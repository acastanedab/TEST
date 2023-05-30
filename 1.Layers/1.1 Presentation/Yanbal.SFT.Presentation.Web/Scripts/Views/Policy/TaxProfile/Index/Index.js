
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Index');
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.TaxProfile.Index.Page.Ini();
    });
} catch (ex) {
    alert(ex.message);
}