/// <summary>
/// Script de Controladora de la Vista de Modificación de Combinación de Parámetros
/// </summary>
/// <remarks>
/// Creación: GMD 20140909 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Freight.Combination.EditParameterCombination.Controller');
    Yanbal.SFT.Presentation.Web.Freight.Combination.EditParameterCombination.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxEditParameterCombinationSuccessCustom = (opts.AjaxEditParameterCombinationSuccessCustom) ? opts.AjaxEditParameterCombinationSuccessCustom : null;

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmEditParameterCombination',
                title: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.CombinationValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
                base.Control.BtnAdd().click(base.Event.BtnAddParameterClick);
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
                base.Function.GenerateGrid();
                base.Control.DivSearchResult().fadeIn();
                base.Control.ListParameterCombination = new Array();
                base.Control.ListParameterValueCurrent = base.Control.ModelEdit.ListParameterValue;
                
                var i = 0;
                while (base.Control.ModelEdit.ListParameterCombination.length > i) {
                    var parameterCombination = {
                        CodeParameter: null,
                        NameParameter: null,
                        Value: null,
                        DescriptionValue: null
                    };
                    parameterCombination.CodeParameter = base.Control.ModelEdit.ListParameterCombination[i].CodeParameter;
                    parameterCombination.NameParameter = base.Control.ModelEdit.ListParameterCombination[i].ParameterName;
                    parameterCombination.Value = base.Control.ModelEdit.ListParameterCombination[i].Value;
                    parameterCombination.DescriptionValue = base.Control.ModelEdit.ListParameterCombination[i].DescriptionValue;

                    base.Control.ListParameterCombination.push(parameterCombination);
                    i++;
                }

                base.Control.ParameterCodeCurrent = parameterCombination.CodeParameter;
                base.Control.ParameterNameCurrent = parameterCombination.NameParameter;

                base.Function.GenerateGrid();
                base.Control.GridResult.setData(base.Control.ListParameterCombination);

                if (base.Control.ModelEdit.ListParameter.length > i) {
                    base.Control.ParameterCodeCurrent = base.Control.ModelEdit.ListParameter[i].ParameterCode;
                    base.Control.ParameterNameCurrent = base.Control.ModelEdit.ListParameter[i].ParameterName;
                    base.Ajax.AjaxAdd.data = {
                        codeParameter: base.Control.ParameterCodeCurrent
                    };
                    base.Ajax.AjaxAdd.submit();
                    base.Control.DivParameterCombinationActive().show();
                    base.Control.DivParameterCombinationDisable().hide();
                } else {
                    base.Control.LblParameterName().empty();
                    base.Control.ParametersRegistration.SlcParameterValue().find('option').remove();
                    base.Control.DivParameterCombinationActive().hide();
                    base.Control.DivParameterCombinationDisable().show();
                }
            };

        };

        base.Control = {
            AjaxEditParameterCombinationSuccessCustom: null,
            Container: null,
            GridResult: null,
            ModelEdit: Yanbal.SFT.Presentation.Web.Freight.Combination.Models.EditParameterCombination,
            Message: new Yanbal.SFT.Web.Components.Message(),
            LblParameterName: function () { return $('#lblParameterNameEdit'); },
            BtnAdd: function () { return $('#btnAddEdit') },
            BtnSave: function () { return $('#btnSavePCEdit'); },
            BtnCancel: function () { return $('#btnCancelPCEdit'); },
            DivEdit: function () { return $('#divEditParameterCombination'); },
            DivSearchResult: function () { return $('#divSearchResultParameterCombinationEdit'); },
            DivParameterCombinationActive: function () { return $('#divParameterCombinationActiveEdit'); },
            DivParameterCombinationDisable: function () { return $('#divParameterCombinationDisableEdit'); },
            ListParameterCombination: null,
            ListParameterValueCurrent: null,
            ParameterCodeCurrent: null,
            ParameterNameCurrent: null,
            ParametersRegistration: {
                SlcParameterValue: function () { return $('#slcParameterValueEdit'); },
                TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
            }
        };

        base.Event = {
            BtnCancelClick: function () {
                base.Control.Container.close();
            },

            BtnAddParameterClick: function () {
                var codeParameter = base.Control.ParameterCodeCurrent;
                var nameParameter = base.Control.ParameterNameCurrent;
                var codeParameterValue = base.Control.ParametersRegistration.SlcParameterValue().val();
                var i = 0;
                while (base.Control.ListParameterValueCurrent.length > i && base.Control.ListParameterValueCurrent[i].Id != codeParameterValue) {
                    i++;
                }
                var nameParameterValue = base.Control.ListParameterValueCurrent[i].Name;

                parameterCombination = {
                    CodeParameter: null,
                    NameParameter: null,
                    Value: null,
                    DescriptionValue: null
                };

                parameterCombination.CodeParameter = codeParameter;
                parameterCombination.NameParameter = nameParameter;
                parameterCombination.Value = codeParameterValue;
                parameterCombination.DescriptionValue = nameParameterValue;

                base.Control.ListParameterCombination.push(parameterCombination);
                base.Function.GenerateGrid();
                base.Control.GridResult.setData(base.Control.ListParameterCombination);

                var item = 0;
                while (item < base.Control.ModelEdit.ListParameter.length) {
                    if (base.Control.ModelEdit.ListParameter[item].ParameterCode == parameterCombination.CodeParameter) {
                        base.Control.ParameterCodeCurrent = base.Control.ModelEdit.ListParameter[item].ParameterCode;
                        base.Control.ParameterNameCurrent = base.Control.ModelEdit.ListParameter[item].ParameterName;
                        break;
                    }
                    item++;
                }

                if (base.Control.ModelEdit.ListParameter.length > item + 1) {
                    base.Control.ParameterCodeCurrent = base.Control.ModelEdit.ListParameter[item + 1].ParameterCode;
                    base.Control.ParameterNameCurrent = base.Control.ModelEdit.ListParameter[item + 1].ParameterName;
                    base.Ajax.AjaxAdd.data = {
                        codeParameter: base.Control.ParameterCodeCurrent
                    };
                    base.Ajax.AjaxAdd.submit();
                } else {
                    base.Control.LblParameterName().empty();
                    base.Control.ParametersRegistration.SlcParameterValue().find('option').remove();
                    base.Control.DivParameterCombinationActive().hide();
                    base.Control.DivParameterCombinationDisable().show();
                }
            },

            BtnDeleteClick: function (e, args) {
                var button = $(e.target);
                if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete.id)) {
                    var columns = base.Control.GridResult.getView().getColumns();
                    var selectedColumn = columns[args.cell];
                    var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                    if (selectedColumn.id == "Delete") {
                        var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                        var item = 0;
                        var listParameterCombination = new Array();
                        while (item < base.Control.ListParameterCombination.length && base.Control.ListParameterCombination[item].CodeParameter != selectedRegistration.CodeParameter) {
                            listParameterCombination.push(base.Control.ListParameterCombination[item]);
                            item++;
                        }
                        var i = 0;
                        while (i < base.Control.ModelEdit.ListParameter.length) {
                            if (base.Control.ModelEdit.ListParameter[i].ParameterCode == selectedRegistration.CodeParameter) {
                                if (i > 0) {
                                    base.Control.ParameterCodeCurrent = base.Control.ModelEdit.ListParameter[i - 1].ParameterCode;
                                    base.Control.ParameterNameCurrent = base.Control.ModelEdit.ListParameter[i - 1].ParameterName;
                                }
                                else {
                                    base.Control.ParameterCodeCurrent = base.Control.ModelEdit.ListParameter[i].ParameterCode;
                                    base.Control.ParameterNameCurrent = base.Control.ModelEdit.ListParameter[i].ParameterName;
                                }
                                break;
                            }
                            i++;
                        }

                        base.Control.ListParameterCombination = listParameterCombination;
                        base.Function.GenerateGrid();
                        base.Control.GridResult.setData(base.Control.ListParameterCombination);

                        var j = 0;
                        while (j < base.Control.ModelEdit.ListParameter.length) {
                            if (base.Control.ModelEdit.ListParameter[j].ParameterCode == selectedRegistration.CodeParameter) {
                                base.Control.ParameterCodeCurrent = base.Control.ModelEdit.ListParameter[j].ParameterCode;
                                base.Control.ParameterNameCurrent = base.Control.ModelEdit.ListParameter[j].ParameterName;
                                break;
                            }
                            j++;
                        }

                        base.Control.IndicatorAdd = false;
                        base.Ajax.AjaxAdd.data = {
                            codeParameter: selectedRegistration.CodeParameter
                        };
                        base.Ajax.AjaxAdd.submit();

                        base.Control.DivParameterCombinationActive().show();
                        base.Control.DivParameterCombinationDisable().hide();
                    }
                }

                e.stopImmediatePropagation();
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    var records = base.Control.GridResult.getDataView().getItems();
                    if (records.length > 0) {
                        var parameterRegister = new Array();

                        for (var i = 0; i < records.length; i++) {
                            parameterRegister.push({ Key: records[i].CodeParameter, Value: records[i].Value });
                        }

                        base.Control.Message.Confirmation({
                            title: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelConfirmationHeader,
                            message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelSaveConfirmation,
                            onAccept: function () {
                                base.Ajax.AjaxSave.data = {
                                    CombinationCode: base.Control.ModelEdit.CodeCombination,
                                    ModificationReason: base.Control.ParametersRegistration.TxtModificationReason().val(),
                                    Parameter: parameterRegister
                                };
                                base.Ajax.AjaxSave.submit();
                            }
                        })
                    }
                    else {
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridNull });
                    }
                }
            },

            AjaxAddSuccess: function (data) {
                if (data != null || data != undefined) {
                    base.Control.ListParameterValueCurrent = data;
                    base.Control.LblParameterName().empty();
                    base.Control.LblParameterName().append(base.Control.ParameterNameCurrent);
                    base.Control.ParametersRegistration.SlcParameterValue().find('option').remove();
                    $.each(data, function (index, value) {
                        base.Control.ParametersRegistration.SlcParameterValue().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.SatisfactorySaved });
                        if (base.Event.AjaxEditParameterCombinationSuccessCustom != null) {
                            base.Event.AjaxEditParameterCombinationSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelExistingParameter });
                        break;
                    case "4":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelParameterInvalidRange });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.FailedSaved });
                        break;
                }
            },
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
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var cadena = '';
                        if (value == base.Control.ParameterCodeCurrent) {
                            cadena += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete, base.Control.ModelEdit.Delete);
                        }
                        return cadena;
                    }
                });
                columns.push({
                    id: 'NameParameter', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridParameter, field: 'NameParameter', width: 100
                });
                columns.push({
                    id: 'Value', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridValue, field: 'Value', width: 100, cssClass: 'center u-actions'
                });
                columns.push({
                    id: 'DescriptionValue', name: Yanbal.SFT.Presentation.Web.Freight.Combination.Resources.LabelGridDescription, field: 'DescriptionValue', width: 150
                });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResultParameterCombinationEdit',
                    columns: columns,
                    width: 500,
                    heightMax: 120,
                    forceFitColumns: true,
                    isPager: true,
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
                action: Yanbal.SFT.Presentation.Web.Freight.Combination.Actions.ModifyParameterCombination,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            })
        };
    };
}
catch (ex) {
    alert(ex.message);
}