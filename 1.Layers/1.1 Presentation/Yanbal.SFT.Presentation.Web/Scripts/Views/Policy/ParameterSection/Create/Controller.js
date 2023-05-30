/// <summary>
/// Script de Controladora de la Vista de Creación Parámetros Section 
/// </summary>
/// <remarks>
/// Creación: GMD 20140721 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Create.Controller');
    Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Create.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmCreateParameterSection',
                messages: Yanbal.SFT.Presentation.Web.ParameterSectionValidation.Message.Resources
            });
            if (base.Function.ApplyBinding(base.Control.ModelCreate, base.Control.Container.getMainContainer())) {
                base.Control.ParametersRegistration.TxtSectionName().keypress(base.Event.EnterKeyPress);
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            };
        };
        base.Parameters = {

        };

        base.Control = {
            Container: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            ModelCreate: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Models.Create,
            AjaxCreateSuccessCustom: null,
            BtnSave: function () { return $('#btnSaveParameterSection'); },
            BtnCancel: function () { return $('#btnCancelParameterSection'); },
            DivCreate: function () { return $('#divCreateParameterSection'); },
            ParametersRegistration: {
                TxtSectionName: function () { return $('#txtSectionName'); },
                TxtSectionType: function () { return $('#slcSectionType'); },
                ChkReadOnly: function () { return $('#chkReadOnly'); },
                ChkRequired: function () { return $('#chkRequired'); }
            }
        };

        base.Event = {
            EnterKeyPress: function (evento) {
                var key = getKeyCode(evento);
                var esValido = !(evento && key == 13);
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
                        title: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxGrabar.data = {
                                CodeParameter: base.Control.ModelCreate.CodeParameter,
                                Code: base.Control.ModelCreate.Code,
                                Name: base.Control.ParametersRegistration.TxtSectionName().val().trim(),
                                CodeParameterSectionType: base.Control.ParametersRegistration.TxtSectionType().val(),
                                ReadOnlyIndicator: base.Control.ParametersRegistration.ChkReadOnly().is(':checked'),
                                RequiredIndicator: base.Control.ParametersRegistration.ChkRequired().is(':checked')
                            };
                            base.Ajax.AjaxGrabar.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({
                            message: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelSatisfactorySaved
                        });
                        if (base.Event.AjaxCreateSuccessCustom != null) {
                            base.Event.AjaxCreateSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;

                    case "3":
                        base.Control.Message.Warning({
                            message: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelExistingName
                        });
                        break;

                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelFailedSaved });
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
            AjaxGrabar: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Actions.RegisterParameterSection,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),
        };
    };
}
catch (ex) {
    alert(ex.message);
}