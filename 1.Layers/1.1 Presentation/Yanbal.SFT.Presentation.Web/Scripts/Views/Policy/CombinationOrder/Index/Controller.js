/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: GMD 20140910 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Index.Controller');
    Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Index.Controller = function () {
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
                form: 'frmCombinationOrderIndex',
                title: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.CombinationOrderValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Models.Index)) {
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Models.Index);
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
            Message: new Yanbal.SFT.Web.Components.Message(),
            CurrentRecord:null,
            EditionForm: null,
            GridResult: null,
            FormFiltersSearch: function () { return $('#frmCombinationOrderIndex'); },
            DivSearchResult: function () { return $('#divSearchResult'); },
            BtnSave: function () { return $('#btnSaveCreate'); },
            ParametersRegistration: {
                TxtParameter: function () { return $('#slcParameter'); }
            }
        };

        base.Event = {
            BtnSearchClick: function () {
                base.Parameters.Search = {

                };
                base.Function.ExecuteQuery();
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message = new Yanbal.SFT.Web.Components.Message();
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                ParameterCode: base.Control.ParametersRegistration.TxtParameter().val(),
                            };
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.SatisfactorySaved });
                        if (base.Event.AjaxCreateSuccessCustom != null) {
                            base.Event.AjaxCreateSuccessCustom(data);
                        }
                        base.Event.BtnSearchClick();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.LabelExistingParameter });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.FailedSaved });
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
                                orderCodeCombination: selectedRegistration.OrderCodeCombination
                            },
                            action: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Actions.Edit,
                            onSuccess: base.Event.ModalEditSuccess
                        });
                    }
                }
                e.stopImmediatePropagation();
            },

            ModalEditSuccess: function (data) {
                base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Edit.Controller();
                base.Control.EditionForm.Ini({
                    Container: base.Control.ModalEdit,
                    AjaxEditSuccessCustom: base.Event.DialogAjaxEditSuccess
                });
            },

            DialogAjaxEditSuccess: function (data) {
                base.Event.BtnSearchClick();
            },
        };

        base.Ajax = {
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Actions.RegisterCombinationOrder,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
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

            ExecuteQuery: function () {
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Models.Index);
                base.Control.GridResult.load();
            },

            GenerateGrid: function (model) {
                if (base.Control.GridResult != null) {
                    base.Control.GridResult.destroy();
                }

                var columns = new Array();
                columns.push({
                    id: 'Edit', name: '', field: 'OrderCodeCombination', width: 5, cssClass: 'center u-actions',
                    Formater: function (row, cell, value, columnDef, dataContext) {
                        var string = '';
                        //if (dataContext.id=model.CountRecord) {
                        //}
                        if (value == base.Control.CurrentRecord)
                        {
                            string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Delete, model.Edit);
                        }
                        return string;
                    }
                });

                columns.push({ id: 'Order', name: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.LabelGridOrder, field: 'Order', width: 30, cssClass: 'center' });
                columns.push({ id: 'ParameterName', name: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Resources.LabelGridParameter, field: 'ParameterName', width: 300 });

                base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                    renderTo: 'grdResult',
                    isPager: true,
                    isServerPaging: true,
                    proxy: {
                        action: Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Actions.Search,
                        data: base.Parameters.Search
                    },
                    onLoad: function (data) {
                        if (data != null && data.length > 0)
                        {
                            base.Control.CurrentRecord = data[data.length - 1].OrderCodeCombination;
                            base.Control.GridResult.setData(data);
                        }
                    },
                    columns: columns,
                    forceFitColumns: true,
                    width: '100%',
                });
                base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
            }
        }
    };
}
catch (ex) {
    alert(ex.message);
}