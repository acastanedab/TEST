/// <summary>
/// Script de Controladora de la Vista de Modificación de Cultura
/// </summary>
/// <remarks>
/// Creación: GMD 20140923 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.Culture.Edit.Controller');
Yanbal.SFT.Presentation.Web.Policy.Culture.Edit.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
        base.Control.ParametersRegistration.SpnUpperLimitYear().keypress(base.Event.NumericFieldValidation);
        base.Control.ParametersRegistration.SpnLowerLimitYear().spinner('option', 'disabled', true);
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmEditCulture',
            messages: Yanbal.SFT.Presentation.Web.CultureValidation.Message.Resources
        });
        base.Control.ParametersRegistration.SpnUpperLimitYear().bind('spinchange', function (event, ui) {
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
        if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Edit, base.Control.Container.getMainContainer())) {
            base.Control.BtnSave().click(base.Event.BtnSaveClick);
            base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            base.Control.BtnColor().colorpicker({
                showOn: 'both',
                buttonColorize: true,
                showNoneButton: false,
                alpha: true,
            });
        };
        base.Control.ParametersRegistration.SpnUpperLimitYear().keypress(base.Event.EnterKeyPress);
    };

    base.Control = {
        Validator: null,
        AjaxEditSuccessCustom: null,
        Container: null,
        CodParametro: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        Model: Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Edit,
        BtnColor: function () { return $('#BindedEdit'); },
        BtnSave: function () { return $('#btnSaveEdit'); },
        BtnCancel: function () { return $('#btnCancelEdit'); },
        ParametersRegistration: {
            TxtLanguage: function () { return $('#slcLanguageEdit'); },
            TxtCountry: function () { return $('#slcCountryEdit'); },
            TxtShortDateFormat: function () { return $('#slcShortDateFormatEdit'); },
            TxtLongDateFormat: function () { return $('#slcLongDateFormatEdit'); },
            TxtShortTimeFormat: function () { return $('#slcShortTimeFormatEdit'); },
            TxtLongTimeFormat: function () { return $('#slcLongTimeFormatEdit'); },
            TxtFormatIntegerNumber: function () { return $('#slcFormatIntegerNumberEdit'); },
            TxtFormatDecimalNumber: function () { return $('#slcFormatDecimalNumberEdit'); },
            TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
            TxtModificationReason: function () { return $('#txtModificationReasonEdit'); },
            SpnLowerLimitYear: function () { return $('#spnLowerLimitYearEdit').spinner({}); },
            SpnUpperLimitYear: function () { return $('#spnUpperLimitYearEdit').spinner({}); }
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
                            CultureCode: base.Control.Model.CultureCode,
                            LanguageCode: base.Control.ParametersRegistration.TxtLanguage().val(),
                            CountryCode: base.Control.ParametersRegistration.TxtCountry().val(),
                            CodeShortDateFormat: base.Control.ParametersRegistration.TxtShortDateFormat().val(),
                            CodeLongDateFormat: base.Control.ParametersRegistration.TxtLongDateFormat().val(),
                            CodeShortTimeFormat: base.Control.ParametersRegistration.TxtShortTimeFormat().val(),
                            CodeLongTimeFormat: base.Control.ParametersRegistration.TxtLongTimeFormat().val(),
                            CodeFormatIntegerNumber: base.Control.ParametersRegistration.TxtFormatIntegerNumber().val(),
                            CodeFormatDecimalNumber: base.Control.ParametersRegistration.TxtFormatDecimalNumber().val(),
                            UpperLimitYear: base.Control.ParametersRegistration.SpnUpperLimitYear().val(),
                            RegistrationStatus: base.Control.ParametersRegistration.TxtRegistrationStatus().val(),
                            ModificationReason: base.Control.ParametersRegistration.TxtModificationReason().val(),
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
                    if (base.Event.AjaxEditSuccessCustom != null) {
                        base.Event.AjaxEditSuccessCustom(data);
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
            action: Yanbal.SFT.Presentation.Web.Policy.Culture.Actions.ModifyCulture,
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