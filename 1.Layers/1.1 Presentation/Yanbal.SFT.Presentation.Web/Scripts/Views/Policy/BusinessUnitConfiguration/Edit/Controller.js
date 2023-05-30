/// <summary>
/// Script de Controladora de la Vista de Creación de Configuración de Unidad de Negocio
/// </summary>
/// <remarks>
/// Creación: GMD 20140919 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Edit.Controller');
    Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Edit.Controller = function () {
        var base = this;
        base.Ini = function (opts) {
            'use strict';
            base.Control.Container = opts.Container;
            base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;

            base.Control.Dialog = new Yanbal.SFT.Web.Components.Dialog({
                autoOpen: false,
                height: 500,
                width: 450,
                modal: true
            });

            base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
                form: 'frmEditBusinessUnitConfiguration',
                title: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelConfirmationHeader,
                messages: Yanbal.SFT.Presentation.Web.BusinessUnitConfigurationValidation.Message.Resources
            });

            base.Control.FileUploadCompanyLogo = new Yanbal.SFT.Web.Components.FileUpload({
                renderTo: 'CompanyImageUploadEdit'
            });

            base.Control.FileUploadReportLogo = new Yanbal.SFT.Web.Components.FileUpload({
                renderTo: 'ReportImageUploadEdit'
            });

            if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
                base.Control.BtnSave().click(base.Event.BtnSaveClick);
                base.Control.BtnCancel().click(base.Event.BtnCancelClick);
                base.Control.ParametersRegistration.TxtRowsPerPage().keypress(base.Event.OnlyNumbers);
                base.Control.ParametersRegistration.TxtCharactersMinimumGloss().keypress(base.Event.OnlyNumbers);
                base.Control.ParametersRegistration.TxtVowelsMinimumGloss().keypress(base.Event.OnlyNumbers);
                base.Control.ParametersRegistration.TxtVowelsMinimumGloss().keypress(base.Event.EnterKeyPress);
                base.Control.ParametersRegistration.TxtCharactersMinimumGloss().keypress(base.Event.EnterKeyPress);
            };
        };

        base.Control = {
            Dialog: null,
            BtnLoad: function () { return $('#btnFileUploadEdit'); },
            FileUploadCompanyLogo: null,
            FileUploadReportLogo: null,
            AjaxEditSuccessCustom: null,
            Container: null,
            ModelEdit: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Models.Edit,
            Message: new Yanbal.SFT.Web.Components.Message(),
            BtnSave: function () { return $('#btnSaveEdit'); },
            BtnCancel: function () { return $('#btnCancelEdit'); },
            DivEdit: function () { return $('#divEditBusinessUnit'); },
            ParametersRegistration: {
                TxtCulture: function () { return $('#slcCultureEdit'); },
                TxtTimeZone: function () { return $('#slcTimeZoneEdit'); },
                TxtDisplayFormReport: function () { return $('#slcDisplayFormReportEdit'); },
                TxtCompanyImage: function () { return $('#CompanyImageUploadEdit'); },
                TxtReportImage: function () { return $('#ReportImageUploadEdit'); },
                TxtRowsPerPage: function () { return $('#txtRowsPerPageEdit').spinner({ min: 1, max: 255 }); },
                TxtCharactersMinimumGloss: function () { return $('#txtCharactersMinimumGlossEdit').spinner({ max: 100 }); },
                TxtVowelsMinimumGloss: function () { return $('#txtVowelsMinimumGlossEdit').spinner({ max: 100 }); },
                ChkAcquiringMainMenu: function () { return $('#chkAcquiringMainMenuEdit'); },
                TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
                TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
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

            OnlyNumbers: function (e) {
                var key = getKeyCode(e);
                var isValid = !(e && key == 13);
                if (isValid) {
                    isValid = validateOnlyNumbers(e);
                } else {
                    base.Event.BtnSaveClick();
                }
                return isValid;
            },

            BtnLoadClick: function () {
                var files = base.Control.FileUpload.getFiles();
                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }
                base.Ajax.AjaxLoad.data = data;
            },

            BtnCancelClick: function () {
                base.Control.Container.close();
            },

            BtnSaveClick: function () {
                if (base.Control.Validator.isValid()) {
                    base.Control.Message.Confirmation({
                        title: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelConfirmationHeader,
                        message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelSaveConfirmation,
                        onAccept: function () {
                            var data = new FormData();
                            var fileCompanyLogo = base.Control.FileUploadCompanyLogo.getFile();
                            var fileReportLogo = base.Control.FileUploadReportLogo.getFile();
                            data.append('fileCompanyLogo', fileCompanyLogo);
                            data.append('fileReportLogo', fileReportLogo);

                            data.append('businessUnitConfiguration', JSON.stringify({
                                BusinessUnitConfigurationCode: base.Control.ModelEdit.BusinessUnitConfigurationCode,
                                BusinessUnitCode: base.Control.ModelEdit.BusinessUnitCode,
                                DisplayFormReport: base.Control.ParametersRegistration.TxtDisplayFormReport().val(),
                                RowsPerPage: base.Control.ParametersRegistration.TxtRowsPerPage().val(),
                                RegistrationStatus: base.Control.ParametersRegistration.TxtRegistrationStatus().val(),
                                ModificationReason: base.Control.ParametersRegistration.TxtModificationReason().val()
                            }));

                            data.append('cultureCode', base.Control.ParametersRegistration.TxtCulture().val());
                            data.append('timeZoneCode', base.Control.ParametersRegistration.TxtTimeZone().val());
                            data.append('charactersMinimumGloss', base.Control.ParametersRegistration.TxtCharactersMinimumGloss().val());
                            data.append('vowelsMinimumGloss', base.Control.ParametersRegistration.TxtVowelsMinimumGloss().val());
                            data.append('indicatorAcquiringMainMenu', base.Control.ParametersRegistration.ChkAcquiringMainMenu().is(':checked'));
                            data.append('vowelsMinimumGloss', base.Control.ParametersRegistration.TxtVowelsMinimumGloss().val());
                            base.Ajax.AjaxSave.data = data;
                            base.Ajax.AjaxSave.submit();
                        }
                    });
                }
            },

            AjaxSaveSuccess: function (data) {
                switch (data) {
                    case "1":
                        base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.SatisfactorySaved });
                        if (base.Event.AjaxEditSuccessCustom != null) {
                            base.Event.AjaxEditSuccessCustom(data);
                        }
                        base.Control.Container.close();
                        break;
                    case "3":
                        base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.LabelExistingBusinessUnit });
                        break;
                    default:
                        base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Resources.FailedSaved });
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
                action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.ModifyBusinessUnitConfiguration,
                autoSubmit: false,
                hasFile: true,
                contentType: false,
                processData: false,
                onSuccess: base.Event.AjaxSaveSuccess
            })
        };
    };
}
catch (ex) {
    alert(ex.message);
}