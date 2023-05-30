/// <summary>
///  Script de controladora para la vista de Impuesto por tipo de producto
/// </summary>
/// <remarks>
/// Creacion: 	PBG 26082014 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Index.Controller');
    Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';
            base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true,
                title: ''
            });
            base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true,
                title: ''
            });
            if (base.Function.ApplyBinding(base.Control.ModelTaxProduct)) {
                base.Control.BtnSearch().click(base.Event.BtnSearchClick);
                base.Control.FiltersSearch.TxtCodigo().keypress(base.Event.EventEnterKeyPress);
                base.Control.FiltersSearch.SlcTaxType().keypress(base.Event.EventEnterKeyPress);
                base.Control.FiltersSearch.SlcOrigin().keypress(base.Event.EventEnterKeyPress);
                base.Control.FiltersSearch.SlcException().keypress(base.Event.EventEnterKeyPress);
                base.Control.FiltersSearch.SlcRegistrationStatus().keypress(base.Event.EventEnterKeyPress);
                base.Control.BtnCreate().click(base.Event.BtnCreateClick);
                base.Function.CreateGrid(base.Control.ModelTaxProduct);
                base.Control.DivSearchResult().fadeIn();
            };
            if (base.Control.modelTaxProduct != null) {
                if (base.Control.ModelTaxProduct.TaxCode != null) { base.Control.FiltersSearch.TaxCode().attr('value', base.Control.ModelTaxProduct.TaxCode); }
                if (base.Control.ModelTaxProduct.SlcTaxType != null) { base.Control.FiltersSearch.SlcTaxType().attr('value', base.Control.ModelTaxProduct.SlcTaxType); }
                if (base.Control.ModelTaxProduct.SlcOrigin != null) { base.Control.FiltersSearch.SlcOrigin().attr('value', base.Control.ModelTaxProduct.SlcOrigin); }
                if (base.Control.ModelTaxProduct.SlcException != null) { base.Control.FiltersSearch.SlcException().attr('value', base.Control.ModelTaxProduct.SlcException); }
                if (base.Control.ModelTaxProduct.SlcRegistrationStatus != null) { base.Control.FiltersSearch.SlcRegistrationStatus().attr('value', base.Control.ModelTaxProduct.SlcRegistrationStatus); }
            };
            base.Event.BtnSearchClick();
        };

        base.TaxProduct = {
            SelectedForm: {
                SelectedRegistration: null
            },
            Search: null
        };

        base.Control = {
            ModalCreate: null,
            ModalEdit: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            CreationForm: null,
            EditForm: null,
            GridResult: null,
            ModelTaxProduct: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Models.Index,
            FormFiltersSearch: function () { return $('#frmTaxProductIndex'); },
            DivSearchResult: function () { return $('#divSearchResultParameter'); },
            BtnSearch: function () { return $('#btnSearch'); },
            BtnCreate: function () { return $('#btnCreate'); },
            //BtnImport: function () { return $('#btnImport'); },
            //BtnExport: function () { return $('#btnExport'); },

            FiltersSearch: {

                TxtCodigo: function () { return $('#txtCodeProduct'); },
                SlcOrigin: function () { return $('#slcOrigin'); },
                SlcTaxType: function () { return $('#slcTaxType'); },
                SlcException: function () { return $('#slcException'); },
                SlcRegistrationStatus: function () { return $('#slcRegistrationStatus'); },
                
            }
        };

        base.Event = {
            EventEnterKeyPress: function (event) {
                var key = getKeyCode(event);
                var isValid = !(event && key == 13);
                if (isValid == false) {
                    base.Event.BtnSearchClick();
                }
                return isValid;
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
                                codeProduct: selectedRegistration.codeProduct
                            },
                            action: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },

            BtnSearchClick: function () {
                base.TaxProduct.Search = {
                    CodeProduct: base.Control.FiltersSearch.TxtCodigo().val(),
                    TaxCode: base.Control.FiltersSearch.SlcTaxType().val(),
                    Origin: base.Control.FiltersSearch.SlcOrigin().val(),
                    Exception: base.Control.FiltersSearch.SlcException().val(),
                    RegistrationStatus: base.Control.FiltersSearch.SlcRegistrationStatus().val()
                };
                base.Function.ExecuteQuery();
            },

            ModalCreateSuccess: function (data) {
                base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Create.Controller();
                base.Control.CreationForm.Ini({
                    Container: base.Control.ModalCreate,
                    AjaxCreateSuccessCustom: base.Event.DialogAjaxCreateSuccess
                });
            },

            ModalEditSuccess: function (data) {
                base.Control.EditForm = new Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Edit.Controller();
                base.Control.EditForm.Ini({
                    Container: base.Control.ModalEdit,
                    AjaxEditSuccessCustom: base.Event.DialogAjaxEditSuccess
                });
            },

            DialogAjaxEditSuccess: function (data) {
                base.Event.BtnSearchClick();
            },

            DialogAjaxCreateSuccess: function (data) {
                base.Event.BtnSearchClick();
            },

            BtnCreateClick: function () {
                base.Control.ModalCreate.getAjaxContent({
                    action: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Actions.Create,
                    onSuccess: base.Event.ModalCreateSuccess
                });
            }
        };
        base.Ajax = {
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
                    base.Control.Message.Warning({ message: Yanbal.SFT.Web.Shared.Resources.ErrorCargarViewModel });
                }
                return isValid;
            },

            ExecuteQuery: function () {
                base.Function.CreateGrid(Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Models.Index);
                base.Control.GridResult.load();
            },

            CreateGrid: function (model) {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'CodeTaxProduct', width: 40, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                        return string;
                    }
                });
                columns.push({ id: 'Code', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridCode, field: 'Code', width: 160 });
                columns.push({ id: 'Origin', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridOrigin, field: 'OriginDescription', width: 160 });
                columns.push({ id: 'DescriptionTax', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridTax, field: 'DescriptionTax', width: 160, cssClass: 'center' });
                columns.push({ id: 'TaxValue', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridTaxPercentage, field: 'TaxValue', width: 160, cssClass: 'center' });
                columns.push({ id: 'ReferenceValue', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridReferencePrice, field: 'ReferenceValue', width: 160, cssClass: 'center' });
                columns.push({
                    id: 'Exception', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridException, field: 'Exception', width: 160, cssClass: 'center',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var output = value;
                        output = '<input type="checkbox" ' + (value ? 'checked' : '') + ' disabled="disabled" />'
                        return output;
                    }
                });
                columns.push({ id: 'Status', name: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 160, cssClass: 'center' });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResultTaxProduct',
                    isPager: true,
                    isServerPaging: true,
                    proxy: {
                        action: Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Actions.Search,
                        data: base.TaxProduct.Search
                    },
                    columns: columns,
                    forceFitColumns: true,
                    width: '100%'
                });
                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        };
    };
}
catch (ex) {
    alert(ex.message);
}