/// <summary>
/// Script de Controladora de la Vista de la vista Edit 
/// </summary>
/// <remarks>
/// Creación: GMD 20140721 <br />
/// </remarks>

ns('Yanbal.SFT.Presentation.Web.Freigth.Policy.ParameterValue.Edit.Controller');
Yanbal.SFT.Presentation.Web.Freigth.Policy.ParameterValue.Edit.Controller = function () {
    var base = this;
    base.Ini = function (opts){
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
        base.Control.BtnSave().click(base.Event.BtnSaveClick);
        base.Control.BtnCancel().click(base.Event.BtnCancelClick);
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmEditParameterValue',
            messages: Yanbal.SFT.Presentation.Web.ParameterValueValidationEdit.Message.Resources
        });
        if (base.Function.ApplyBinding(base.Control.ModelParameterValue, base.Control.Container.getMainContainer())) {
            $("input[nameEdit = txtValueEdit]").keypress(base.Event.EnterKeyPress);
            base.Control.Calendar = new Yanbal.SFT.Web.Components.Calendar({
                inputFrom: $("input[typeSectionEdit = " + base.Control.TypeSectionDate + "]")
            });

            if (base.Control.ModelParameterValue.Parameter.CodeParameterType == base.Control.TypeParameterRange) {
                var rangeIni = $("input[typeRangeEdit = " + base.Control.TypeRangeIni + "]");
                var rangeEnd = $("input[typeRangeEdit = " + base.Control.TypeRangeEnd + "]");

                if (rangeIni.attr("typeSectionEdit") == Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDate) {
                    base.Control.Calendar = new Yanbal.SFT.Web.Components.Calendar({
                        inputFrom: rangeIni,
                        inputTo: rangeEnd
                    });
                }
                else {
                    rangeEnd.blur(base.Event.BlurRangeEnd);
                    rangeEnd.blur(base.Event.BlurRangeEnd);
                }
            }
            $("input[typeSectionEdit = " + base.Control.TypeSectionDate + "]").keypress(base.Event.KeypressDate);
            $("input[typeSectionEdit = " + base.Control.TypeSectionDate + "]").bind('paste', base.Event.PasteDate);
        }
    };
    base.Control = {
        Validator: null,
        Container: null,
        AjaxEditSuccessCustom: null,
        TypeParameterRange: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.ParameterTypeRange,
        TypeRangeIni: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.RangeTypeBegin,
        TypeRangeEnd: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.RangeTypeEnd,
        TypeSectionDate: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDate,
        TypeSectionInteger: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeInteger,
        TypeSectionDecimal: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDecimal,
        Message: new Yanbal.SFT.Web.Components.Message(),
        ModelParameterValue: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Models.Edit,
        BtnSave: function () { return $('#btnSaveEdit'); },
        BtnCancel: function () { return $('#btnCancelEdit'); },
        DivEdit: function () { return $('#divEditParameterValue') },
        ParameterRegistration: {
            TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
            TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
        }
    };
    base.Event = {
        PasteDate: function (e) {
            return validateCopyDate(e);
        },

        KeypressDate: function (e) {
            var key = getKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
                base.Event.BtnSaveClick();
            } else {
                return validarFormatoFecha((this), e);
            }
            return esValido;
        },

        BlurRangeBeg: function (e) {
            var rangeIni = $("input[typeRangeEdit = " + base.Control.TypeRangeIni + "]");
            var rangeEnd = $("input[typeRangeEdit = " + base.Control.TypeRangeEnd + "]");
            var rangeIniValue = null;
            var rangeEndValue = null;
            if (rangeIni.val().trim() != "" && rangeEnd.val().trim() != "") {
                switch (rangeEnd.attr("typeSectionEdit")) {
                    case base.Control.TypeSectionInteger:
                        rangeIniValue = ConvertInteger(rangeIni.val());
                        rangeEndValue = ConvertInteger(rangeEnd.val());
                        break;
                    case base.Control.TypeSectionDecimal:
                        rangeIniValue = ConvertDecimal(rangeIni.val());
                        rangeEndValue = ConvertDecimal(rangeEnd.val());
                        break;
                    default:
                        rangeIniValue = rangeIni.val();
                        rangeEndValue = rangeEnd.val();
                }
                if (rangeIniValue > rangeEndValue) {
                    rangeIni.attr("value", rangeEnd.val());
                }
            }
        },

        BlurRangeEnd: function (e) {
            var rangeIni = $("input[typeRangeEdit = " + base.Control.TypeRangeIni + "]");
            var rangeEnd = $("input[typeRangeEdit = " + base.Control.TypeRangeEnd + "]");
            var rangeIniValue = null;
            var rangeEndValue = null;
            if (rangeIni.val().trim() != "" && rangeEnd.val().trim() != "") {
                switch (rangeEnd.attr("typeSectionEdit")) {
                    case base.Control.TypeSectionInteger:
                        rangeIniValue = ConvertInteger(rangeIni.val());
                        rangeEndValue = ConvertInteger(rangeEnd.val());
                        break;
                    case base.Control.TypeSectionDecimal:
                        rangeIniValue = ConvertDecimal(rangeIni.val());
                        rangeEndValue = ConvertDecimal(rangeEnd.val());
                        break;
                    default:
                        rangeIniValue = rangeIni.val();
                        rangeEndValue = rangeEnd.val();
                }
                if (rangeIniValue > rangeEndValue) {
                    rangeEnd.attr("value", rangeIni.val());
                }
            }
        },
        EnterKeyPress: function (event){
            var key = getKeyCode(event);
            var isValid =!(event && key == 13);
            if (isValid == false) {
                base.Event.BtnSaveClick();
            }
            return isValid;
        },
        BtnCancelClick: function () {
            base.Control.Container.close();
        },
        BtnSaveClick: function() {
            if (base.Control.Validator.isValid()) {
                base.Control.Message.Confirmation({
                    title: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelConfirmationHeader,
                    message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelSaveConfirmation,
                    onAccept: function () {
                        var array = new Array();
                        $.each($("input[nameEdit = txtValueEdit]"), function (index, value) {
                            array.push({ Key: $(value).attr('idSectionEdit'), Value: $(value).val() });
                        });
                        base.Ajax.AjaxSave.data = {
                            CodeParameter: base.Control.ModelParameterValue.CodeParameter,
                            CodeValue: base.Control.ModelParameterValue.CodeValue,
                            RecordValueString: array,
                            RegistrationStatus: base.Control.ParameterRegistration.TxtRegistrationStatus().val(),
                            ModificationReason: base.Control.ParameterRegistration.TxtModificationReason().val()
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
                    base.Control.Message.Information({
                        message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.SatisfactorySaved
                    });
                    if (base.Event.AjaxEditSuccessCustom != null) {
                        base.Event.AjaxEditSuccessCustom(data);
                    }
                    base.Control.Container.close();
                    break;
                case "3":
                    base.Control.Message.Warning({
                        message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.DuplicateParameter
                    });
                    break;
                case "4":
                    base.Control.Message.Warning({
                        message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelParameterValueExistingInTableParameterCombinationFormula
                    });
                    break;
                case "5":
                    base.Control.Message.Warning({
                        message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelParameterValueExistingInTableParameterCombination
                    });
                    break;
                case "6":
                    base.Control.Message.Warning({
                        message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelParameterValueExistingInTableFormula
                    });
                    break;
                default:
                    base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.FailedSaved });
                    break;
            }
        }        
    };
    base.Ajax = {
        AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Actions.ModififyParameterValue,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSaveSuccess
        })
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
    }
};