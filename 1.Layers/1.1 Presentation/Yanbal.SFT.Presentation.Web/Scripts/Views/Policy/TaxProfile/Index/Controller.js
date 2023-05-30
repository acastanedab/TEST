ns('Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Index');
Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        'use strict';       
        base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 550,
            width: 450,
            modal: true
        });
        base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 550,
            width: 450,
            modal: true
        });
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmSearchTaxProfile',
            messages: Yanbal.SFT.Presentation.Web.TaxProfileValidation.Message.Resources
        });
        if (base.Function.ApplyBinding(base.Control.modelTaxProfile)){
            base.Control.BtnCreate().click(base.Event.BtnCreateClick);
            base.Control.BtnSearch().click(base.Event.BtnSearchClick);
            base.Function.CreateGrid(base.Control.modelTaxProfile);
            base.Control.DivSearchResult().fadeIn();
        };
        if (base.Control.modelTaxProfile != null) {
            if (base.Control.modelTaxProfile.DirectorCode != null) {
                base.Control.FilterSearch.TxtDirectorCode().attr('value', base.Control.modelTaxProfile.DirectorCode);
            }
            if (base.Control.modelTaxProfile.DirectorName != null) {
                base.Control.FilterSearch.TxtDirectorName().attr('value', base.Control.modelTaxProfile.DirectorName);
            }
            if (base.Control.modelTaxProfile.TaxRegime != null) {
                base.Control.FilterSearch.TxtTaxRegimen().attr('value', base.Control.modelTaxProfile.TaxRegime);
            }
            if (base.Control.modelTaxProfile.ListRegistrationStatus != null) {
                base.Control.FilterSearch.TxtRegistrationstatus().attr('value', base.Control.modelTaxProfile.ListRegistrationStatus)
            }
        }
    }

    base.Parameters = {
        FormularioSeleccion: {
            SelectedRegistration: null
        },
        Search: null
    };

    base.Control = {
        ModalCreate: null,
        ModalEdit: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        CreatingForm: null,
        GridResult: null,
        modelTaxProfile: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Model.Index,
        FormFiltersSearch: function () {
            return $('#frmSearchTaxProfile');
        },
        BtnVisualize: function () {
            return $('#btnVisualize');
        },
        DivSearchResult: function () {
            return $('#divSearchTaxProfile');
        },
        BtnSearch: function () {
            return $('#btnSearchTaxProfile');
        },
        BtnCreate: function () {
            return $('#btnCreateTaxProfile');
        },
        FilterSearch: {
            TxtDirectorCode: function () {
                return $('#txtSearchCodeDirector');
            },
            TxtDirectorName: function () {
                return $('#txtSearchName');
            },
            TxtTaxRegimen: function () {
                return $('#slcSearchTaxRegimen');
            },
            TxtRegistrationstatus: function () {
                return $('#slcSearchRegisterStatus');
            }
        }
    };

    base.Event = {
        EventEnterKeyPress: function (e, args) {
            var button = $(e.target);
            if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.Edit.Id)) {
                var columns = base.Control.GridResult.getView().getColumns();
                var selectedColumn = columns[args.cell];
                var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                if (selectedColumn.id == "Edit") {
                    base.Control.ModalEdit.getAjaxContent({
                        data: {
                            codeTaxProfile: selectedRegistration.CodeTaxProfile
                        },
                        action: Yanbal.SFT.Presentation.Web.Policy.Parameters.Action.Edit,
                        onSuccess: base.Event.ModalEditSuccess
                    });
                }
            }
            e.stopImmediatePropagation();
        },
        BtnSearchClick: function () {
            base.Parameters.Search = {
                DirectorCode: base.Control.FilterSearch.TxtDirectorCode().val(),
                DirectorName: base.Control.FilterSearch.TxtDirectorName().val(),
                TaxRegime: base.Control.FilterSearch.TxtTaxRegimen().val(),
                RegistrationStatus: base.Control.FilterSearch.TxtRegistrationstatus().val()
            };
            base.Function.ExecuteQuery();
        },
        ModalCreateSuccess: function (data) {
            base.Control.CreatingForm = new Yanbal.SFT.Presentation.Web.Policy.Edit.Controller();
            base.Control.EditForm.Ini({
                Container: base.Control.ModalEdit,
                AjaxEditSuccessCustom: base.Event.DialogAjaxEditSucess
            });
        },
        DialogAjaxEditSucess: function (data) {
            base.Event.BtnSearchClick();
        },
        BtnCreateClick: function () {
            base.Control.ModalCreate.getAjaxContent({
                action: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Actions.Create,
                onSuccess: base.Event.ModalCreateSuccess                
            });
        }
    };
    base.Ajax = {
    };

    base.Function = {
        ValidatorRegister: function(){
            var isValid = true;
            var txtDirectorCode = base.Control.FilterSearch.TxtDirectorCode().val();
            if (txtDirectorCode =="") {
                isValid= false,
                base.Control.Message.Warning({ message: Yanbal.SFT.Web.Validacion.Mensaje.Resources.EtiquetaDebeIngresar });
            }
            return isValid;
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
                base.Control.Message.Warning({ message: Yanbal.SFT.Web.Shared.Resource.ErrorCargarViewModel });
            }
            return isValid;
        },
        ExecuteQuery: function () {
            base.Function.CreateGrid(base.Control.modelTaxProfile);
            base.Control.GridResult.load();
        },
        CreateGrid: function (model) {
            if (base.Control.GridResult != null) {
                base.Control.GridResult.destroy();
            }

            var columns = new Array();
            columns.push({
                id: 'Edit', name: '', field: 'CodeParameter', width: 40, cssClass: 'center u-actions',
                formatter: function (row, cell, value, columnDef, dataContext) {
                    var string = '';
                    string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                    return string;
                }
            });
            columns.push({ id: 'DirectorCode', name: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Resources.LabelCodeDirector, field: 'DiretorCode', width: 160,cssClass:'center' });
            columns.push({ id: 'DirectorName', name: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Resources.LabelGridNameDirector, field: 'DirectorName', width: 160, cssClass: 'center' });
            columns.push({ id: 'Affectation', name: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Resources.LabelGridTaxRegimen, field: 'Affectation', width: 160, cssClass: 'center' });
            columns.push({ id: 'PersonType', name: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Resources.LabelGridPersonType, field: 'PersonType', width: 160, cssClass: 'center' });
            columns.push({ id: 'DeclarationDate', name: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Resources.LabelGridDeclarationLast, field: 'DeclarationDate', width: 160, cssClass: 'center' });
            columns.push({ id: 'StatusRegister', name: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Resources.LabelGridStatusRegister, field: 'RegisterStatus', width: 160, cssClass: 'center' });

            base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                renderTo: 'grdResultTaxProfile',
                isPager: true,
                isServerPaging: true,
                proxy: {
                    action: Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Actions.Search,
                    data: base.Parameters.Search
                },
                columns: columns,
                forceFitColumns: true,
                width: '100%'
            });
            base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
        }
    };
}