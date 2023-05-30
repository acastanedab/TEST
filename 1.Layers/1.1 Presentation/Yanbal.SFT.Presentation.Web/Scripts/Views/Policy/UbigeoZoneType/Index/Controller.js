/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: GMD 20140827 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Index.Controller');
    Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';
            base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true
            });

            base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true
            });

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmUbigeoZoneTypeIndex',
                messages: Yanbal.SFT.Presentation.Web.UbigeoZoneTypeValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Models.Index)) {
                base.Control.BtnVisualize().click(base.Event.BtnVisualizeClick);
                base.Control.BtnSearch().click(base.Event.BtnSearchClick);
                base.Control.BtnCreate().click(base.Event.BtnCreateClick);
                base.Control.FiltersSearch.TxtGeoLevel1().change(base.Event.ChangeZoneLevel1);
                base.Control.FiltersSearch.TxtGeoLevel2().change(base.Event.ChangeZoneLevel2);
                base.Event.ChangeZoneLevel1();
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Models.Index);
                base.Control.DivSearchResult().fadeIn();
            };
            base.Event.BtnSearchClick();
        };

        base.Parameters = {
            SelectedForm: {
                SelectedRegistration: null
            },
            Search: null
        };

        base.Control = {
            Validator: null,
            ModalCreate: null,
            ModalEdit: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            CreationForm: null,
            EditionForm: null,
            GridResult: null,
            BtnVisualize: function () { return $('#btnVisualize'); },
            FormFiltersSearch: function () { return $('#frmUbigeoZoneTypeIndex'); },
            DivSearchResult: function () { return $('#divSearchResult'); },            
            BtnSearch: function () { return $('#btnSearch'); },
            BtnCreate: function () { return $('#btnCreate'); },
            FiltersSearch: {
                TxtGeoLevel1:           function () { return $('#slcGeoLevel1'); },
                TxtGeoLevel2:           function () { return $('#slcGeoLevel2'); },
                TxtGeoLevel3:           function () { return $('#slcGeoLevel3'); },
                HdnGeoLevel1:               function () { return $('#hdnGeoLevel1'); },
                HdnGeoLevel2:               function () { return $('#hdnGeoLevel2'); },
                HdnGeoLevel3:               function () { return $('#hdnGeoLevel3'); },
                TxtZoneType: function () { return $('#slcZoneType'); },
                HdnZoneType: function () { return $('#hdnZoneType'); },
                TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); },
                HdnRegistrationStatus: function () { return $('#hdnRegistrationStatus'); }
            }
        };

        base.Event = {
            ChangeZoneLevel1: function () {
                base.Ajax.AjaxChangeZoneLevel1.data = {
                    codeZoneLevel1: base.Control.FiltersSearch.TxtGeoLevel1().val()
                };
                base.Ajax.AjaxChangeZoneLevel1.submit();
            },

            ChangeZoneLevel2: function () {
                base.Ajax.AjaxChangeZoneLevel2.data = {
                    codeZoneLevel1: base.Control.FiltersSearch.TxtGeoLevel1().val(),
                    codeZoneLevel2: base.Control.FiltersSearch.TxtGeoLevel2().val()
                };
                base.Ajax.AjaxChangeZoneLevel2.submit();
            },

            BtnCreateClick: function () {
                base.Control.ModalCreate.getAjaxContent({
                    action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.Create,
                    onSuccess: base.Event.ModalCreateSuccess
                });
            },

            BtnSearchClick: function () {
                base.Parameters.Search = {
                    CodeLevel1:         base.Control.FiltersSearch.TxtGeoLevel1().val(),
                    CodeLevel2:         base.Control.FiltersSearch.TxtGeoLevel2().val(),
                    CodeLevel3:         base.Control.FiltersSearch.TxtGeoLevel3().val(),
                    CodeTypeZone:       base.Control.FiltersSearch.TxtZoneType().val(),
                    RegistrationStatus: base.Control.FiltersSearch.TxtRegistrationStatus().val()
                };
                base.Function.ExecuteQuery();
            },

            BtnEditClick: function (e, args) {
                var button = $(e.target);
                if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.Edit.id)) {
                    var columns = base.Control.GridResult.getView().getColumns();
                    var selectedColumn = columns[args.cell];
                    var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                    if (selectedColumn.id == "Edit") {
                        base.Control.ModalEdit.getAjaxContent({
                            data: {
                                codeTypeZoneUbigeo: selectedRegistration.CodeTypeZoneUbigeo
                            },
                            action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },
            
            BtnVisualizeClick: function () {
                if (base.Control.Validator.isValid()) {
                    if (base.Control.FiltersSearch.TxtGeoLevel1().val() == '') {
                        base.Control.FiltersSearch.HdnGeoLevel1().val('');
                    } else {
                        base.Control.FiltersSearch.HdnGeoLevel1().val($("#slcGeoLevel1 option:selected").text());
                    }
                    if (base.Control.FiltersSearch.TxtGeoLevel2().val() == '') {
                        base.Control.FiltersSearch.HdnGeoLevel2().val('');
                    } else {
                        base.Control.FiltersSearch.HdnGeoLevel2().val($("#slcGeoLevel2 option:selected").text());
                    }
                    if (base.Control.FiltersSearch.TxtGeoLevel3().val() == '') {
                        base.Control.FiltersSearch.HdnGeoLevel3().val('');
                    } else {
                        base.Control.FiltersSearch.HdnGeoLevel3().val($("#slcGeoLevel3 option:selected").text());
                    }
                    if (base.Control.FiltersSearch.TxtZoneType().val() == '') {
                        base.Control.FiltersSearch.HdnZoneType().val('');
                    } else {
                        base.Control.FiltersSearch.HdnZoneType().val($("#slcZoneType option:selected").text());
                    }
                    if (base.Control.FiltersSearch.TxtRegistrationStatus().val() == '') {
                        base.Control.FiltersSearch.HdnRegistrationStatus().val('');
                    } else {
                        base.Control.FiltersSearch.HdnRegistrationStatus().val($("#slcSearchRegistrationStatus option:selected").text());
                    }

                    if (Yanbal.SFT.Presentation.Web.Global.Report.BusinessUnitConfiguration == Yanbal.SFT.Presentation.Web.Enumerated.ReportDisplayForm.Window) {
                        var windowName = 'popupReport';
                        window.open(null, windowName, Yanbal.SFT.Presentation.Web.Global.Policy.Reports.PresentationFormat.Horizontal);
                        base.Control.FormFiltersSearch().attr('target', windowName);
                        base.Control.FormFiltersSearch().attr('action', Yanbal.SFT.Presentation.Web.General.ReportViewer.Actions.AllocationAreas);
                    }
                    else if (Yanbal.SFT.Presentation.Web.Global.Report.BusinessUnitConfiguration == Yanbal.SFT.Presentation.Web.Enumerated.ReportDisplayForm.Tab) {
                        base.Control.FormFiltersSearch().attr('action', Yanbal.SFT.Presentation.Web.General.ReportViewer.Actions.AllocationAreas);
                        base.Control.FormFiltersSearch().attr('target', '_blank');
                    }
                    else {
                        base.Control.FormFiltersSearch().removeAttr('action')
                        base.Control.FormFiltersSearch().removeAttr('target')
                    }
                    base.Control.FormFiltersSearch().submit();
                }
            },

            ModalCreateSuccess: function (data) {
                base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Create.Controller();
                base.Control.CreationForm.Ini({
                    Container: base.Control.ModalCreate,
                    AjaxCreateSuccessCustom: base.Event.DialogAjaxCreateSuccess
                });
            },

            ModalEditSuccess: function (data) {
                base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Edit.Controller();
                base.Control.EditionForm.Ini({
                    Container: base.Control.ModalEdit,
                    AjaxEditSuccessCustom: base.Event.DialogAjaxEditSuccess
                });
            },
            DialogAjaxCreateSuccess: function (data) {
                base.Event.BtnSearchClick();
            },
            DialogAjaxEditSuccess: function (data) {
                base.Event.BtnSearchClick();
            },

            AjaxChangeZoneLevel1Success: function (data) {
                base.Control.FiltersSearch.TxtGeoLevel2().find('option').remove();
                base.Control.FiltersSearch.TxtGeoLevel2().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSelectAll));
                base.Control.FiltersSearch.TxtGeoLevel3().find('option').remove();
                base.Control.FiltersSearch.TxtGeoLevel3().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSelectAll));

                if (base.Control.FiltersSearch.TxtGeoLevel1().val() != null && base.Control.FiltersSearch.TxtGeoLevel1().val() != "") {
                    if (data != null || data != undefined) {
                        $.each(data, function (index, value) {
                            base.Control.FiltersSearch.TxtGeoLevel2().append($("<option />").val(value.Id).text(value.Name));
                        });
                    }
                }                
            },

            AjaxChangeZoneLevel2Success: function (data) {
                base.Control.FiltersSearch.TxtGeoLevel3().find('option').remove();
                base.Control.FiltersSearch.TxtGeoLevel3().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSelectAll));
                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.FiltersSearch.TxtGeoLevel3().append($("<option />").val(value.Id).text(value.Name));
                    });
                }                               
            }
        };

        base.Ajax = {
            AjaxChangeZoneLevel1: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.ChangeZoneLevel1,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeZoneLevel1Success
            }),

            AjaxChangeZoneLevel2: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.ChangeZoneLevel2,
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

            ExecuteQuery: function () {
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Models.Index);
                base.Control.GridResult.load();
            },

            GenerateGrid: function (model) {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'CodeTypeZoneUbigeo', width: 60, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                        return string;
                    }
                });

                columns.push({ id: 'Country', name: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelGridCountry, field: 'DescriptionCountry', width: 120 });
                columns.push({ id: 'Nivel1', name: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelGridLevel1, field: 'Level1', width: 120, cssClass: 'center' });
                columns.push({ id: 'Nivel2', name: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelGridLevel2, field: 'Level2', width: 120, cssClass: 'center' });
                columns.push({ id: 'Nivel3', name: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelGridLevel3, field: 'Level3', width: 120, cssClass: 'center' });
                columns.push({ id: 'TypeZone', name: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelGridZoneType, field: 'CodeTypeZone', width: 80, cssClass: 'center' });
                columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center' });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResult',
                    isPager: true,
                    isServerPaging: true,
                    proxy: {
                        action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.Search,
                        data: base.Parameters.Search
                    },
                    columns: columns,
                    forceFitColumns: true,
                    width: '100%',
                });
                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        }
    };
}
catch (ex) {
    alert(ex.message);
}