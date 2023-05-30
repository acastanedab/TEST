/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: 	EJHF 20140905 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Simulator.Index.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Simulator.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmSimulatorIndex',
                title: Yanbal.SFT.Presentation.Web.Freight.Simulator.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.SimulatorValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(base.Control.ModelIndex)) {
                base.Control.BtnSimulate().click(base.Event.BtnSimulateClick);
                base.Control.FiltersSimulate.TxtAmount().keypress(base.Event.EventAmountKeyPress);
                base.Control.FiltersSimulate.TxtAmount().bind('paste', base.Event.EventAmountPaste);
                base.Control.FiltersSimulate.TxtCountry().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.TxtZone().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.SlcTypeOrder().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.TxtYearCampaign().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.TxtNumberCampaign().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.TxtWeek().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.SlcSendType().keypress(base.Event.EnterKeyPress);
                base.Control.FiltersSimulate.SlcZone1().change(base.Event.ZoneLevel1);
                base.Control.FiltersSimulate.SlcZone2().change(base.Event.ZoneLevel2);
                base.Control.FiltersSimulate.SlcZone3().change(base.Event.ZoneLevel3);
                base.Control.FiltersSimulate.TxtCodeParameter().keypress(base.Event.EventCodeKeyPress);
                base.Control.FiltersSimulate.TxtCodeParameter().bind('paste', base.Event.EventCodePaste);
                base.Control.FiltersSimulate.TxtCodeParameter().blur(base.Event.EventCodeBlur);
                base.Event.ZoneLevel1();
                base.Control.DivSearchResult().fadeIn();
            }
        };

        base.Parameters = {
            SelectedForm: {
                SelectedRegistration: null
            },
            Search: null
        };

        base.Control = {
            ModalCreate: null,
            ModalEdit: null,
            ModelIndex: Yanbal.SFT.Presentation.Web.Freight.Simulator.Models.Index,
            ModalEditParameterCombination: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            CreationForm: null,
            EditionForm: null,
            EditionParameterCombinationForm: null,
            GridResult: null,
            BtnSimulate: function () { return $('#btnSimulate'); },
            LblAmountFreight: function () { return $('#lblAmountFreight'); },
            LblCodeError: function () { return $('#lblCodeError'); },
            LblDescriptionError: function () { return $('#lblDescriptionError'); },
            LblCombinationDescription: function () { return $('#lblCombinationDescription'); },
            DivSearchResult: function () { return $('#divSearchResult'); },
            FiltersSimulate: {
                TxtAmount: function () { return $('#txtAmount'); },
                TxtCountry: function () { return $('#txtCountry'); },
                TxtZone: function () { return $('#txtZone'); },
                SlcZone1: function () { return $('#slcZone1'); },
                SlcZone2: function () { return $('#slcZone2'); },
                SlcZone3: function () { return $('#slcZone3'); },
                SlcTypeOrder: function () { return $('#slcTypeOrder'); },
                TxtYearCampaign: function () { return $('#txtYearCampaign'); },
                TxtNumberCampaign: function () { return $('#txtNumberCampaign'); },
                TxtWeek: function () { return $('#txtWeek'); },
                SlcSendType: function () { return $('#slcSendType'); },
                TxtCodeParameter: function () { return $("input[name = CodeParameter]") }
            }
        };

        base.Event = {
            EventCodePaste: function (event) {
                var esValido = validateCopyOnlyLetters(event);
                return esValido;
            },

            EventCodeBlur: function (event) {
                $.each($(base.Control.FiltersSimulate.TxtCodeParameter()), function (index, value) {
                    $(value).attr('value', $(value).val().toUpperCase());
                });
            },

            EventCodeKeyPress: function (event) {
                var esValido = validateOnlyLetters(event);
                if (esValido) {
                    ConvertShift();
                    var key = getKeyCode(event);
                    esValido = !(event && key == 13);
                    if (esValido == false) {
                        base.Event.BtnSimulateClick();
                    }
                }
                return esValido;
            },

            EventAmountPaste: function (event) {
                var isValido = validateCopyStringOnlyDecimalPoint(event);
                return isValido;
            },

            EventAmountKeyPress: function (event) {
                var esValido = validateOnlyNumbersAndPoint(event);
                if (esValido) {
                    var amount = base.Control.FiltersSimulate.TxtAmount().val();
                    var key = getKeyCode(event);
                    amount += (key == 46) ? "." : key;
                    if (event.charCode == 46) {
                        amount += '0';
                    }
                    esValido = validateStringOnlyDecimalPoint(amount);
                    if (esValido) {
                        var key = getKeyCode(event);
                        esValido = !(event && key == 13);
                        if (esValido == false) {
                            base.Event.BtnSimulateClick();
                        }
                    }
                }
                return esValido;
            },

            EnterKeyPress: function (event) {
                var key = getKeyCode(event);
                var esValido = !(event && key == 13);
                if (esValido == false) {
                    base.Event.BtnSimulateClick();
                }
                return esValido;
            },

            ZoneLevel1: function () {
                base.Ajax.AjaxChangeZoneLevel1.data = {
                    codeZoneLevel1: base.Control.FiltersSimulate.SlcZone1().val(),
                };
                base.Ajax.AjaxChangeZoneLevel1.submit();
            },

            ZoneLevel2: function () {
                base.Ajax.AjaxChangeZoneLevel2.data = {
                    codeZoneLevel1: base.Control.FiltersSimulate.SlcZone1().val(),
                    codeZoneLevel2: base.Control.FiltersSimulate.SlcZone2().val(),
                };
                base.Ajax.AjaxChangeZoneLevel2.submit();
            },

            ZoneLevel3: function () {
                var zoneCode = base.Control.FiltersSimulate.SlcZone3().val();

                if (zoneCode == null || zoneCode.trim() == "") {
                    zoneCode = base.Control.FiltersSimulate.SlcZone2().val();
                }
                base.Control.FiltersSimulate.TxtZone().attr('value', zoneCode);
            },

            BtnSimulateClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.LblAmountFreight().empty();
                    base.Control.LblCodeError().empty();
                    base.Control.LblDescriptionError().empty();
                    base.Control.LblCombinationDescription().empty();

                    var parameters = new Array();
                    $.each($(base.Control.FiltersSimulate.TxtCodeParameter()), function (index, value) {
                        if ($(value).val() != null && $(value).val().trim() != "") {
                            parameters.push({ Id: $(value).val(), Value: '' });
                        }
                    });

                    var iterator = 0;
                    while (parameters.length > iterator) {
                        parameters[iterator] = {
                            Id: parameters[iterator].Id,
                            Value: $('#txtValueParameter' + (iterator + 1)).val()
                        }
                        iterator++;
                    }
                    base.Ajax.AjaxSimulate.data = {
                        AmountString: base.Control.FiltersSimulate.TxtAmount().val(),
                        Country: base.Control.FiltersSimulate.TxtCountry().val(),
                        Zone: base.Control.FiltersSimulate.TxtZone().val(),
                        TypeOrder: base.Control.FiltersSimulate.SlcTypeOrder().val(),
                        YearCampaign: base.Control.FiltersSimulate.TxtYearCampaign().val(),
                        NumberCampaign: base.Control.FiltersSimulate.TxtNumberCampaign().val(),
                        NumberWeek: base.Control.FiltersSimulate.TxtWeek().val(),
                        SendType: base.Control.FiltersSimulate.SlcSendType().val(),
                        CollectorParameter: parameters
                    };
                    base.Ajax.AjaxSimulate.submit();
                }
            },

            AjaxSimulateSuccess: function (data) {            

                base.Control.LblCodeError().empty();
                base.Control.LblCodeError().append(data.CodeError);

                base.Control.LblDescriptionError().empty();
                base.Control.LblDescriptionError().append(data.DescriptionError);

                $("#divTblResultados").html("");

                var html = "";
                html += "<table class=\"table table-hover table-responsive table-bordered\">"
                html += "<thead>"
                html += "<tr>"
                html += "<th>Combinación</th>"
                html += "<th>Tipo de Envío</th>"
                html += "<th>Importe de flete</th>"
                html += "</tr>"
                html += "</thead>"
                html += "<tbody>"
                for (item in data.OrderResponseList) {
                    html += "<tr>"
                    html += "<td>" + data.OrderResponseList[item].combinationDescription + "</td>"
                    html += "<td>" + data.OrderResponseList[item].SendTypeDescripcion + "</td>"
                    html += "<td>" + data.OrderResponseList[item].valueFreight + "</td>"                                        
                    html += "</tr>"
                };
                html += "</tbody>"
                html += "</table>"
                $("#divTblResultados").append(html);
                base.Control.DivSearchResult().fadeIn();
            },

            AjaxChangeZoneLevel1Success: function (data) {
                base.Control.FiltersSimulate.SlcZone2().find('option').remove();
                base.Control.FiltersSimulate.SlcZone2().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Simulator.Resources.LabelSelect));
                base.Control.FiltersSimulate.SlcZone3().find('option').remove();
                base.Control.FiltersSimulate.SlcZone3().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Simulator.Resources.LabelSelect));

                if (base.Control.FiltersSimulate.SlcZone1().val() != null && base.Control.FiltersSimulate.SlcZone1().val() != "") {
                    if (data != null || data != undefined) {
                        $.each(data, function (index, value) {
                            base.Control.FiltersSimulate.SlcZone2().append($("<option />").val(value.Id).text(value.Name));
                        });
                    }
                }
                var zoneCode = base.Control.FiltersSimulate.SlcZone1().val();

                if (zoneCode == null || zoneCode.trim() == "") {
                    zoneCode = base.Control.ModelIndex.CodeCountryGeo;
                }
                base.Control.FiltersSimulate.TxtZone().attr('value', zoneCode);
            },

            AjaxChangeZoneLevel2Success: function (data) {
                base.Control.FiltersSimulate.SlcZone3().find('option').remove();
                base.Control.FiltersSimulate.SlcZone3().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Simulator.Resources.LabelSelect));
                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.FiltersSimulate.SlcZone3().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
                var zoneCode = base.Control.FiltersSimulate.SlcZone2().val();

                if (zoneCode == null || zoneCode.trim() == "") {
                    zoneCode = base.Control.FiltersSimulate.SlcZone1().val();
                }
                base.Control.FiltersSimulate.TxtZone().attr('value', zoneCode);
            }

        };

        base.Ajax = {
            AjaxSimulate: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Simulator.Actions.Simulate,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSimulateSuccess
            }),

            AjaxChangeZoneLevel1: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Simulator.Actions.ChangeZoneLevel1,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeZoneLevel1Success
            }),

            AjaxChangeZoneLevel2: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Simulator.Actions.ChangeZoneLevel2,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeZoneLevel2Success
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
}
catch (ex) {
    alert(ex.message);
}