/// <summary>
/// Script de Controladora de la Vista 
/// </summary>
/// <remarks>
/// Creacion: GMD 20141609 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.AuditReport.Index.Controller');
    Yanbal.SFT.Presentation.Web.Policy.AuditReport.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';

            base.Control.Calendar = new Yanbal.SFT.Web.Components.Calendar({
                inputFrom: base.Control.FiltersSearch.TxtDateFrom(),
                inputTo: base.Control.FiltersSearch.TxtDateTo()
            });

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmAuditReportIndex',
                messages: Yanbal.SFT.Presentation.Web.AuditReportValidation.Message.Resources,
                validationsExtra: base.Function.GetAdditionalValidations()
            });
            base.Control.Message = new Yanbal.SFT.Web.Components.Message();

            base.Control.FiltersSearch.TxtTable().change(base.Event.ColumnAuditChange);

            if (base.Function.AplicarBinding(Yanbal.SFT.Presentation.Web.Policy.AuditReport.Models.Index)) {
                base.Control.BtnVisualize().click(base.Event.BtnVisualizeClick);
                base.Control.BtnCleanForm().click(base.Event.BtnCleanFormClick);

                base.Control.FiltersSearch.TxtDateFrom().keypress(base.Event.TxtDateKeypress);
                base.Control.FiltersSearch.TxtDateTo().keypress(base.Event.TxtDateKeypress);
                base.Control.FiltersSearch.TxtDateFrom().bind('paste', base.Event.TxtDatePaste);
                base.Control.FiltersSearch.TxtDateTo().bind('paste', base.Event.TxtDatePaste);

                base.Control.FiltersSearch.TxtUser().keypress(base.Event.TxtUserKeypress);
            }

            base.Event.ColumnAuditChange();

        };

        base.Parametros = {

        };

        base.Control = {
            Validator: null,
            FormFilterSearch: function () { return $('#frmAuditReportIndex'); },
            Message: null,
            BtnVisualize: function () { return $('#btnVisualize'); },
            BtnCleanForm: function () { return $('#btnClean'); },
            FiltersSearch: {
                TxtTable: function () { return $('#slcTable'); },
                TxtAttribute: function () { return $('#slcAttribute'); },
                TxtDateFrom: function () { return $('#calDateFrom'); },
                TxtDateTo: function () { return $('#calDateTo'); },
                TxtUser: function () { return $('#txtUserTransaction'); },
                HdnTable: function () { return $('#hdnTable'); },
                HdnAttribute: function () { return $('#hdnAttribute'); }
            }
        };

        base.Event = {
            ColumnAuditChange: function (event) {
                base.Ajax.AjaxChangeAuditTable.data = {
                    TableCode: base.Control.FiltersSearch.TxtTable().val(),
                };
                base.Ajax.AjaxChangeAuditTable.submit();
            },

            TxtDatePaste: function (e) {
                return validateCopyDate(e);
            },

            TxtDateKeypress: function (event) {
                var key = getKeyCode(event);
                if (key == 13) {
                    base.Event.BtnVisualizeClick();
                }
            },

            TxtUserKeypress: function (event) {
                var key = getKeyCode(event);
                var isValid = !(event && key == 13);
                if (isValid) {

                } else {
                    base.Event.BtnVisualizeClick();
                }
                return isValid;
            },

            BtnCleanFormClick: function () {
                base.Control.FiltersSearch.TxtDateFrom().datepicker('option', 'maxDate', null);
                base.Control.FiltersSearch.TxtDateTo().datepicker('option', 'minDate', null);
                base.Control.FiltersSearch.TxtDateFrom().val('')
                base.Control.FiltersSearch.TxtDateTo().val('')

                base.Control.FiltersSearch.TxtTable().val('');
                base.Control.FiltersSearch.TxtAttribute().find('option').remove();
                base.Control.FiltersSearch.TxtUser().val('');
                base.Control.FiltersSearch.TxtDateFrom().val('');
                base.Control.FiltersSearch.TxtDateTo().val('');

                base.Event.ColumnAuditChange();
            },

            AjaxChangeAuditTableSuccess: function (data) {
                base.Control.FiltersSearch.TxtAttribute().find('option').remove();
                base.Control.FiltersSearch.TxtAttribute().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.AuditReport.Resources.LabelSelectAll));

                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.FiltersSearch.TxtAttribute().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
            },

            BtnVisualizeClick: function () {
                if (base.Control.Validator.isValid()) {
                    if (base.Control.FiltersSearch.TxtTable().val() == '') {
                        base.Control.FiltersSearch.HdnTable().val('');
                    } else {
                        base.Control.FiltersSearch.HdnTable().val($("#slcTable option:selected").text());
                    }
                    if (base.Control.FiltersSearch.TxtAttribute().val() == '') {
                        base.Control.FiltersSearch.HdnAttribute().val('');
                    } else {
                        base.Control.FiltersSearch.HdnAttribute().val($("#slcAttribute option:selected").text());
                    }

                    if (Yanbal.SFT.Presentation.Web.Global.Report.BusinessUnitConfiguration == Yanbal.SFT.Presentation.Web.Enumerated.ReportDisplayForm.Window) {
                        var windowName = 'popupReport';
                        window.open(null, windowName, Yanbal.SFT.Presentation.Web.Global.Policy.Reports.PresentationFormat.Horizontal);
                        base.Control.FormFilterSearch().attr('target', windowName);
                        base.Control.FormFilterSearch().attr('action', Yanbal.SFT.Presentation.Web.General.ReportViewer.Actions.AuditPolicy);
                    }
                    else if (Yanbal.SFT.Presentation.Web.Global.Report.BusinessUnitConfiguration == Yanbal.SFT.Presentation.Web.Enumerated.ReportDisplayForm.Tab) {
                        base.Control.FormFilterSearch().attr('action', Yanbal.SFT.Presentation.Web.General.ReportViewer.Actions.AuditPolicy);
                        base.Control.FormFilterSearch().attr('target', '_blank');
                    }
                    else {
                        base.Control.FormFilterSearch().removeAttr('action')
                        base.Control.FormFilterSearch().removeAttr('target')
                    }
                    base.Control.FormFilterSearch().submit();
                }
            }
        };

        base.Ajax = {
            AjaxChangeAuditTable: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.Formula.Actions.ChangeAuditTable,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeAuditTableSuccess
            })

        };

        base.Function = {
            AplicarBinding: function (model, container) {
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

            GetAdditionalValidations: function () {
                var AdditionalValidations = new Array();
                AdditionalValidations.push({
                    Event: function () {
                        return validateDateRange(base.Control.FiltersSearch.TxtDateFrom(), base.Control.FiltersSearch.TxtDateTo());
                    },
                    codeMessage: 'CorrectDateRange'
                });

                AdditionalValidations.push({
                    Event: function () {
                        var isValid = true;

                        if (base.Control.FiltersSearch.TxtDateTo().val() != '') {
                            isValid = (base.Control.FiltersSearch.TxtDateFrom().val() != '')
                        }
                        return isValid;
                    },
                    codeMessage: 'IncorrectDateRange'
                });

                AdditionalValidations.push({
                    Event: function () {
                        var result = true;

                        result = !(base.Control.FiltersSearch.TxtTable().val() == '' &&
                                        base.Control.FiltersSearch.TxtAttribute().val() == '' &&
                                        base.Control.FiltersSearch.TxtUser().val().trim() == '' &&
                                        base.Control.FiltersSearch.TxtDateFrom().val() == '');

                        if (!result) {
                            result = (base.Control.FiltersSearch.TxtDateTo().val() != '');
                        }

                        return result;
                    },
                    codeMessage: 'SelectFilter'
                });

                return AdditionalValidations;
            }
        };
    };
} catch (ex) {
    alert(ex.message);
}