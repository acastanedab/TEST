/// <summary>
/// Script de Controladora de la Vista de Modificación de Fórmula
/// </summary>
/// <remarks>
/// Creación: GMD 20140912 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Formula.Edit.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Formula.Edit.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmEditFormula',
                title: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.FormulaValidation.Message.Resources,
                validationsExtra: base.Function.GetValidationsExtra()
            });
            if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
                base.Control.ParametersRegistration.TxtParameter().change(base.Event.ChangeParameter);
                base.Control.ParametersRegistration.TxtParameterValue().val(base.Control.ModelEdit.Value);
                base.Control.ParametersRegistration.TxtFactor().keypress(base.Event.EnterKeyPress);
                base.Control.RdoAmountEdit().change(base.Event.ChangeFixedValue);
                base.Control.RdoPercentagEdit().change(base.Event.ChangeFixedValue);
                base.Control.RdoFixedValueEdit().change(base.Event.ChangeFixedValue);
            };
            base.Control.RdoFixedValueEdit().trigger("change");
        };

        base.Control = {
            AjaxEditSuccessCustom: null,
            Container: null,
            ModelEdit: Yanbal.SFT.Presentation.Web.Freight.Formula.Models.Edit,
            Message: new Yanbal.SFT.Web.Components.Message(),
            BtnSave: function () { return $('#btnSaveEdit'); },
            BtnCancel: function () { return $('#btnCancelEdit'); },
            DivEdit: function () { return $('#divEditFormula'); },

            RdoAdditionEdit: function () { return $('#rdoAdditionEdit'); },
            RdoSubtractionEdit: function () { return $('#rdoSubtractionEdit'); },
            RdoMultiplicationEdit: function () { return $('#rdoMultiplicationEdit'); },
            RdoDivisionEdit: function () { return $('#rdoDivisionEdit'); },
            RdoAmountEdit: function () { return $('#rdoFactorTypeAmountEdit'); },
            RdoPercentagEdit: function () { return $('#rdoFactorTypePercentageEdit'); },
            RdoFixedValueEdit: function () { return $('#rdoFactorTypeFixedValueEdit'); },

            ParametersRegistration: {
                TxtSendType: function () { return $('#slcSendTypeEdit'); },
                TxtParameter: function () { return $('#slcParameterEdit'); },
                TxtParameterValue: function () { return $('#slcParameterValueEdit'); },
                RdoOperation: function () { return $('input[name="rdoOperationEdit"]:checked'); },
                TxtFactor: function () { return $('#txtFactorEdit'); },
                RdoFactorType: function () { return $('input[name="rdoFactorTypeEdit"]:checked'); },
                TxtModificationReason: function () { return $('#txtModificationReasonEdit'); },
                TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); }
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

            ChangeParameter: function () {
                var parameterCode = base.Control.ParametersRegistration.TxtParameter().val();
                if (parameterCode != null && parameterCode != "") {
                    base.Ajax.AjaxChangeParameter.data = {
                        parameterCode: parameterCode,
                    };
                    base.Ajax.AjaxChangeParameter.submit();
                }
                else {
                    base.Event.AjaxChangeParameterSuccess(null);
                }
            },

            ChangeFixedValue: function () {
                console.log(base.Control.RdoFixedValueEdit()[0].checked);
                if (base.Control.RdoFixedValueEdit()[0].checked) {
                    base.Control.RdoAdditionEdit().attr("disabled", true);
                    base.Control.RdoSubtractionEdit().attr("disabled", true);
                    base.Control.RdoMultiplicationEdit().attr("disabled", true);
                    base.Control.RdoDivisionEdit().attr("disabled", true);
                }
                else {
                    base.Control.RdoAdditionEdit().attr("disabled", false);
                    base.Control.RdoSubtractionEdit().attr("disabled", false);
                    base.Control.RdoMultiplicationEdit().attr("disabled", false);
                    base.Control.RdoDivisionEdit().attr("disabled", false);
                }
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                FormulaCode: base.Control.ModelEdit.FormulaCode,
                                ParameterCode: base.Control.ParametersRegistration.TxtParameter().val(),
                                Value: base.Control.ParametersRegistration.TxtParameterValue().val(),
                                Operation: base.Control.ParametersRegistration.RdoOperation().val(),
                                FactorString: base.Control.ParametersRegistration.TxtFactor().val(),
                                FactorType: base.Control.ParametersRegistration.RdoFactorType().val(),
                                ValueSendType: base.Control.ParametersRegistration.TxtSendType().val(),
                                RegistrationStatus: base.Control.ParametersRegistration.TxtRegistrationStatus().val(),
                                ModificationReason: base.Control.ParametersRegistration.TxtModificationReason().val()
                            };
                            console.log(base.Ajax.AjaxSave.data);
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.SatisfactorySaved });
                        if (base.Event.AjaxEditSuccessCustom != null) {
                            base.Event.AjaxEditSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelExistingFormula });
                        break;
                    case "4":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelInvalidCancellationFormula });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.FailedSaved });
                }
            },

            AjaxChangeParameterSuccess: function (data) {
                base.Control.ParametersRegistration.TxtParameterValue().find('option').remove();
                base.Control.ParametersRegistration.TxtParameterValue().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelSelect));
                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.ParametersRegistration.TxtParameterValue().append($("<option />").val(value.Id).text(value.Name));
                    });
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
            },
            GetValidationsExtra: function () {                
                var validationsExtra = new Array();
                validationsExtra.push({
                    Event: function () {
                        var isValido = true;
                        var operation = base.Control.ParametersRegistration.RdoOperation().val();
                        var factor = base.Control.ParametersRegistration.TxtFactor().val();
                        if (operation != '*' && ConvertDecimal(factor) == 0) {
                            var isValido = false;
                        }

                        return isValido;
                    },
                    codeMessage: "InvalidFactorOperation"
                });                
                return validationsExtra;
            }
        };

        base.Ajax = {
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.ModifyFormula,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),

            AjaxChangeParameter: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.ChangeParameter,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeParameterSuccess
            })
        };
    };
}
catch (ex) {
    alert(ex.message);
}