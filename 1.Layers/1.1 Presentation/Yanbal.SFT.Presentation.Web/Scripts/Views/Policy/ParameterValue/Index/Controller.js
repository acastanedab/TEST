/// <summary>
/// Script de Controladora de la Vista Index  de Parámetros Valor
/// </summary>
/// <remarks>
/// Creación: GMD 20140825 <br />
/// </remarks>

ns('Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Index');
Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        'use strict';
        base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 750,
            width: 450,
            modal: true
        });
        base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 750,
            width: 450,
            modal: true
        });
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmSearchParameterValue',
            messages: Yanbal.SFT.Presentation.Web.ParameterValueValidation.Message.Resources
        });
        
        if (base.Function.ApplyBinding(base.Control.ModelParameterValue)) {
            base.Control.DivSearchResult().fadeIn();
            base.Control.FilterSearch.SlcParameter().change(base.Event.BtnSearchChange);
            base.Control.FilterSearch.SlcSearchParameterStatus().change(base.Event.BtnSearchChange);
            base.Control.BtnCreate().click(base.Event.BtnCreateClick);
            base.Control.BtnCreate().attr('disabled', 'disabled');
        }
    }

    base.Parameters = {
        FormularioSeleccion: {
            SelectedRegistration: null
        },
        Search: null
    };

    base.Control = {
        ModelParameterValue: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Models.Index,
        TypeSectionDate: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDate,
        TypeSectionInteger: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeInteger,
        TypeSectionDecimal: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Enumerated.SectionTypeDecimal,
        Message: new Yanbal.SFT.Web.Components.Message(),
        ParameterSearch: null,
        FormFilterSearch: function () { return $('#frmSearchParameterValue'); },
        BtnCreate: function () { return $('#btnCreateParameterValue'); },
        DivSearchResult: function () { return $('#divDatosDeuda'); },
        FilterSearch: {
            SlcSearchParameterStatus: function () { return $('#slcSearchParameterStatus'); },
            SlcParameter: function () { return $('#slcParameter'); }
        },
        ModalEdit: null,
        ModalCreate: null,
        GridParameters: null,
        FilterCreate: null,
        FilterEdit: null,
    };

    base.Event = {
        BtnSearchChange: function () {
            if (base.Control.Validator.isValid()) {
                base.Ajax.AjaxSearch.data = {
                    RegistrationStatus: base.Control.FilterSearch.SlcSearchParameterStatus().val(),
                    Code: base.Control.FilterSearch.SlcParameter().val()
                };
                base.Ajax.AjaxSearch.submit();
            }
        },
        BtnEditClick: function (e, args) {
            if ($(e.target).hasClass("fa fa-edit")) {
                var columns = base.Control.GridParameters.getView().getColumns();
                var columnSelected = columns[args.cell];
                var selectedRegistration = base.Control.GridParameters.getDataView().getItem(args.row);
                if (columnSelected.id == "Edit") {
                    base.Control.ModalEdit.getAjaxContent({
                        action: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Actions.Edit,
                        data: {
                            codeParameter: selectedRegistration.CodeParameter,
                            codeParameterValue: selectedRegistration.CodeValue
                        },
                        onSuccess: base.Event.ModalEditSuccess
                    });
                }
            }
        },
        BtnCreateClick: function () {
                base.Control.ModalCreate.getAjaxContent({
                    action: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Actions.Create,
                    data: {
                    code: base.Control.FilterSearch.SlcParameter().val()
                    },
                    onSuccess: base.Event.ModalCreateSuccess
                });
        },
        AjaxSearchSuccess: function (data) {
            if (data != null) {
                base.Function.GenerateGrid(data);
            }
        },

        AjaxErrorSuccess: function (data, error) {
            if (data != null) {
                base.Function.GenerateGrid(data);
            }
        },
        ModalCreateSuccess: function (html, customParam) {
            base.Control.FilterCreate = new Yanbal.SFT.Presentation.Web.Freigth.Policy.ParameterValue.Create.Controller();
            base.Control.FilterCreate.Ini({
                Container: base.Control.ModalCreate,
                AjaxCreateSuccessCustom: base.Event.DialogAjaxSucess
            });
        },
        DialogAjaxSucess: function (data) {
            base.Event.BtnSearchChange();
        },
        ModalEditSuccess: function (html, customParam) {
            base.Control.FilterEdit = new Yanbal.SFT.Presentation.Web.Freigth.Policy.ParameterValue.Edit.Controller();
            base.Control.FilterEdit.Ini({
                Container: base.Control.ModalEdit,
                AjaxEditSuccessCustom: base.Event.DialogAjaxSucess
            });
        }
    };

    base.Ajax = {
        AjaxSearch: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Actions.Search,
            autoSubmit: false,
            onError: base.Event.AjaxErrorSuccess,
            onSuccess: base.Event.AjaxSearchSuccess
        }),
    };

    base.Function = {
        ValitorRegister: function () {
            var isValid = true;
            var txtNombrePar = base.Control.FilterSearch.TxtCodeParameter().val();
            if (txtNombrePar == "") {
                isValid = false,
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
                base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
            }
            return isValid;
        },
        GenerateGrid: function (data) {
            if (base.Control.GridParameters != null) {
                base.Control.GridParameters.destroy();
            }
            var columns = new Array();

            if (data.ListParameterSection.length == 0) {
                columns.push({ id: '', name: '', field: '', width: 800, cssClass: 'center' });
            }
            else {
                if (data.Parameter.AllowModifyValueIndicator) {
                    columns.push({
                        id: 'Edit', name: '', field: 'CodeValue', width: 50, cssClass: 'center u-actions',
                        Formater: function (row, cell, value, columnDef, dataContext) {
                            var string = '';
                            string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, base.Control.ModelParameterValue.Edit);
                            return string;
                        }
                    });
                }

                if (!data.Parameter.AllowAddValueIndicator) {
                    base.Control.BtnCreate().attr('disabled', 'disabled');
                    base.Control.BtnCreate().removeAttr('class');
                    base.Control.BtnCreate().attr('class', 'pull-left btn btn-default btn-filter');
                }
                else {
                    base.Control.BtnCreate().removeAttr('disabled');
                    base.Control.BtnCreate().removeAttr('class');
                    base.Control.BtnCreate().attr('class', 'pull-left btn btn-primary btn-filter');
                }
                $.each(data.ListParameterSection, function (index, value) {
                    var classColumn = '';
                    switch (value.CodeParameterSectionType) {
                        case base.Control.TypeSectionDate:
                            classColumn = 'center u-actions';
                            break;
                        case base.Control.TypeSectionInteger:
                            classColumn = 'right u-actions';
                            break;
                        case base.Control.TypeSectionDecimal:
                            classColumn = 'right u-actions';
                            break;
                        default:
                            classColumn = 'left u-actions';
                            break;
                    }

                    if (value.CodeSection == '1') {
                        classColumn = 'center u-actions';
                    }

                    columns.push({
                        id: value.CodeSection, name: value.NameSection, field: value.CodeSection, cssClass: classColumn,
                        Formater: function (row, cell, valueFormated, columnDef, dataContext) {
                            var output = dataContext.RecordValueString[value.CodeSection];
                            return output;
                        }
                    });
                });
                columns.push({ id: 'DescriptionRegistrationStatus', name: Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center' });
            }
            base.Control.GridParameters = new Yanbal.SFT.Web.Components.Grid({
                renderTo: 'grdResultParameterValue',
                columns: columns,
                width: '100%',
                isPager: true,
                forceFitColumns: true
            });            
            if (data != null) {
                base.Control.GridParameters.setData(data.ListParameterValue);
                base.Control.GridParameters.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        }
    };
};