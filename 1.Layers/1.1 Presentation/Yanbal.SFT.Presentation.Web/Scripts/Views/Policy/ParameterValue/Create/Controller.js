/// <summary>
/// Script de Controladora de la Vista Create de Parámetro Valor
/// </summary>
/// <remarks>
/// Creación: GMD 20140721 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Freigth.Policy.ParameterValue.Create.Controller');
 
Yanbal.SFT.Presentation.Web.Freigth.Policy.ParameterValue.Create.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;
        base.Control.BtnSave().click(base.Event.BtnSaveClick);
        base.Control.BtnCancel().click(base.Event.BtnCancelClick);
        base.Control.DivCreate().dialog({
            autoOpen: false,
            higth: 500,
            width: 900,
            modal: true
        });

        base.Control.Validador = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmCreateParameterValue',
            messages: Yanbal.SFT.Presentation.Web.ParameterValueValidationCreate.Message.Resources
        });

        if (base.Function.ApplyBinding(base.Control.ModelCreate, base.Control.Container.getMainContainer())) {
            $("input[nameCreate = txtValueCreate]").keypress(base.Event.EnterKeyPress);
            base.Control.Calendar = new Yanbal.SFT.Web.Components.Calendar({
                inputFrom: $("input[typeSectionCreate = " + base.Control.TypeSectionDate + "]")
            });

            if (base.Control.ModelCreate.Parameter.CodeParameterType == base.Control.TypeParameterRange) {
                var rangeIni = $("input[typeRangeCreate = " + base.Control.TypeRangeIni + "]");
                var rangeEnd = $("input[typeRangeCreate = " + base.Control.TypeRangeEnd + "]");

                if (rangeIni.attr("typeSectionCreate") == Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDate) {
                    base.Control.Calendar = new Yanbal.SFT.Web.Components.Calendar({
                        inputFrom: rangeIni,
                        inputTo: rangeEnd
                    });
                }
                else {
                    rangeIni.blur(base.Event.BlurRangeBeg);
                    rangeEnd.blur(base.Event.BlurRangeEnd);
                }
            }
            $("input[typeSectionCreate = " + base.Control.TypeSectionDate + "]").keypress(base.Event.KeypressDate);
            $("input[typeSectionCreate = " + base.Control.TypeSectionDate + "]").bind('paste', base.Event.PasteDate);
            
        }
    };
    base.Control = {
        Validador: null,
        Calendar: null,
        AjaxCreateSuccessCustom: null,
        Container: null,
        ModelCreate: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Models.Create,
        TypeParameterRange: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.ParameterTypeRange,
        TypeSectionDate: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDate,
        TypeSectionInteger: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeInteger,
        TypeSectionDecimal: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDecimal,
        TypeRangeIni: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.RangeTypeBegin,
        TypeRangeEnd: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.RangeTypeEnd,
        Message: new Yanbal.SFT.Web.Components.Message(),
        BtnSave: function () { return $('#btnSaveCreate'); },
        BtnCancel: function () { return $('#btnCancelCreate'); },
        DivCreate: function () { return $('#divCreateParameterValue'); }
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
            var rangeIni = $("input[typeRangeCreate = " + base.Control.TypeRangeIni + "]");
            var rangeEnd = $("input[typeRangeCreate = " + base.Control.TypeRangeEnd + "]");
            var rangeIniValue = null;
            var rangeEndValue = null;
            if (rangeIni.val().trim() != "" && rangeEnd.val().trim() != "") {
                switch (rangeEnd.attr("typeSectionCreate")) {
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
            var rangeIni = $("input[typeRangeCreate = " + base.Control.TypeRangeIni + "]");
            var rangeEnd = $("input[typeRangeCreate = " + base.Control.TypeRangeEnd + "]");
            var rangeIniValue = null;
            var rangeEndValue = null;
            if (rangeIni.val().trim() != "" && rangeEnd.val().trim() != "") {
                switch (rangeEnd.attr("typeSectionCreate")) {
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

        EnterKeyPress: function (evento)
        {
            var key = getKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
                base.Event.BtnSaveClick();    
            }
            return esValido;
        },
        BtnSaveClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Message.Confirmation({
                    title: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelConfirmationHeader,
                    message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelSaveConfirmation,
                    onAccept: function () {
                        var array = new Array();
                        $.each($("input[nameCreate = txtValueCreate]"), function (index, value) {
                            array.push({ Key: $(value).attr('idSectionCreate'), Value: $(value).val() });
                        });
                        base.Ajax.AjaxSave.data = {
                            CodeParameter: base.Control.ModelCreate.CodeParameter,
                            RecordValueString: array
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
                    if (base.Event.AjaxCreateSuccessCustom != null) {
                        base.Event.AjaxCreateSuccessCustom(data);
                    }
                    base.Control.Container.close();
                    break;

                case "3":
                    base.Control.Message.Warning({
                        message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.DuplicateParameter
                    });
                    break;

                default:
                    base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.FailedSaved });
                    break;
            }
        },
    };
    base.Ajax = {
        AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Actions.RegisterParameterValue,
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
        },
    };
};