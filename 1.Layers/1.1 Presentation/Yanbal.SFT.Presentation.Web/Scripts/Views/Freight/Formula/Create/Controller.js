/// <summary>
/// Script de Controladora de la Vista de Creación de Fórmulas
/// </summary>
/// <remarks>
/// Creación: GMD 20140912 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Formula.Create.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Formula.Create.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmCreateFormula',
                title: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.FormulaValidation.Message.Resources,
                validationsExtra: base.Function.GetValidationsExtra()
            });

            if (base.Function.ApplyBinding(base.Control.ModelCreate, base.Control.Container.getMainContainer())) {
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
                base.Control.ParametersRegistration.TxtParameter().change(base.Event.ChangeParameter);
                base.Control.ParametersRegistration.TxtFactor().keypress(base.Event.EnterKeyPress);
                base.Event.ChangeParameter();
                base.Control.RdoAmountCreate().change(base.Event.ChangeFixedValue);
                base.Control.RdoPercentagCreate().change(base.Event.ChangeFixedValue);
                base.Control.RdoFixedValueCreate().change(base.Event.ChangeFixedValue);
            };
            base.Control.RdoFixedValueCreate().trigger("change");
        };

        base.Control = {
            AjaxCreateSuccessCustom: null,
            Container: null,
            ModelCreate: Yanbal.SFT.Presentation.Web.Freight.Formula.Models.Create,
            Message: new Yanbal.SFT.Web.Components.Message(),
            BtnSave: function () { return $('#btnSaveCreate'); },
            BtnCancel: function () { return $('#btnCancelCreate'); },
            DivCreate: function () { return $('#divCreateFormula'); },

            RdoAdditionCreate: function () { return $('#rdoAdditionCreate'); },
            RdoSubtractionCreate: function () { return $('#rdoSubtractionCreate'); },
            RdoMultiplicationCreate: function () { return $('#rdoMultiplicationCreate'); },
            RdoDivisionCreate: function () { return $('#rdoDivisionCreate'); },
            RdoAmountCreate: function () { return $('#rdoFactorTypeAmountCreate'); },
            RdoPercentagCreate: function () { return $('#rdoFactorTypePercentageCreate'); },
            RdoFixedValueCreate: function () { return $('#rdoFactorTypeFixedValueCreate'); },

            ParametersRegistration: {
                TxtSendType: function () { return $('#slcSendTypeCreate'); },
                TxtParameter: function () { return $('#slcParameterCreate'); },
                TxtParameterValue: function () { return $('#slcParameterValueCreate'); },
                RdoOperation: function () { return $('input[name="rdoOperationCreate"]:checked'); },
                TxtFactor: function () { return $('#txtFactorCreate'); },
                RdoFactorType: function () { return $('input[name="rdoFactorTypeCreate"]:checked'); }
            }
        };

        base.Event = {
            EnterKeyPress: function (event) {
                var key = getKeyCode(event);
                var isValid = !(event && key == 13);
                if (isValid == false) {
                    base.Event.BtnSaveClick();
                }
                return isValid;
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
                console.log(base.Control.RdoFixedValueCreate()[0].checked);
                if (base.Control.RdoFixedValueCreate()[0].checked) {
                    base.Control.RdoAdditionCreate().attr("disabled", true);
                    base.Control.RdoSubtractionCreate().attr("disabled", true);
                    base.Control.RdoMultiplicationCreate().attr("disabled", true);
                    base.Control.RdoDivisionCreate().attr("disabled", true);
                }
                else {
                    base.Control.RdoAdditionCreate().attr("disabled", false);
                    base.Control.RdoSubtractionCreate().attr("disabled", false);
                    base.Control.RdoMultiplicationCreate().attr("disabled", false);
                    base.Control.RdoDivisionCreate().attr("disabled", false);
                }
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                ValueSendType: base.Control.ParametersRegistration.TxtSendType().val(),
                                ParameterCode: base.Control.ParametersRegistration.TxtParameter().val(),
                                Value: base.Control.ParametersRegistration.TxtParameterValue().val(),
                                Operation: base.Control.ParametersRegistration.RdoOperation().val(),
                                FactorString: base.Control.ParametersRegistration.TxtFactor().val(),
                                FactorType: base.Control.ParametersRegistration.RdoFactorType().val()
                            };
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.SatisfactorySaved });
                        if (base.Event.AjaxCreateSuccessCustom != null) {
                            base.Event.AjaxCreateSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelExistingFormula });
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
                action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.RegisterFormula,
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