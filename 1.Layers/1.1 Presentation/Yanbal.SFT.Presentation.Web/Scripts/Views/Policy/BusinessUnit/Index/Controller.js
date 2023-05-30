/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: GMD 20140917 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Index.Controller');
Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        'use strict';
        //base.Control.FiltersSearch.TxtBusinessUnitName().keypress(base.Event.EventEnterKeyPress);
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

        if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Models.Index)) {
            base.Control.BtnSearch().click(base.Event.BtnSearchClick);
            base.Control.BtnCreate().click(base.Event.BtnCreateClick);
            base.Control.FiltersSearch.TxtBusinessUnitName().keypress(base.Event.EventEnterKeyPress);
            base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Models.Index);
            base.Control.DivSearchResult().fadeIn();
        };
        if (base.Control.BusinessUnitModel != null) {
            var sessionFilterIndicator = 0;
            if (base.Control.BusinessUnitModel.CountryCode != null) { base.Control.FiltersSearch.TxtCountry().attr('value', base.Control.BusinessUnitModel.CountryCode); sessionFilterIndicator = 1; }
            if (base.Control.BusinessUnitModel.BusinessUnitName != null) { base.Control.FiltersSearch.TxtBusinessUnitName().attr('value', base.Control.BusinessUnitModel.BusinessUnitName); sessionFilterIndicator = 1; }
            if (base.Control.BusinessUnitModel.RegistrationStatus != null) { base.Control.FiltersSearch.TxtRegistrationStatus().attr('value', base.Control.BusinessUnitModel.RegistrationStatus); sessionFilterIndicator = 1 }
        }
        base.Event.BtnSearchClick();
    };

    base.Parameters = {
        Search: null
    };

    base.Control = {
        ModalCreate: null,
        ModalEdit: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        CreationForm: null,
        EditionForm: null,
        GridResult: null,
        BusinessUnitModel: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Models.Index,
        FormFilterSearch: function () { return $('#frmBusinessUnitIndex'); },
        DivSearchResult: function () { return $('#divSearchResult'); },

        BtnSearch: function () { return $('#btnSearch'); },
        BtnCreate: function () { return $('#btnCreate'); },

        FiltersSearch: {
            TxtCountry: function () { return $('#slcSearchCountry'); },
            TxtBusinessUnitName: function () { return $('#txtSearchBusinessUnitName'); },
            //TxtCulture: function () { return $('#slcSearchCulture'); },
            TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); }
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
                            businessUnitCode: selectedRegistration.BusinessUnitCode
                        },
                        action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Actions.Edit,
                        onSuccess: base.Event.ModalEditSuccess
                    });
                }
            }
            e.stopImmediatePropagation();
        },
        BtnSearchClick: function () {
            base.Parameters.Search = {
                CountryCode: base.Control.FiltersSearch.TxtCountry().val(),
                BusinessUnitName: base.Control.FiltersSearch.TxtBusinessUnitName().val(),
                //CodigoCultura: base.Control.FiltersSearch.TxtCulture().val(),
                RegistrationStatus: base.Control.FiltersSearch.TxtRegistrationStatus().val()
            };

            base.Function.ExecuteQuery();
        },

        ModalCreateSuccess: function (data) {
            base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Create.Controller();
            base.Control.CreationForm.Ini({
                Container: base.Control.ModalCreate,
                AjaxCreateSuccessCustom: base.Event.DialogAjaxEditSucess
            });
        },

        ModalEditSuccess: function (data) {
            base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Edit.Controller();
            base.Control.EditionForm.Ini({
                Container: base.Control.ModalEdit,
                AjaxEditSuccessCustom: base.Event.DialogAjaxEditSucess
            });
        },

        DialogAjaxEditSucess: function (data) {
            base.Event.BtnSearchClick();
        },

        BtnCreateClick: function () {
            base.Control.ModalCreate.getAjaxContent({
                action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Actions.Create,
                onSuccess: base.Event.ModalCreateSuccess,
                data: {
                    CountryCode: base.Control.FiltersSearch.TxtCountry().val()
                }
            });
        },

        AjaxSearchSuccess: function (data) {
            if (data != null) {
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Models.Index);
                base.Control.GridResult.setData(data);
            }
        }
    };
    base.Ajax = {
        AjaxBuscar: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Actions.Search,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSearchSuccess
        }),
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
                base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Resources.ErrorCargarViewModel });
            }
            return isValid;
        },

        ExecuteQuery: function () {
            base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Models.Index);
            base.Control.GridResult.load();
        },

        GenerateGrid: function (model) {
            if (base.Control.GridResult != null) {
                base.Control.GridResult.destroy();
            }

            var columns = new Array();
            columns.push({
                id: 'Edit', name: '', field: 'BusinessUnitCode', width: 50, cssClass: 'center u-actions',
               Formater: function (row, cell, value, columnDef, dataContext) {
                   var string = '';
                   string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                   return string;
                }
            });

            columns.push({
                id: 'Configuration', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelGridConfiguration, field: 'BusinessUnitCode', width: 80, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    var string = '';
                    string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurityLink(Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.Selection, model.GoConfiguration,
                                                                                       Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelGridConfiguration,
                                                                                       Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.Index,
                                                                                       value);
                    return string;
                }
            });
            columns.push({ id: 'CountryDescription', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelGridCountry, field: 'CountryName', width: 80 });
            columns.push({ id: 'BusinessUnitName', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelGridBusinessUnitName, field: 'BusinessName', width: 200 });
            columns.push({ id: 'BusinessAddress', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelGridAddress, field: 'BusinessAddress', width: 150 });
            columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center u-actions' });

            base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                renderTo: 'grdResult',
                columns: columns,
                isServerPaging: true,
                proxy: {
                    action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Actions.Search,
                    data: base.Parameters.Search
                },
                width: '100%',
                isPager: true,
                forceFitColumns: true
            });
            base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
        }
    };
};