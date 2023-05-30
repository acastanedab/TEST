/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: 	GMD 20140912 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Formula.Index.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Formula.Index.Controller = function () {
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

            if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Freight.Formula.Models.Index)) {
                base.Control.BtnVisualize().click(base.Event.BtnVisualizeClick);
                base.Control.BtnSearch().click(base.Event.BtnSearchClick);
                base.Control.BtnCreate().click(base.Event.BtnCreateClick);
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Freight.Formula.Models.Index);
                base.Control.DivSearchResult().fadeIn();
                base.Control.FiltersSearch.TxtParameter().change(base.Event.ChangeParameter);
                base.Event.ChangeParameter();
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
            EditionForm: null,
            GridResult: null,
            BtnVisualize: function () { return $('#btnVisualize'); },
            FormFilterSearch: function () { return $('#frmFormulaIndex'); },
            DivSearchResult: function () { return $('#divSearchResult'); },
            BtnSearch: function () { return $('#btnSearch'); },
            BtnCreate: function () { return $('#btnCreate'); },
            FiltersSearch: {
                TxtParameter: function () { return $('#slcSearchParameter'); },
                TxtParameterValue: function () { return $('#slcSearchParameterValue'); },
                TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); }
            }
        };

        base.Event = {
            ChangeParameter: function () {
                var codeParameter = base.Control.FiltersSearch.TxtParameter().val();
                if (codeParameter != null && codeParameter != "") {
                    base.Ajax.AjaxChangeParameter.data = {
                        parameterCode: codeParameter
                    };
                    base.Ajax.AjaxChangeParameter.submit();
                }
                else {
                    base.Event.AjaxChangeParameterSuccess(null);
                }
            },

            BtnCreateClick: function () {
                base.Control.ModalCreate.getAjaxContent({
                    action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.Create,
                    onSuccess: base.Event.ModalCreateSuccess
                });
            },

            BtnSearchClick: function () {
                base.Parameters.Search = {
                    ParameterCode: base.Control.FiltersSearch.TxtParameter().val(),
                    Value: base.Control.FiltersSearch.TxtParameterValue().val(),
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
                                formulaCode: selectedRegistration.FormulaCode
                            },
                            action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },

            ModalCreateSuccess: function (data) {
                base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Freight.Formula.Create.Controller();
                base.Control.CreationForm.Ini({
                    Container: base.Control.ModalCreate,
                    AjaxCreateSuccessCustom: base.Event.DialogAjaxCreateSuccess
                });
            },

            ModalEditSuccess: function (data) {
                base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Freight.Formula.Edit.Controller();
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

            AjaxChangeParameterSuccess: function (data) {
                base.Control.FiltersSearch.TxtParameterValue().find('option').remove();
                base.Control.FiltersSearch.TxtParameterValue().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelSelectAll));
                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.FiltersSearch.TxtParameterValue().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
            }
        };

        base.Ajax = {
            AjaxChangeParameter: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.ChangeParameter,
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
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Freight.Formula.Models.Index);
                base.Control.GridResult.load();
            },

            GenerateGrid: function (model) {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'FormulaCode', width: 20, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                        return string;
                    }
                });
                columns.push({ id: 'FormulaCode', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridCode, field: 'FormulaCode', width: 20, cssClass: 'center u-actions' });
                columns.push({ id: 'DescriptionSendType', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridSendType, field: 'DescriptionSendType', width: 60, cssClass: 'center u-actions' });

                columns.push({ id: 'Parameter', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridParameter, field: 'ParameterDescription', width: 120 });
                columns.push({ id: 'ParameterValue', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridParameterValue, field: 'ValueDescription', width: 130 });
                columns.push({
                    id: 'Operation', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridOperation, field: 'Operation', width: 50, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var output = value;
                        if (dataContext.FactorType == '2') {
                            output = '<label style="font-size:20px"></label>';
                        } else {
                            output = '<label style="font-size:20px">' + value + '</label>';
                        }
                        return output;
                    }
                });

                columns.push({ id: 'Factor', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridFactor, field: 'FactorString', width: 30, cssClass: 'right' });

                columns.push({
                    id: 'FactorType', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridFactorType, field: 'FactorType', width: 60, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        if (dataContext.FactorType == '0') {                            
                            string += Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridFactorTypeAmount;
                        }else if (dataContext.FactorType == '1') {
                            string += Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridFactorTypePercentage;
                        }else if (dataContext.FactorType == '2') {
                            string += Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridFactorTypeFixedValue;
                        }
                            
                        return string;
                    }
                });

                columns.push({ id: 'RegistrationStatus', name: Yanbal.SFT.Presentation.Web.Freight.Formula.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 50, cssClass: 'center' });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResult',
                    isPager: true,
                    isServerPaging: true,
                    proxy: {
                        action: Yanbal.SFT.Presentation.Web.Freight.Formula.Actions.Search,
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