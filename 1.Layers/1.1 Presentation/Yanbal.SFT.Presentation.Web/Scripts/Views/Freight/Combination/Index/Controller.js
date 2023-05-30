/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: GMD 20140905 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Combination.Index.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Combination.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';
            base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 550,
                modal: true
            });

            base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 550,
                modal: true
            });

            base.Control.ModalEditParameterCombination = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 550,
                modal: true
            });

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmCombinationIndex',
                messages: Yanbal.SFT.Presentation.Web.CombinationValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(base.Control.ModelIndex)) {
                base.Control.BtnVisualize().click(base.Event.BtnVisualizeClick);
                base.Control.BtnSearch().click(base.Event.BtnSearchClick);
                base.Control.BtnCreate().click(base.Event.BtnCreateClick);
                base.Function.GenerateGrid();
                base.Control.DivSearchResult().fadeIn();
                base.Control.FiltersSearch.SlcSearchParameter().change(base.Event.ChangeParameter);                
                base.Event.ChangeParameter();
                if (base.Control.ModelIndex.ListParameter == null || base.Control.ModelIndex.ListParameter.length == 0) {
                    base.Control.BtnCreate().attr('disabled', 'disabled');
                }
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
            ModalCreate: null,
            ModalEdit: null,
            ModelIndex: Yanbal.SFT.Presentation.Web.Freight.Combination.Models.Index,
            ModalEditParameterCombination: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            CreationForm: null,
            EditionForm: null,
            EditionParameterCombinationForm: null,
            GridResult: null,
            BtnVisualize: function () { return $('#btnVisualize'); },
            FormFilterSearch: function () { return $('#frmCombinationIndex'); },
            DivSearchResult: function () { return $('#divSearchResult'); },
            BtnSearch: function () { return $('#btnSearch'); },
            BtnCreate: function () { return $('#btnCreate'); },
            FiltersSearch: {
                SlcSearchParameter: function () { return $('#slcSearchParameter'); },
                HdnParameterCode: function () { return $('#hdnParameterCode'); },
                SlcSearchParameterValue: function () { return $('#slcSearchParameterValue'); },
                HdnParameterValue: function () { return $('#hdnParameterValue'); },
                TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); },
                HdnRegistrationStatus: function () { return $('#hdnRegistrationStatus'); }
            }
        };

        base.Event = {
            ChangeParameter: function () {
                var codeParameter = base.Control.FiltersSearch.SlcSearchParameter().val();
                if (codeParameter != null && codeParameter != "") {
                    base.Ajax.AjaxChangeParameter.data = {
                        codeParameter: codeParameter
                    };
                    base.Ajax.AjaxChangeParameter.submit();
                }
                else {
                    base.Event.AjaxChangeParameterSuccess(null);
                }
            },

            BtnCreateClick: function () {
                base.Control.ModalCreate.getAjaxContent({
                    action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.Create,
                    onSuccess: base.Event.ModalCreateSuccess
                });
            },

            BtnSearchClick: function () {
                var parameter = new Array();
                parameter.push({ Key: ((base.Control.FiltersSearch.SlcSearchParameter().val() == null || base.Control.FiltersSearch.SlcSearchParameter().val() == "") ? null : base.Control.FiltersSearch.SlcSearchParameter().val()), 
                                 Value: ((base.Control.FiltersSearch.SlcSearchParameterValue().val() == null || base.Control.FiltersSearch.SlcSearchParameterValue().val() == "") ? null : base.Control.FiltersSearch.SlcSearchParameterValue().val())});
                
                base.Parameters.Search = {
                    Parameter: parameter,
                    RegistrationStatus: base.Control.FiltersSearch.TxtRegistrationStatus().val()
                };
                base.Function.ExecuteQuery();
            },

            BtnVisualizeClick: function () {
                if (base.Control.Validator.isValid()) {
                    if (base.Control.FiltersSearch.SlcSearchParameter().val() == '') {
                        base.Control.FiltersSearch.HdnParameterCode().val('');
                    } else {
                        base.Control.FiltersSearch.HdnParameterCode().val($("#slcSearchParameter option:selected").text());
                    }
                    if (base.Control.FiltersSearch.SlcSearchParameterValue().val() == '') {
                        base.Control.FiltersSearch.HdnParameterValue().val('');
                    } else {
                        base.Control.FiltersSearch.HdnParameterValue().val($("#slcSearchParameterValue option:selected").text());
                    }
                    if (base.Control.FiltersSearch.TxtRegistrationStatus().val() == '') {
                        base.Control.FiltersSearch.HdnRegistrationStatus().val('');
                    } else {
                        base.Control.FiltersSearch.HdnRegistrationStatus().val($("#slcSearchRegistrationStatus option:selected").text());
                    }                    

                    if (Yanbal.SFT.Presentation.Web.Global.Report.BusinessUnitConfiguration == Yanbal.SFT.Presentation.Web.Enumerated.ReportDisplayForm.Window) {
                        var windowName = 'popupReport';
                        window.open(null, windowName, Yanbal.SFT.Presentation.Web.Global.Policy.Reports.PresentationFormat.Horizontal);
                        base.Control.FormFilterSearch().attr('target', windowName);
                        base.Control.FormFilterSearch().attr('action', Yanbal.SFT.Presentation.Web.General.ReportViewer.Actions.Combination);
                    }
                    else if (Yanbal.SFT.Presentation.Web.Global.Report.BusinessUnitConfiguration == Yanbal.SFT.Presentation.Web.Enumerated.ReportDisplayForm.Tab) {
                        base.Control.FormFilterSearch().attr('action', Yanbal.SFT.Presentation.Web.General.ReportViewer.Actions.Combination);
                        base.Control.FormFilterSearch().attr('target', '_blank');
                    }
                    else {
                        base.Control.FormFilterSearch().removeAttr('action')
                        base.Control.FormFilterSearch().removeAttr('target')
                    }
                    base.Control.FormFilterSearch().submit();
                }
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
                                codeCombination: selectedRegistration.CombinationCode
                            },
                            action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                else if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Action.ModifyParameterCombination.id)) {
                    var columns = base.Control.GridResult.getView().getColumns();
                    var selectedColumn = columns[args.cell];
                    var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                    if (selectedColumn.id == "Parameter") {
                        base.Control.ModalEditParameterCombination.getAjaxContent({
                            data: {
                                codeCombination: selectedRegistration.CombinationCode
                            },
                            action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.EditParameterCombination,
                            onSuccess: base.Event.ModalEditParameterCombinationOpen
                        });
                    }
                }
                e.stopImmediatePropagation();
            },

            ModalCreateSuccess: function (data) {
                base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Freight.Combination.Create.Controller();
                base.Control.CreationForm.Ini({
                    Container: base.Control.ModalCreate,
                    AjaxCreateSuccessCustom: base.Event.DialogAjaxCreateSuccess
                });
            },

            ModalEditSuccess: function (data) {
                base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Freight.Combination.Edit.Controller();
                base.Control.EditionForm.Ini({
                    Container: base.Control.ModalEdit,
                    AjaxEditSuccessCustom: base.Event.DialogAjaxEditSuccess
                });
            },

            ModalEditParameterCombinationOpen: function (data) {
                base.Control.EditionParameterCombinationForm = new Yanbal.SFT.Presentation.Web.Freight.Combination.EditParameterCombination.Controller();
                base.Control.EditionParameterCombinationForm.Ini({
                    Container: base.Control.ModalEditParameterCombination,
                    AjaxEditParameterCombinationSuccessCustom: base.Event.DialogAjaxEditSuccess
                });
            },

            DialogAjaxCreateSuccess: function (data) {
                base.Event.BtnSearchClick();
            },

            DialogAjaxEditSuccess: function (data) {
                base.Event.BtnSearchClick();
            },

            AjaxChangeParameterSuccess: function (data) {
                base.Control.FiltersSearch.SlcSearchParameterValue().find('option').remove();
                base.Control.FiltersSearch.SlcSearchParameterValue().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelSelectAll));
                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.FiltersSearch.SlcSearchParameterValue().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
            }
        };

        base.Ajax = {
            AjaxChangeParameter: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.ChangeParameterValue,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeParameterSuccess
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
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Freight.Combination.Models.Index);
                base.Control.GridResult.load();
            },

            GenerateGrid: function (model) {                
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'CombinationCode', width: 10, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                        return string;
                    }
                });                

                columns.push({
                    id: 'Parameter', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridParameters, field: 'CombinationCode', width: 40, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        if (dataContext.RegistrationStatus == Yanbal.SIP.Enumerados.RegistrationStatus.Active) {
                            string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.ModifyParameterCombination, model.Parameter);
                        }
                        return string;
                    }
                });

                columns.push({
                    id: 'CombinationCode', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridCode, field: 'CombinationCode', width: 40, cssClass: 'center u-actions'
                });
                columns.push({ id: 'Combination', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridCombination, field: 'Description', width: 200 });
                columns.push({ id: 'AmountFreight', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridAmount, field: 'AmountFreightString', width: 50, cssClass: 'right' });
                columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 50, cssClass: 'center' });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResult',
                    isPager: true,
                    isServerPaging: true,
                    proxy: {
                        action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.Search,
                        data: base.Parameters.Search
                    },
                    columns: columns,
                    forceFitColumns: true,
                    width: '100%',
                });
                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        };
    };
}
catch (ex) {
    alert(ex.message);
}