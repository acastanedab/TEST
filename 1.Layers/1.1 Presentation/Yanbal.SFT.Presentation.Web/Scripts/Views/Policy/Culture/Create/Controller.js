/// <summary>
/// Script de Controladora de la Registro de Cultura
/// </summary>
/// <remarks>
/// Creación: GMD 20140923 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.Culture.Create.Controller');
Yanbal.SFT.Presentation.Web.Policy.Culture.Create.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;
        base.Control.ParametersRegistration.SpnUpperLimitYear().keypress(base.Event.NumericFieldValidation);
        base.Control.ParametersRegistration.SpnLowerLimitYear().spinner('option', 'disabled', true);
        base.Control.ParametersRegistration.SpnLowerLimitYear().spinner({ disabled: true });
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmCreateCulture',
            messages: Yanbal.SFT.Presentation.Web.CultureValidation.Message.Resources
        });

        if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Create, base.Control.Container.getMainContainer())) {
            base.Control.BtnSave().click(base.Event.BtnSaveClick);
            base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            base.Control.BtnColor().colorpicker({
                showOn: 'both',
                buttonColorize: true,
                showNoneButton: false,
                alpha: true,
            });
        };

        base.Control.ParametersRegistration.SpnUpperLimitYear().on('spinchange', function (event, ui) {
            var valueYear = base.Control.ParametersRegistration.SpnUpperLimitYear().val()
            var total = parseInt(0);
            total = parseInt(valueYear);
            if (total < 99) {
                base.Control.ParametersRegistration.SpnLowerLimitYear().val(0);
            }
            else {
                total = parseInt(valueYear) - 99
                base.Control.ParametersRegistration.SpnLowerLimitYear().val(total);
            }
            if (valueYear == undefined || valueYear == null || valueYear == '')
                base.Control.ParametersRegistration.SpnLowerLimitYear().val('');
        });

        base.Control.ParametersRegistration.TxtCultureCode().mask("SS-SS");
        base.Control.ParametersRegistration.TxtCultureCode().keypress(base.Event.EnterKeyPress);
        base.Control.ParametersRegistration.SpnUpperLimitYear().keypress(base.Event.EnterKeyPress);
    };

    base.Control = {
        Validator: null,
        AjaxCreateSuccessCustom: null,
        Container: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        Model: Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Create,
        BtnColor: function () { return $('#BindedCreate'); },
        BtnSave: function () { return $('#btnSaveCreate'); },
        BtnCancel: function () { return $('#btnCancelCreate'); },
        ParametersRegistration: {
            TxtCultureCode: function () { return $('#txtCultureCodeCreate'); },
            TxtLanguage: function () { return $('#slcLanguageCreate'); },
            TxtCountry: function () { return $('#slcCountryCreate'); },
            TxtShortDateFormat: function () { return $('#slcShortDateFormatCreate'); },
            TxtLongDateFormat: function () { return $('#slcLongDateFormatCreate'); },
            TxtShortTimeFormat: function () { return $('#slcShortTimeFormatCreate'); },
            TxtLongTimeFormat: function () { return $('#slcLongTimeFormatCreate'); },
            TxtFormatIntegerNumber: function () { return $('#slcFormatIntegerNumberCreate'); },
            TxtFormatDecimalNumber: function () { return $('#slcFormatDecimalNumberCreate'); },
            SpnLowerLimitYear: function () { return $('#spnLowerLimitYearCreate').spinner({}); },
            SpnUpperLimitYear: function () { return $('#spnUpperLimitYearCreate').spinner({}); }
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

        NumericFieldValidation: function (e) {
            return validateOnlyNumbers(e);
        },

        BtnSaveClick: function () {
            if (base.Control.Validator.isValid()) {
                base.Control.Message.Confirmation({
                    title: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelConfirmationHeader,
                    message: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelSaveConfirmation,
                    onAccept: function () {
                        base.Ajax.AjaxSave.data = {
                            CultureCode: base.Control.ParametersRegistration.TxtCultureCode().val().toUpperCase(),
                            LanguageCode: base.Control.ParametersRegistration.TxtLanguage().val(),
                            CountryCode: base.Control.ParametersRegistration.TxtCountry().val(),
                            CodeShortDateFormat: base.Control.ParametersRegistration.TxtShortDateFormat().val(),
                            CodeLongDateFormat: base.Control.ParametersRegistration.TxtLongDateFormat().val(),
                            CodeShortTimeFormat: base.Control.ParametersRegistration.TxtShortTimeFormat().val(),
                            CodeLongTimeFormat: base.Control.ParametersRegistration.TxtLongTimeFormat().val(),
                            CodeFormatIntegerNumber: base.Control.ParametersRegistration.TxtFormatIntegerNumber().val(),
                            CodeFormatDecimalNumber: base.Control.ParametersRegistration.TxtFormatDecimalNumber().val(),
                            UpperLimitYear: base.Control.ParametersRegistration.SpnUpperLimitYear().val(),
                        };
                        base.Ajax.AjaxSave.submit();
                    }
                });
            }
        },

        BtnCancelClick: function () {
            base.Control.Container.close();
        },

        AjaxSaveSuccess: function (data) {
            switch (data) {
                case "1":
                    base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.SatisfactorySaved });
                    if (base.Event.AjaxCreateSuccessCustom != null) {
                        base.Event.AjaxCreateSuccessCustom(data);
                    }
                    base.Control.Container.close();
                    break;
                case "3":
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelExistingCulture });
                    break;
                default:
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.FailedSaved });
                    break;
            }
        }
    };

    base.Ajax = {
        AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.Culture.Actions.RegisterCulture,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSaveSuccess
        }),
    };

    base.Function = {
        GetAdditionalValidations: function () {
            var AdditionalValidations = new Array();
            AdditionalValidations.push({
                Event: function () { return (!base.Control.ParametersRegistration.SpnUpperLimitYear().val() < 1999); },
                codeMessage: 'ValidateSuperiorYear'
            });

            return AdditionalValidations;
        },

        validarFormatoCultura: function (campo, evento) {
            var cultura = campo.value;
            var charCode = (evento.charCode) ? evento.charCode : ((evento.keyCode) ? evento.keyCode
			: ((evento.which) ? evento.which : 0));
            var ultimo = String.fromCharCode(charCode);
            if (charCode == 8 || charCode == 9 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 38 || charCode == 39 || charCode == 40) {
                return true;
            }
            else {
                if (cultura.length < 5) {

                    if (validarSoloLetras(evento)) {
                        if (cultura.length < 2) {
                            var culturafinal = cultura + ultimo;
                            if (culturafinal.length < 3) {
                                if (culturafinal.length == 2) culturafinal = culturafinal + '-';
                                cultura = culturafinal;
                            }
                        } else {
                            var culturafinal = cultura + ultimo;
                            cultura = culturafinal;
                        }
                    }
                }
            }

            campo.value = cultura;
            return false;
        },

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
                base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Resources.ErrorCargarViewModel });
            }
            return isValid;
        }
    }
};