/// <summary>
/// Script de Controladora de la Vista de Creación de Unidades de Negocio
/// </summary>
/// <remarks>
/// Creación: GMD 20140917 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Create.Controller');
    Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Create.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxCreateSuccessCustom = (opts.AjaxCreateSuccessCustom) ? opts.AjaxCreateSuccessCustom : null;
            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmCreateBusinessUnit',
                title: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.BusinessUnitValidation.Message.Resources
            });

            if (base.Function.ApplyBinding(base.Control.ModelCreate, base.Control.Container.getMainContainer())) {
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            };
        };

        base.Control = {
            AjaxCreateSuccessCustom: null,
            Container: null,
            ModelCreate: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Models.Create,
            Message: new Yanbal.SFT.Web.Components.Message(),
            BtnSave: function () { return $('#btnSaveCreate'); },
            BtnCancel: function () { return $('#btnCancelCreate'); },
            DivCreate: function () { return $('#divCreateBusinessUnit'); },
            ParametersRegistration: {
                TxtCountry: function () { return $('#slcCountryCreate'); },
                TxtBusinessUnitName: function () { return $('#txtBusinessUnitNameCreate'); },
                TxtAddress: function () { return $('#txtAddressCreate'); }
            }
        };

        base.Event = {
            EnterKeyPress: function (event) {
                var key = getKeyCode(event);
                var isValid = !(event && key == 13);
                if (isValid == false) {
                    base.Event.BtnSaveClick();
                }
                return isValid;
            },

            BtnCancelClick: function () {
                base.Control.Container.close();
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            base.Ajax.AjaxSave.data = {
                                CountryCode: base.Control.ParametersRegistration.TxtCountry().val(),
                                Name: base.Control.ParametersRegistration.TxtCountry().find('option:selected').text(),
                                BusinessUnitName: base.Control.ParametersRegistration.TxtBusinessUnitName().val(),
                                Address: base.Control.ParametersRegistration.TxtAddress().val()
                            };
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.SatisfactorySaved });
                        if (base.Event.AjaxCreateSuccessCustom != null) {
                            base.Event.AjaxCreateSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.LabelExistingBusinessUnit });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Resources.FailedSaved });
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
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
                }
                return isValid;
            }
        };

        base.Ajax = {
            AjaxSave: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Actions.RegisterBusinessUnit,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            })
        };
    };
}
catch (ex) {
    alert(ex.message);
}