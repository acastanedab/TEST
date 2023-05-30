/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: GMD 20140910 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Index.Controller');
    Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Index.Controller = function () {
        var base = this;
        base.Ini = function () {
            'use strict';
            base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                maxHeight: 750,
                width: 450,
                modal: true
            });

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmFormulaOrderIndex',
                title: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.FormulaOrderValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Models.Index)) {
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Function.GenerateGrid();
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
            ModalEdit: null,
            ModelIndex: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Models.Index,
            LabelFreight: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelFreight,
            Message: new Yanbal.SFT.Web.Components.Message(),
            CurrentRecord:null,
            EditionForm: null,
            GridResult: null,
            FormFiltersSearch: function () { return $('#frmFormulaOrderIndex'); },
            DivSearchResult: function () { return $('#divSearchResult'); },
            BtnSave: function () { return $('#btnSave'); },
            CurrentRecord: 1,
            LblFormula: function () { return $('#lblFormula'); },
            LblFormulaBegin: function () { return $('#lblFormulaBegin'); },            
            ParametersRegistration: {
                TxtFormula: function () { return $('#slcFormula'); }
            }
        };

        base.Event = {
            BtnSearchClick: function () {
                base.Ajax.AjaxSearch.data = null;
                base.Ajax.AjaxSearch.submit();                
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message = new Yanbal.SFT.Web.Components.Message();
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                FormulaCode: base.Control.ParametersRegistration.TxtFormula().val(),
                            };
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.SatisfactorySaved });
                        if (base.Event.AjaxCreateSuccessCustom != null) {
                            base.Event.AjaxCreateSuccessCustom(data);
                        }
                        base.Event.BtnSearchClick();
                        break;
                    case "2":
                        base.Control.Message.Warning({ message: 'La Formula ya se encuentra Priorizada' });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.FailedSaved });
                        break;
                }
            },

            BtnEditClick: function (e, args) {
                var button = $(e.target);
                if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete.id)) {
                    var columns = base.Control.GridResult.getView().getColumns();
                    var selectedColumn = columns[args.cell];
                    var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                    if (selectedColumn.id == "Edit") {
                        base.Control.ModalEdit.getAjaxContent({
                            data: {
                                formulaCode: selectedRegistration.FormulaCode
                            },
                            action: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },

            ModalEditSuccess: function () {
                base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Edit.Controller();
                base.Control.EditionForm.Ini({
                    Container: base.Control.ModalEdit,
                    AjaxEditSuccessCustom: base.Event.DialogAjaxEditSuccess
                });
            },

            DialogAjaxEditSuccess: function (data) {
                base.Event.BtnSearchClick();
            },
            AjaxSearchSuccess: function (data) {
                base.Function.GenerateGrid();
                base.Control.LblFormula().empty();
                base.Control.LblFormula().append(base.Control.LabelFreight);
                if (data != null && data.length > 0) {
                    base.Control.CurrentRecord = data.length;
                    base.Control.LblFormulaBegin().empty();
                    base.Control.LblFormula().empty();
                    base.Control.LblFormula().append(base.Control.LabelFreight);
                    $.each(data, function (index, value) {
                        base.Control.LblFormulaBegin().append("(");
                        if (value.FactorType == true) {
                            base.Control.LblFormula().append(' ' + value.Operation + ' ' + value.Factor + ') ');
                        } else {
                            base.Control.LblFormula().append(' ' + value.Operation + ' ' + value.Factor + '%' + '(' + base.Control.LabelFreight + ')) ');
                        }
                    });
                    base.Control.GridResult.setData(data);
                }
            },
        };

        base.Ajax = {
            AjaxSearch: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Actions.Search,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSearchSuccess
            }),
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Actions.RegisterFormulaOrder,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
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

            GenerateGrid: function () {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'FormulaCode', width: 5, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        if (dataContext.Order == base.Control.CurrentRecord)
                        {
                            string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete, base.Control.ModelIndex.Edit);
                        }
                        return string;
                    }
                });

                columns.push({ id: 'Order', name: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridOrder, field: 'Order', width: 30, cssClass: 'center' });
                columns.push({ id: 'Parameter', name: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridParameter, field: 'ParameterDescription', width: 120 });
                columns.push({ id: 'ParameterValue', name: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridParameterValue, field: 'ValueDescription', width: 140 });
                columns.push({
                    id: 'Operation', name: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridOperation, field: 'Operation', width: 30, cssClass: 'center u-actions',
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

                columns.push({ id: 'Factor', name: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridFactor, field: 'FactorString', width: 30, cssClass: 'right' });
                columns.push({
                    id: 'FactorType', name: Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridFactorType, field: 'FactorType', width: 60, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        if (dataContext.FactorType == '0') {
                            string += Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridFactorTypeAmount;
                        } else if (dataContext.FactorType == '1') {
                            string += Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridFactorTypePercentage;
                        } else if (dataContext.FactorType == '2') {
                            string += Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Resources.LabelGridFactorTypeFixedValue;
                        }
                        return string;
                    }
                });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResult',
                    columns: columns,
                    width: '100%',
                    isPager: true,
                    forceFitColumns: true
                });                
                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        }
    };
}
catch (ex) {
    alert(ex.message);
}