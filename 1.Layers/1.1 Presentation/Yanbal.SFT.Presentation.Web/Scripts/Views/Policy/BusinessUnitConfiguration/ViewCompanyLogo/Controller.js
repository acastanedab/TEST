ns('Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.ViewCompanyLogo');
Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.ViewCompanyLogo.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.Container = opts.Container;
        base.Event.AjaxVisualizeSuccessCustom = (opts.AjaxVisualizeSuccessCustom) ? opts.AjaxVisualizeSuccessCustom : null;
    };
    base.Control = {
        Validator: null,
        AjaxVisualizeSuccessCustom: null,
        Container: null,
    };
    base.Event = {
        BtnSearchClick: function () {
            base.Ajax.AjaxSearch.data = {
                businessUnitConfigurationCode: 1,
            };
            base.Ajax.AjaxSearch.submit();
        },
    }

    base.Ajax = {
        AjaxSearch: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.BusinessUnitConfiguration.Actions.ViewCompanyLogoImage,
            autoSubmit: false
        }),
    };
};