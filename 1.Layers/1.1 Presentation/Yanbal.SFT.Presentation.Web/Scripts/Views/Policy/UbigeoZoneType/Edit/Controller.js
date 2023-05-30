/// <summary>
/// Script de Controladora de la Vista de Edición de Tipos de Zonas de Ubigeo
/// </summary>
/// <remarks>
/// Creación: GMD 20140829 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Edit.Controller');
Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Edit.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        debugger
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxEditSuccessCustom = (opts.AjaxEditSuccessCustom) ? opts.AjaxEditSuccessCustom : null;
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmEditUbigeoZoneType',
            title: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelConfirmationHeader,
            messages: Yanbal.SFT.Presentation.Web.UbigeoZoneTypeValidation.Message.Resources,
        });
        
        if (base.Function.ApplyBinding(base.Control.ModelEdit, base.Control.Container.getMainContainer())) {
            base.Control.BtnSave().click(base.Event.BtnSaveClick);
            base.Control.BtnCancel().click(base.Event.BtnCancelClick);
            base.Control.ParametersRegistration.TxtCodeLevel1().change(base.Event.ZoneLevel1);
            base.Control.ParametersRegistration.TxtCodeLevel2().change(base.Event.ZoneLevel2);
            base.Control.ParametersRegistration.TxtCodeLevel3().change(base.Event.ZoneLevel3);
            base.Control.ParametersRegistration.LblCodeUbigeo().append(base.Control.ModelEdit.CodeZone);
        };
    };

    base.Parameters = {

    };

    base.Control = {
        AjaxEditSuccessCustom: null,
        Container: null,
        ModelEdit: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Models.Edit,
        Message: new Yanbal.SFT.Web.Components.Message(),
        BtnSave: function () { return $('#btnSaveEdit'); },
        BtnCancel: function () { return $('#btnCancelEdit'); },
        ParametersRegistration: {
            LblCodeUbigeo: function () { return $('#lblCodeUbigeoEdit'); },
            TxtCodeCountry: function () { return $('#slcCodeCountryEdit'); },
            TxtCodeLevel1: function () { return $('#slcLevel1Edit'); },
            TxtCodeLevel2: function () { return $('#slcLevel2Edit'); },
            TxtCodeLevel3: function () { return $('#slcLevel3Edit'); },
            TxtCodeZoneType: function () { return $('#slcZoneTypeEdit'); },
            TxtRegistrationStatus: function () { return $('#slcRegistrationStatusEdit'); },
            TxtModificationReason: function () { return $('#txtModificationReasonEdit'); }
        }

    };

    base.Event = {
        EventEnterKeyPress: function (event) {
            var key = getKeyCode(event);
            if (key == 13) {
                base.Event.BtnSaveClick();
            }
        },

        ZoneLevel1: function () {
            base.Ajax.AjaxChangeZoneLevel1.data = {
                codeZoneLevel1: base.Control.ParametersRegistration.TxtCodeLevel1().val()
            };            
            base.Ajax.AjaxChangeZoneLevel1.submit();
        },

        ZoneLevel2: function () {
            base.Ajax.AjaxChangeZoneLevel2.data = {
                codeZoneLevel1: base.Control.ParametersRegistration.TxtCodeLevel1().val(),
                codeZoneLevel2: base.Control.ParametersRegistration.TxtCodeLevel2().val()
            };
            base.Ajax.AjaxChangeZoneLevel2.submit();
        },

        ZoneLevel3: function () {
            base.Control.ParametersRegistration.LblCodeUbigeo().empty();
            var zoneCode = base.Control.ParametersRegistration.TxtCodeLevel3().val();

            if (zoneCode == null || zoneCode.trim() == "") {
                zoneCode = base.Control.ParametersRegistration.TxtCodeLevel2().val();
            }
            base.Control.ParametersRegistration.LblCodeUbigeo().append(zoneCode);
        },

        BtnCancelClick: function () {
            base.Control.Container.close();
        },

        BtnSaveClick: function () {
            if (base.Control.Validator.isValid()) {
                base.Control.Message.Confirmation({
                    title: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelConfirmationHeader,
                    message: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSaveConfirmation,
                    onAccept: function () {
                        base.Ajax.AjaxSave.data = {
                            CodeTypeZoneUbigeo: base.Control.ModelEdit.CodeTypeZoneUbigeo,
                            CodeCountry: base.Control.ModelEdit.CodeCountry,
                            CodeLevel1: base.Control.ParametersRegistration.TxtCodeLevel1().val(),
                            CodeLevel2: base.Control.ParametersRegistration.TxtCodeLevel2().val(),
                            CodeLevel3: base.Control.ParametersRegistration.TxtCodeLevel3().val(),
                            CodeTypeZone: base.Control.ParametersRegistration.TxtCodeZoneType().val(),
                            ModificationReason: base.Control.ParametersRegistration.TxtModificationReason().val(),
                            RegistrationStatus: base.Control.ParametersRegistration.TxtRegistrationStatus().val()
                        };
                        base.Ajax.AjaxSave.submit();
                    }
                });
            }
        },

        AjaxSaveSuccess: function (data) {
            switch (data) {
                case "1":
                    base.Control.Message.Information({ message: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.SatisfactorySaved });
                    if (base.Event.AjaxEditSuccessCustom != null) {
                        base.Event.AjaxEditSuccessCustom(data);
                    }
                    base.Control.Container.close();
                    break;
                case "3":
                    base.Control.Message.Warning({ message: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelExistingZone });
                    break;
                default:
                    base.Control.Message.Error({ message: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.FailedSaved });
            }
        },

        AjaxChangeZoneLevel1Success: function (data) {
            base.Control.ParametersRegistration.TxtCodeLevel2().find('option').remove();
            base.Control.ParametersRegistration.TxtCodeLevel2().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSelect));
            base.Control.ParametersRegistration.TxtCodeLevel3().find('option').remove();
            base.Control.ParametersRegistration.TxtCodeLevel3().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSelect));
            
            if (base.Control.ParametersRegistration.TxtCodeLevel1().val() != null && base.Control.ParametersRegistration.TxtCodeLevel1().val() != "") {
                if (data != null || data != undefined) {
                    $.each(data, function (index, value) {
                        base.Control.ParametersRegistration.TxtCodeLevel2().append($("<option />").val(value.Id).text(value.Name));
                    });
                }
            }
            base.Control.ParametersRegistration.LblCodeUbigeo().empty();
            var zoneCode = base.Control.ParametersRegistration.TxtCodeLevel1().val();

            if (zoneCode == null || zoneCode.trim() == "") {
                zoneCode = base.Control.ModelEdit.CodeCountry;
            }
            base.Control.ParametersRegistration.LblCodeUbigeo().append(zoneCode);
        },

        AjaxChangeZoneLevel2Success: function (data) {
            base.Control.ParametersRegistration.TxtCodeLevel3().find('option').remove();
            base.Control.ParametersRegistration.TxtCodeLevel3().append($("<option />").val('').text(Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Resources.LabelSelect));        
            if (data != null || data != undefined) {
                $.each(data, function (index, value) {
                    base.Control.ParametersRegistration.TxtCodeLevel3().append($("<option />").val(value.Id).text(value.Name));
                });
            }
            base.Control.ParametersRegistration.LblCodeUbigeo().empty();
            var zoneCode = base.Control.ParametersRegistration.TxtCodeLevel2().val();

            if (zoneCode == null || zoneCode.trim() == "") {
                zoneCode = base.Control.ParametersRegistration.TxtCodeLevel1().val();
            }
            base.Control.ParametersRegistration.LblCodeUbigeo().append(zoneCode);
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
                action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.ModifyUbigeoZoneType,
                autoSubmit: false,
                onSuccess: base.Event.AjaxSaveSuccess
            }),

            AjaxChangeZoneLevel1: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.ChangeZoneLevel1,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeZoneLevel1Success
            }),

            AjaxChangeZoneLevel2: new Yanbal.SFT.Web.Components.Ajax({
                action: Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Actions.ChangeZoneLevel2,
                autoSubmit: false,
                onSuccess: base.Event.AjaxChangeZoneLevel2Success
            })
        };
};