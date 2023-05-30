/// <summary>
/// Script de Controladora de la Vista de Editar Parámetros
/// </summary>
/// <remarks>
/// Creación: GMD 20140821 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.Parameter.Edit.Controller');
    Yanbal.SFT.Presentation.Web.Policy.Parameter.Edit.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmEditParameter',
                messages: Yanbal.SFT.Presentation.Web.ParameterValidation.Message.Resources
            });
            if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
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
            AjaxEditSuccessCustom: null,
            ModelEdit: Yanbal.SFT.Presentation.Web.Policy.Parameter.Models.Edit,
            BtnSave: function () { return $('#btnSaveEditParameter'); },
            BtnCancel: function () { return $('#btnCancelEditParameter'); },
            DivEdit: function () { return $('#divEditParameter'); },
            ParametersRegistration: {
                TxtName: function () { return $('#txtParameterNameEdit'); },
                TxtDescription: function () { return $('#txtParameterDescriptionEdit'); },
                TxtParameterType: function () { return $('#slcParameterTypeEdit'); },
                ChkAllowAddValue: function () { return $('#chkAllowAddValueEdit'); },
                ChkAllowModifyValue: function () { return $('#chkAllowModifyValueEdit'); },
                TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
                TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
            }
        };

        base.Event = {
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
                                CodeParameter: base.Control.ModelEdit.CodeParamater,
                                Code: base.Control.ModelEdit.Code,
                                ParameterName: base.Control.ParametersRegistration.TxtName().val().trim(),
                                ParameterDescription: base.Control.ParametersRegistration.TxtDescription().val().trim(),
                                CodeParameterType: base.Control.ParametersRegistration.TxtParameterType().val(),
                                AllowAddValueIndicator: base.Control.ParametersRegistration.ChkAllowAddValue().is(':checked'),
                                AllowModifyValueIndicator: base.Control.ParametersRegistration.ChkAllowModifyValue().is(':checked'),
                                RegistrationStatus: base.Control.ParametersRegistration.TxtRegistrationStatus().val(),
                                ModificationReason: base.Control.ParametersRegistration.TxtModificationReason().val()
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
                        if (base.Event.AjaxEditSuccessCustom != null) {
                            base.Event.AjaxEditSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;

                    case "3":
                        base.Control.Message.Warning({
                            message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelExistingName
                        });
                        break;

                    case "4":
                        base.Control.Message.Warning({
                            message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelExistingParameterInTableCombinationOrderFormula
                        });
                        break;

                    case "5":
                        base.Control.Message.Warning({
                            message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelExistingParameterInTableCombinationOrder
                        });
                        break;

                    case "6":
                        base.Control.Message.Warning({
                            message: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelExistingInTableFormula
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
                action: Yanbal.SFT.Presentation.Web.Policy.Parameter.Actions.ModifyParameter,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),
        };
    };
}
catch (ex) {
    alert(ex.message);
}