/// <summary>
/// Script de Controladora de la Vista de Modificación de Combinación
/// </summary>
/// <remarks>
/// Creación: GMD 20140908 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Combination.Edit.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Combination.Edit.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmEditCombination',
                title: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.CombinationValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
                base.Control.ParametersRegistration.TxtFreightAmount().keypress(base.Event.EnterKeyPress);
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            };
        };

        base.Control = {
            AjaxEditSuccessCustom: null,
            Container: null,
            ModelEdit: Yanbal.SFT.Presentation.Web.Freight.Combination.Models.Edit,
            Message: new Yanbal.SFT.Web.Components.Message(),
            BtnSave: function () { return $('#btnSaveEdit'); },
            BtnCancel: function () { return $('#btnCancelEdit'); },
            DivEdit: function () { return $('#divEditCombination'); },
            ParametersRegistration: {
                TxtCodeCombination: function () { return $('#hdnCodeCombinationEdit') },
                TxtFreightAmount: function () { return $('#txtFreightAmountEdit'); },
                TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
                TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
            }
        };

        base.Event = {
            EnterKeyPress: function (event) {
                var key = getKeyCode(event);
                var isValido = !(event && key == 13);
                if (isValido == false) {
                    base.Event.BtnSaveClick();
                }
                return isValido;
            },

            BtnCancelClick: function () {
                base.Control.Container.close();
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                CombinationCode: base.Control.ParametersRegistration.TxtCodeCombination().val(),
                                AmountFreightString: base.Control.ParametersRegistration.TxtFreightAmount().val(),
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
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.SatisfactorySaved });
                        if (base.Event.AjaxEditSuccessCustom != null) {
                            base.Event.AjaxEditSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelExistingParameter });
                        break;
                    case "4":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelInvalidParameter });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.FailedSaved });
                        break;
                }
            },
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
                    base.Control.Message.Warning({ message: Yanbal.SFT.Web.Shared.Resources.ErrorCargarViewModel });
                }
                return isValid;
            }
        };

        base.Ajax = {
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.ModifyCombination,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),
        };
    };
}
catch (ex) {
    alert(ex.message);
}