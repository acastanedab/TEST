/// <summary>
/// Script de Controladora de la Vista de Edición de Orden de Combinación
/// </summary>
/// <remarks>
/// Creación: GMD 20140910 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Edit.Controller');
Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Edit.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmEditFormulaOrder',
            title: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelConfirmationHeader,
            messages: Yanbal.SFT.Presentation.Web.FormulaOrderValidation.Message.Resources,
        });

        if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
            base.Control.BtnSave().click(base.Event.BtnSaveClick);
            base.Control.BtnCancel().click(base.Event.BtnCancelClick);
        };
    };

    base.Parameters = {

    };

    base.Control = {
        AjaxEditSuccessCustom: null,
        Container: null,
        ModelEdit: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Models.Edit,
        Message: new Yanbal.SFT.Web.Components.Message(),
        BtnSave: function () { return $('#btnSaveEdit'); },
        BtnCancel: function () { return $('#btnCancelEdit'); },
        ParametersRegistration: {
            TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
        }
    };

    base.Event = {
        BtnCancelClick: function () {
            base.Control.Container.close();
        },

        BtnSaveClick: function () {
            if (base.Control.Validator.isValid()) {
                base.Control.Message.Confirmation({
                    title: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelConfirmationHeader,
                    message: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelSaveConfirmation,
                    onAccept: function () {
                        base.Ajax.AjaxSave.data = {
                            FormulaCode: base.Control.ModelEdit.FormulaCode,
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
                    base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.SatisfactorySaved });
                    if (base.Event.AjaxEditSuccessCustom != null) {
                        base.Event.AjaxEditSuccessCustom(data);
                    }
                    base.Control.Container.close();
                    break;
                default:
                    base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.FailedSaved });
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
                base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
            }
            return isValid;
        }
    };
    base.Ajax = {
        AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Actions.ModifyFormulaOrder,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSaveSuccess
        })
    };
};