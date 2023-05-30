/// <summary>
/// Script de Controladora de la Vista de Creación de Combinación de Parámetros
/// </summary>
/// <remarks>
/// Creación: 	EJHF 09092014 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Combination.Create.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Combination.Create.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmCreateParameterCombination',
                title: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.CombinationValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(base.Control.ModelCreate, base.Control.Container.getMainContainer())) {
                base.Control.BtnAdd().click(base.Event.BtnAddParameterClick);
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
                base.Function.GenerateGrid();
                base.Control.DivSearchResult().fadeIn();
                base.Control.ListParameterCombination = new Array();
                base.Control.ListParameterValueCurrent = base.Control.ModelCreate.ListParameterValue;
                base.Event.AjaxAddSuccess(base.Control.ModelCreate.ListParameterValue);
                base.Control.IndicatorCurrent++;
                base.Control.ParameterCodeCurrent = base.Control.ModelCreate.ListParameter[base.Control.IndicatorCurrent].ParameterCode;
                base.Control.ParameterNameCurrent = base.Control.ModelCreate.ListParameter[base.Control.IndicatorCurrent].ParameterName;
                base.Control.OrderCurrent = base.Control.ModelCreate.ListParameter[base.Control.IndicatorCurrent].Order;
                base.Control.LblParameterName().empty();
                base.Control.LblParameterName().append(base.Control.ParameterNameCurrent);
            };
        };

        base.Control = {
            AjaxCreateSuccessCustom: null,
            Container: null,
            GridResult: null,
            ModelCreate: Yanbal.SFT.Presentation.Web.Freight.Combination.Models.Create,
            Message: new Yanbal.SFT.Web.Components.Message(),
            LblParameterName: function () { return $('#lblParameterName'); },
            BtnAdd: function () { return $('#btnAddPCCreate') },
            BtnSave: function () { return $('#btnSavePCCreate'); },
            BtnCancel: function () { return $('#btnCancelPCCreate'); },
            DivCreate: function () { return $('#divCreateParameterCombination'); },
            DivSearchResult: function () { return $('#divSearchResultParameterCombination'); },
            ListCodeParameter: Yanbal.SFT.Presentation.Web.Freight.Combination.Models.Create.ListCodeParameter,
            ListParameterCombination: null,
            ListParameterValueCurrent: null,
            ParameterCodeCurrent: null,
            ParameterNameCurrent: null,
            OrderCurrent: null,
            IndicatorCurrent: -1,
            ParametersRegistration: {
                SlcParameterValue: function () { return $('#slcParameterValueCreate'); }
            }
        };

        base.Event = {
            BtnCancelClick: function () {
                base.Control.Container.close();
            },

            BtnAddParameterClick: function () {
                if (base.Control.Validator.isValid()) {
                    var codeParameter = base.Control.ParameterCodeCurrent;
                    var nameParameter = base.Control.ParameterNameCurrent;
                    var codeParameterValue = base.Control.ParametersRegistration.SlcParameterValue().val();
                    var i = 0;
                    while (base.Control.ListParameterValueCurrent[i].Id != codeParameterValue) {
                        i++;
                    }
                    var nameParameterValue = base.Control.ListParameterValueCurrent[i].Name;

                    parameterCombination = {
                        CodeParameter: null,
                        NameParameter: null,
                        Value: null,
                        DescriptionValue: null
                    };

                    parameterCombination.id = codeParameter;
                    parameterCombination.CodeParameter = codeParameter;
                    parameterCombination.NameParameter = nameParameter;
                    parameterCombination.Value = codeParameterValue;
                    parameterCombination.DescriptionValue = nameParameterValue;

                    base.Control.ListParameterCombination.push(parameterCombination);

                    base.Control.GridResult.setData(base.Control.ListParameterCombination);

                    base.Control.IndicatorCurrent++;
                    base.Control.ParameterCodeCurrent = base.Control.ModelCreate.ListParameter[base.Control.IndicatorCurrent].ParameterCode;
                    base.Control.ParameterNameCurrent = base.Control.ModelCreate.ListParameter[base.Control.IndicatorCurrent].ParameterName;
                    base.Control.OrderCurrent = base.Control.ModelCreate.ListParameter[base.Control.IndicatorCurrent].Order;
                    base.Control.LblParameterName().empty();
                    base.Control.LblParameterName().append(base.Control.ParameterNameCurrent);

                    base.Ajax.AjaxAdd.data = {
                        codeParameter: base.Control.ParameterCodeCurrent
                    };
                    base.Ajax.AjaxAdd.submit();
                };
            },

            BtnDeleteClick: function (e, args) {
                var button = $(e.target);

                if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete.id)) {
                    var columns = base.Control.GridResult.getView().getColumns();
                    var selectedColumn = columns[args.cell];
                    var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                    if (selectedColumn.id == "Delete") {
                        var records = base.Control.GridResult.getDataView().getItems();
                        var data = new Array();

                        for (var i = 0; i < records.length; i++) {
                            data.push(records[i].Code);
                        }

                        if (data.length > 0) {
                            var codeDelete = selectedRegistration.CodeParameter
                            if (codeDelete != null) {
                                data = $.grep(data, function (value) {
                                    return value != codeDelete;
                                });
                            }
                        }
                        base.Control.ListCodeParameter = data;
                        base.Function.GenerarGrid(Yanbal.SFT.Presentation.Web.Freight.Combination.Models.Create);
                    }
                }

                e.stopImmediatePropagation();
            },

            BtnSaveClick: function () {
                var records = base.Control.GridResult.getDataView().getItems();
                var data = new Array();

                for (var i = 0; i < records.length; i++) {
                    data.push(records[i].CodeParameter);
                }

                if (records.length > 0) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                combinationRequest: base.Control.ModelCreate.CombinationRegistration,
                                data: data
                            };
                            base.Ajax.AjaxSave.submit();
                        }
                    })
                }
                else {
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridNull });
                }
            },

            AjaxAddSuccess: function (data) {
                if (data != null || data != undefined) {
                    base.Control.ListParameterValueCurrent = data;
                    base.Control.ParametersRegistration.SlcParameterValue().find('option').remove();
                    base.Control.ParametersRegistration.SlcParameterValue().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelSelect));
                    $.each(data, function (index, value) {
                        base.Control.ParametersRegistration.SlcParameterValue().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.SatisfactorySaved });
                        if (base.Event.AjaxCreateParameterCombinationSuccessCustom != null) {
                            base.Event.AjaxCreateParameterCombinationSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelExistingParameter });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.FailedSaved });
                }
            }
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

            GenerateGrid: function () {
                base.Control.DivSearchResult().fadeIn();

                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();

                columns.push({
                    id: 'Delete', field: 'CodeParameter', width: 50, cssClass: 'center u-actions',
                    formater: function (row, cell, value, columnDef, dataContext) {
                        var cadena = '';
                        cadena += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete, base.Control.ModelCreate.Delete);
                        return cadena;
                    }
                });
                columns.push({
                    id: 'NameParameter', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridParameter, field: 'NameParameter', width: 100
                });
                columns.push({
                    id: 'Value', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridValue, field: 'Value', width: 100
                });
                columns.push({
                    id: 'DescriptionValue', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridValue, field: 'DescriptionValue', width: 100
                });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResultParameterCombination',
                    columns: columns,
                    width: 390,
                    height: 120,
                    forceFitColumns: true
                });

                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnDeleteClick);
            }
        };

        base.Ajax = {
            AjaxAdd: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.ChangeParameterValue,
                autoSubmit: false,
                onSuccess: base.Event.AjaxAddSuccess
            }),

            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.RegisterCombination,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            })
        };
    };
}
catch (ex) {
    alert(ex.message);
}