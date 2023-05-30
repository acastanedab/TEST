/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: GMD 20140918 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Index.Controller');
Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        'use strict';
        base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 600,
            width: 950,
            modal: true
        });

        base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 600,
            width: 950,
            modal: true
        });

        base.Control.ModalSeeCompanyLogo = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 550,
            width: 350,
            modal: true
        });

        base.Control.ModalSeeReportLogo = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 550,
            width: 350,
            modal: true,
        });

        if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Models.Index)) {
            base.Control.BtnCreate().click(base.Event.BtnCreateClick);
            base.Event.BtnSearchClick();
            base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Models.Index);
            base.Control.DivSearchResult().fadeIn();
        };

        base.Event.BtnSearchClick();
    };

    base.Parameters = {
        Search: null
    };

    base.Control = {
        ModalCreate: null,
        ModalEdit: null,
        ModalSeeCompanyLogo: null,
        ModalSeeReportLogo: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        CreationForm: null,
        EditionForm: null,
        CompanyLogoForm: null,
        ReportLogoForm: null,
        GridResult: null,
        BusinessUnitConfigurationModel: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Models.Index,
        FormFilterSearch: function () { return $('#frmBusinessUnitConfigurationIndex'); },
        DivSearchResult: function () { return $('#divSearchResult'); },
        BtnCreate: function () { return $('#btnCreate'); },

        FiltersSearch: {
            //TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); }
        }
    };

    base.Event = {
        BtnEditClick: function (e, args) {
            var button = $(e.target);

            if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.Edit.id)) {
                var columns = base.Control.GridResult.getView().getColumns();
                var selectedColumn = columns[args.cell];
                var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                if (selectedColumn.id == "Edit") {
                    base.Control.ModalEdit.getAjaxContent({
                        data: {
                            businessUnitCode: selectedRegistration.BusinessUnitCode,
                            businessUnitConfigurationCode: selectedRegistration.BusinessUnitConfigurationCode
                        },
                        action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.Edit,
                        onSuccess: base.Event.ModalEditSuccess
                    });
                }
            }
            else if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Action.SelectCompanyLogo.id)) {
                var columns = base.Control.GridResult.getView().getColumns();
                var selectedColumn = columns[args.cell];
                var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                if (selectedColumn.id == "SelectCompanyLogo") {
                    base.Control.ModalSeeCompanyLogo.getAjaxContent({
                        data: {
                            businessUnitConfigurationCode: selectedRegistration.BusinessUnitConfigurationCode
                        }
                        ,
                        action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.ViewCompanyLogo,
                        onSuccess: base.Event.ModalSeeCompanyLogoSuccess
                    });
                }
            }
            else if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Action.SelectReportLogo.id)) {
                var columns = base.Control.GridResult.getView().getColumns();
                var selectedColumn = columns[args.cell];
                var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                if (selectedColumn.id == "SelectReportLogo") {
                    base.Control.ModalSeeReportLogo.getAjaxContent({
                        data: {
                            businessUnitConfigurationCode: selectedRegistration.BusinessUnitConfigurationCode
                        }
                        ,
                        action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.ViewReportLogo,
                        onSuccess: base.Event.ModalSeeReportLogoSuccess
                    });
                }
            }
            e.stopImmediatePropagation();
        },

        BtnSearchClick: function () {
            base.Parameters.Search = {
                BusinessUnitCode: base.Control.BusinessUnitConfigurationModel.BusinessUnitCode                
            };

            base.Function.ExecuteQuery();
        },

        ModalCreateSuccess: function (data) {
            base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Create.Controller();
            base.Control.CreationForm.Ini({
                Container: base.Control.ModalCreate,
                AjaxCreateSuccessCustom: base.Event.DialogAjaxSucess
            });
        },

        ModalEditSuccess: function (data) {
            base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Edit.Controller();
            base.Control.EditionForm.Ini({
                Container: base.Control.ModalEdit,
                AjaxEditSuccessCustom: base.Event.DialogAjaxSucess
            });
        },

        ModalSeeCompanyLogoSuccess: function (html, customParam) {
            base.Control.CompanyLogoForm = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.ViewCompanyLogo.Controller();
            base.Control.CompanyLogoForm.Ini({
                Contenedor: base.Control.ModalSeeCompanyLogo,
                AjaxVisualizeSuccessCustom: base.Event.DialogAjaxSucess
            });
        },

        ModalSeeReportLogoSuccess: function (html, customParam) {
            base.Control.ReportLogoForm = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.ViewReportLogo.Controller();
            base.Control.ReportLogoForm.Ini({
                Contenedor: base.Control.ModalSeeReportLogo,
                AjaxVisualizeSuccessCustom: base.Event.DialogAjaxSucess
            });
        },

        DialogAjaxSucess: function (data) {
            base.Event.BtnSearchClick();
        },

        BtnCreateClick: function () {
            base.Control.ModalCreate.getAjaxContent({
                data: {
                    businessUnitCode: base.Control.BusinessUnitConfigurationModel.BusinessUnitCode
                },
                action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.Create,
                onSuccess: base.Event.ModalCreateSuccess,
            });
        },

        AjaxSearchSuccess: function (data) {
            if (data != null) {
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Models.Index);
                base.Control.GridResult.setData(data);
            }
        }
    };

    base.Ajax = {
        AjaxBuscar: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.Search,
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
            base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Models.Index);
            base.Control.GridResult.load();
        },

        GenerateGrid: function (model) {
            if (base.Control.GridResult != null) {
                base.Control.GridResult.destroy();
            }

            var columns = new Array();
            columns.push({
                id: 'Edit', name: '', field: 'BusinessUnitConfigurationCode', width: 20, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    if (dataContext.NumberRows == 1) {
                        base.Control.BtnCreate().prop('disabled', true);
                        base.Control.BtnCreate().attr('class', 'pull-left btn btn-default btn-filter');
                    }
                    if (dataContext.NumberRows == null && dataContext.RegistrationStatus == 0) {
                        base.Control.BtnCreate().prop('disabled', false);
                        base.Control.BtnCreate().attr('class', 'pull-left btn btn-primary btn-filter');
                    }
                    var string = '';
                    string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                    return string;
                }
            });
            columns.push({
                id: 'CultureCode', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridCulture, field: 'CultureCode', width: 130, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    var output = dataContext.Culture.CultureCode;
                    return output;
                }
            });
            columns.push({ id: 'TimeZone', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridTimeZone, field: 'DescriptionTimeZone', width: 220 });
            columns.push({ id: 'DisplayFormReport', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridDisplayFormReport, field: 'DescriptionDisplayFormReport', width: 100, cssClass: 'center u-actions' });

            columns.push({ id: 'AcquiringMaineMenu', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridAcquiringMainMenu, field: 'CollapseMenuIndicator', width: 95, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    var output = value;
                    output = '<input type="checkbox" ' + (value ? 'checked' : '') + ' disabled="disabled" />'
                    return output;
                }
            });

            columns.push({ id: 'RowsPerPage', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridRowsPerPage, field: 'RowsPerPage', width: 100, cssClass: 'center u-actions' });
            columns.push({ id: 'CharactersMinimumGloss', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridCharactersMinimumGloss, field: 'MinimumNumberCharactersGloss', width: 100, cssClass: 'center u-actions' });
            columns.push({ id: 'VowelssMinimumGloss', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridVowelsMinimumGloss, field: 'MinimumNumberVowelGloss', width: 100, cssClass: 'center u-actions' });

            columns.push({
                id: 'SelectCompanyLogo', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridCompanyLogo, field: 'BusinessUnitConfigurationCode', width: 70, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    var string = '';
                    string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.SelectCompanyLogo, model.SelectCompanyLogo);
                    return string;
                }
            });
            columns.push({
                id: 'SelectReportLogo', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridReportLogo, field: 'BusinessUnitConfigurationCode', width: 70, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    var string = '';
                    string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.SelectReportLogo, model.SelectReportLogo);
                    return string;
                }
            });

            columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center u-actions' });

            base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                renderTo: 'grdResult',
                columns: columns,
                isServerPaging: true,
                proxy: {
                    action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.Search,
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