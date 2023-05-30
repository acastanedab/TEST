/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creacion: GMD 20140718 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.Parameter.Index.Controller');
    Yanbal.SFT.Presentation.Web.Policy.Parameter.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';
            base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true,
                title: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelTitleNew
            });
            base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true,
                title: ''
            });
            if (base.Function.ApplyBinding(base.Control.modelParameter)) {
                base.Control.FiltersSearch.RdoParameterSystem().attr('value', true);
                base.Control.FiltersSearch.RdoParameterBusiness().attr('value', false);
                base.Control.BtnSearch().click(base.Event.BtnSearchClick);
                base.Control.FiltersSearch.TxtCode().keypress(base.Event.EventCodeKeyPress);
                base.Control.FiltersSearch.TxtCode().bind('paste', base.Event.EventCodePaste);
                base.Control.FiltersSearch.TxtName().keypress(base.Event.EventEnterKeyPress);
                base.Control.FiltersSearch.TxtDescription().keypress(base.Event.EventEnterKeyPress);
                base.Control.BtnCreate().click(base.Event.BtnCreateClick);
                base.Control.BtnVisualize().click(base.Event.BtnVisualizeClick);
                base.Function.CreateGrid(base.Control.modelParameter);
                base.Control.DivSearchResult().fadeIn();
                if (base.Control.modelParameter != null) {
                    if (base.Control.modelParameter.ParameterName != null) { base.Control.FiltersSearch.TxtName().attr('value', base.Control.modelParameter.ParameterName); }
                    if (base.Control.modelParameter.ParameterDescription != null) { base.Control.FiltersSearch.TxtDescription().attr('value', base.Control.modelParameter.ParameterDescription); }
                    if (base.Control.modelParameter.RegistrationStatus != null) { base.Control.FiltersSearch.TxtRegistrationStatus().attr('value', base.Control.modelParameter.RegistrationStatus); }
                };
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
            Message: new Yanbal.SFT.Web.Components.Message(),
            CreationForm: null,
            EditForm: null,
            GridResult: null,
            modelParameter: Yanbal.SFT.Presentation.Web.Policy.Parameter.Models.Index,
            FormFiltersSearch: function () { return $('#frmParameterIndex'); },
            BtnVisualize: function () { return $('#btnVisualize'); },

            DivSearchResult: function () { return $('#divSearchResultParameter'); },
            BtnSearch: function () { return $('#btnSearchParameter'); },
            BtnCreate: function () { return $('#btnCreateParameter'); },
            FiltersSearch: {
                TxtCode: function () { return $('#txtSearchCode'); },
                TxtName: function () { return $('#txtSearchName'); },
                TxtDescription: function () { return $('#txtSearchDescription'); },
                TxtParameterType: function () { return $('#slcSearchParameterType'); },
                TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); },                
                RdoParameterSystem: function () { return $('#rdoParameterSystem'); },
                RdoParameterBusiness: function () { return $('#rdoParameterBusiness'); },
                RdoParameterSystemBusiness: function () { return $('input[name="rdoParameterSystemBusiness"]:checked'); }
            }
        };

        base.Event = {
            EventCodePaste: function (event) {
                var esValido = ValidarCopySoloAlfanumerico(event);
                return esValido;
            },
            EventCodeKeyPress: function (event) {
                var esValido = validateOnlyLetters(event);
                if (esValido) {
                    ConvertShift();
                    var key = getKeyCode(event);
                    var isValid = !(event && key == 13);
                    if (isValid == false) {
                        base.Event.BtnSearchClick();
                    }
                }
                return isValid;                
            },
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
                                codeParameter: selectedRegistration.CodeParameter
                            },
                            action: Yanbal.SFT.Presentation.Web.Policy.Parameter.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },
            BtnSearchClick: function () {
                base.Parameters.Search = {
                    CodeApproximate: base.Control.FiltersSearch.TxtCode().val().trim(),
                    ParameterName: base.Control.FiltersSearch.TxtName().val().trim(),
                    ParameterDescription: base.Control.FiltersSearch.TxtDescription().val().trim(),
                    CodeParameterType: base.Control.FiltersSearch.TxtParameterType().val(),
                    ParameterSystemIndicator: base.Control.FiltersSearch.RdoParameterSystemBusiness().val(),
                    RegistrationStatus: base.Control.FiltersSearch.TxtRegistrationStatus().val()
                };
                base.Function.ExecuteQuery();
            },

            ModalCreateSuccess: function (data) {
                base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.Parameter.Create.Controller();
                base.Control.CreationForm.Ini({
                    Container: base.Control.ModalCreate,
                    AjaxCreateSuccessCustom: base.Event.DialogAjaxCreateSuccess
                });
            },
            ModalEditSuccess: function (data) {
                base.Control.EditForm = new Yanbal.SFT.Presentation.Web.Policy.Parameter.Edit.Controller();
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
                    action: Yanbal.SFT.Presentation.Web.Policy.Parameter.Actions.Create,
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
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
                }
                return isValid;
            },

            ExecuteQuery: function () {
                base.Function.CreateGrid(Yanbal.SFT.Presentation.Web.Policy.Parameter.Models.Index);
                base.Control.GridResult.load();
            },

            CreateGrid: function (model) {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'CodeParameter', width: 40, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                        return string;
                    }
                });                
                columns.push({
                    id: 'Sections', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridSections, field: 'CodeParameter', width: 90, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurityLink(Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.Selection,
                                                                                           model.GoSection,
                                                                                           Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridSections,
                                                                                           Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Actions.Index,
                                                                                           value);
                        return string;
                    }
                });
                columns.push({ id: 'Code', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridCode, field: 'Code', width: 70, cssClass: 'center u-actions' });
                columns.push({ id: 'Name', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridName, field: 'NameParameter', width: 160 });
                columns.push({ id: 'Description', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridDescription, field: 'DescriptionParameter', width: 265 });
                columns.push({ id: 'ParameterType', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridParameterType, field: 'DescriptionParameterType', width: 80, cssClass: 'center' });
                
                columns.push({
                    id: 'AllowAddValue', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridAllowAddValue, field: 'AllowAddValueIndicator', width: 60, cssClass: 'center',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var output = value;
                        output = '<input type="checkbox" ' + (value ? 'checked' : '') + ' disabled="disabled" />'
                        return output;
                    }
                });
                columns.push({
                    id: 'AllowModifyValue', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridAllowModifyValue, field: 'AllowModifyValueIndicator', width: 60, cssClass: 'center',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var output = value;
                        output = '<input type="checkbox" ' + (value ? 'checked' : '') + ' disabled="disabled" />'
                        return output;
                    }
                });
                columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Presentation.Web.Policy.Parameter.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center' });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResultParameter',
                    isPager: true,
                    isServerPaging: true,
                    proxy: {
                        action: Yanbal.SFT.Presentation.Web.Policy.Parameter.Actions.Search,
                        data: base.Parameters.Search
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