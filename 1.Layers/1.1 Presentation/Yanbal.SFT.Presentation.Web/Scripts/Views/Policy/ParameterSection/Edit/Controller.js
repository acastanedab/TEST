/// <summary>
/// Script de Controladora de la Vista de la Vista Editar de Parámetro Sección
/// </summary>
/// <remarks>
/// Creación: GMD 20140821 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Edit.Controller');
    Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Edit.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmEditParameterSection',
                messages: Yanbal.SFT.Presentation.Web.ParameterSectionValidation.Message.Resources
            });
            if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
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
            AjaxEditSuccessCustom: null,
            ModelEdit: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Models.Edit,
            BtnSave: function () { return $('#btnSaveEditParameterSection'); },
            BtnCancel: function () { return $('#btnCancelEditParameterSection'); },
            DivEdit: function () { return $('#divEditParameterSection'); },
            ParametersRegistration: {
                TxtCodeParameterSection: function () { return $('#hdnCodeParameterSectionEdit'); },
                TxtSectionName: function () { return $('#txtSectionNameEdit'); },
                TxtSectionType: function () { return $('#slcSectionTypeEdit'); },
                ChkReadOnly: function () { return $('#chkReadOnlyEdit'); },
                ChkRequired: function () { return $('#chkRequiredEdit'); },
                TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
                TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
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
                            base.Ajax.AjaxSave.data = {
                                CodeParameter: base.Control.ModelEdit.CodeParameter,
                                Code: base.Control.ModelEdit.Code,
                                CodeParameterSection: base.Control.ModelEdit.CodeSection,
                                Name: base.Control.ParametersRegistration.TxtSectionName().val().trim(),
                                CodeParameterSectionType: base.Control.ParametersRegistration.TxtSectionType().val(),
                                ReadOnlyIndicator: base.Control.ParametersRegistration.ChkReadOnly().is(':checked'),
                                RequiredIndicator: base.Control.ParametersRegistration.ChkRequired().is(':checked'),
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
                            message: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelSatisfactorySaved
                        });
                        if (base.Event.AjaxEditSuccessCustom != null) {
                            base.Event.AjaxEditSuccessCustom(data);
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
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Actions.ModififyParameterSection,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),
        };
    };
}
catch (ex) {
    alert(ex.message);
}