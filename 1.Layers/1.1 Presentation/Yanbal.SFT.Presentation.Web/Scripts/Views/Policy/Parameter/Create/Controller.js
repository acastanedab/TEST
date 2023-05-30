/// <summary>
/// Script de Controladora de la Vista de Creación de Parámetros
/// </summary>
/// <remarks>
/// Creacion: GMD 20140721 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.Parameter.Create.Controller');
    Yanbal.SFT.Presentation.Web.Policy.Parameter.Create.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmCreateParameter',
                messages: Yanbal.SFT.Presentation.Web.ParameterValidation.Message.Resources
            });
            if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.Parameter.Models.Nuevo, base.Control.Container.getMainContainer())) {
                base.Control.ParametersRegistration.TxtCode().keypress(base.Event.EventCodeKeyPress);
                base.Control.ParametersRegistration.TxtCode().bind('paste', base.Event.EventCodePaste);
                base.Control.ParametersRegistration.TxtCode().blur(base.Event.EventCodeBlur);
                base.Control.ParametersRegistration.TxtName().keypress(base.Event.EnterKeyPress);
                base.Control.ParametersRegistration.TxtDescription().keypress(base.Event.EnterKeyPress);
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            };
        };
        base.Parameters = {

        };

        base.Control = {
            Container: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            AjaxCreateSuccessCustom: null,
            BtnSave: function () { return $('#btnSaveParameter'); },
            BtnCancel: function () { return $('#btnCancelParameter'); },
            DivCreate: function () { return $('#divCreateParameter'); },
            ParametersRegistration: {
                TxtCode: function () { return $('#txtCodeCreate'); },
                TxtName: function () { return $('#txtNameCreate'); },
                TxtDescription: function () { return $('#txtDescriptionCreate'); },
                TxtParameterType: function () { return $('#slcParameterTypeCreate'); },
                ChkAllowAddValue: function () { return $('#chkAllowAddValueCreate'); },
                ChkAllowModifyValue: function () { return $('#chkAllowModifyValueCreate'); }
            }
        };

        base.Event = {
            EventCodePaste: function (event) {
                var esValido = validateCopyOnlyLetters(event);
                return esValido;
            },

            EventCodeBlur: function (event) {
                base.Control.ParametersRegistration.TxtCode().attr('value', base.Control.ParametersRegistration.TxtCode().val().toUpperCase());
            },

            EventCodeKeyPress: function (event) {
                var esValido = validateOnlyLetters(event);
                if (esValido) {
                    ConvertShift();
                    var key = getKeyCode(event);
                    esValido = !(event && key == 13);
                    if (esValido == false) {
                        base.Event.BtnSaveClick();
                    }
                }
                return esValido;
            },

            EnterKeyPress: function (event) {
                var key = getKeyCode(event);
                var esValido = !(event && key == 13);
                if (esValido == false) {
                    base.Event.BtnSaveClick();
                }
                return esValido;
            },
            BtnCancelClick: function () {
                base.Control.Container.close();
            },
            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.TagConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.TagSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                Code: base.Control.ParametersRegistration.TxtCode().val(),
                                ParameterName: base.Control.ParametersRegistration.TxtName().val().trim(),
                                ParameterDescription: base.Control.ParametersRegistration.TxtDescription().val().trim(),
                                CodeParameterType: base.Control.ParametersRegistration.TxtParameterType().val(),
                                AllowAddValueIndicator: base.Control.ParametersRegistration.ChkAllowAddValue().is(':checked'),
                                AllowModifyValueIndicator: base.Control.ParametersRegistration.ChkAllowModifyValue().is(':checked')
                            };
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({
                            message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.SatisfactorySaved
                        });
                        if (base.Event.AjaxCreateSuccessCustom != null) {
                            base.Event.AjaxCreateSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;

                    case "3":
                        base.Control.Message.Warning({
                            message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelExistingName
                        });
                        break;

                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.FailedSaved });
                }
            }
        };
        base.Function = {
            ApplyBinding: function (model, container) {
                var isValid = (typeof model !== 'undefined');

                if (isValid) {
                    var containerDom = (container) ? container[0] : container;
                    isValid = (model.Error.Code == 0);
                    if (isValid) {
                        ko.applyBindings(model, containerDom);
                    } else {
                        base.Control.Message.Warning({ message: model.Error.Message });
                    }
                } else {
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
                }
                return isValid;
            }
        };

        base.Ajax = {
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.Parameter.Actions.RegisterParameter,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),
        };
    };
}
catch (ex) {
    alert(ex.message);
}