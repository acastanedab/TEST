/// <summary>
/// Script de Controladora de la Vista Index  de Parámetros Sección
/// </summary>
/// <remarks>
/// Creación: GMD 20140721 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Index.Controller');
    Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';
            base.Control.FilterSearch.TxtRegistrationStatus().change(base.Event.BtnBuscarClick);
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
            if (base.Function.ApplyBinding(base.Control.Model)) {
                base.Control.BtnCreate().click(base.Event.BtnCreateClick);
                base.Control.BtnVisualize().click(base.Event.BtnVisualizeClick);
                base.Event.BtnSearchClick();
                base.Function.CreateGrid(base.Control.Model);
                base.Control.DivSearchResult().fadeIn();
                base.Control.FilterSearch.TxtRegistrationStatus().change(base.Event.BtnSearchClick);
            };
        };
        base.Parameters = {

        };

        base.Control = {
            ModalCreate: null,
            ModalEdit: null,
            Message: new Yanbal.SFT.Web.Components.Message(),
            CreationForm: null,
            EditForm: null,
            GridResult: null,
            Model : Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Models.Index,
            FormFilterSearch: function () { return $('#frmParameterSectionIndex'); },
            BtnVisualize: function () { return $('#btnVisualize'); },

            DivSearchResult: function () { return $('#divSearchResultParameterSection'); },
            BtnCreate: function () { return $('#btnCreateParameterSection'); },
            FilterSearch: {
                TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); }
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
                                codeParameter: selectedRegistration.CodeParameter,
                                codeSection: selectedRegistration.CodeSection,
                            },
                            action: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },
            BtnSearchClick: function () {
                base.Ajax.AjaxSearch.data = {
                    CodeParameter: base.Control.Model.CodeParameter,
                    RegistrationStatus: base.Control.FilterSearch.TxtRegistrationStatus().val()
                };
                base.Ajax.AjaxSearch.submit();
            },

            ModalCreateSuccess: function (data) {
                base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Create.Controller();
                base.Control.CreationForm.Ini({
                    Container: base.Control.ModalCreate,
                    AjaxCreateSuccessCustom: base.Event.DialogAjaxSucess
                });
            },

            ModalEditSuccess: function (data) {
                base.Control.EditForm = new Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Edit.Controller();
                base.Control.EditForm.Ini({
                    Container: base.Control.ModalEdit,
                    AjaxEditSuccessCustom: base.Event.DialogAjaxSucess
                });
            },

            DialogAjaxSucess: function (data) {
                base.Event.BtnSearchClick();
            },

            BtnCreateClick: function () {
                base.Control.ModalCreate.getAjaxContent({
                    data: {
                        CodeParameter: base.Control.Model.CodeParameter
                    },
                    action: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Actions.Create,
                    onSuccess: base.Event.ModalCreateSuccess
                });
            },

            AjaxSearchSuccess: function (data) {
                if (data != null) {
                    base.Function.CreateGrid(base.Control.Model);
                    base.Control.GridResult.setData(data);
                }
            }
        };
        base.Ajax = {
            AjaxSearch: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Actions.Search,
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
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
                }
                return isValid;
            },
            CreateGrid: function (model) {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }
                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'CodeSection', width: 60, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var cadena = '';
                        cadena += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                        return cadena;
                    }
                });
                columns.push({ id: 'Name', name: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelGridSection, field: 'NameSection', width: 200 });
                columns.push({ id: 'CodeParameterSectionType', name: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelGridSectionType, field: 'DescriptionParameterSectionType', width: 100 });
                columns.push({
                    id: 'ReadOnlyIndicator', name: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelGridReadOnly, field: 'ReadOnlyIndicator', minWidth: 60, cssClass: 'center',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var output = value;
                        output = '<input type="checkbox" ' + (value ? 'checked' : '') + ' disabled="disabled" />'
                        return output;
                    }
                });
                columns.push({
                    id: 'RequiredIndicator', name: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelGridRequired, field: 'RequiredIndicator', minWidth: 60, cssClass: 'center',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var output = value;
                        output = '<input type="checkbox" ' + (value ? 'checked' : '') + ' disabled="disabled" />'
                        return output;
                    }
                });
                columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Web.Policy.ParameterSection.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center' });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResultParameterSection',
                    columns: columns,
                    width: '100%',
                    isPager: true,
                    forceFitColumns: true
                });
                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        };
    };
}
catch (ex) {
    alert(ex.message);
}