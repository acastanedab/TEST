ns('Yanbal.SFT.Web.Security.Recaptcha.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Web.Security.Recaptcha.Page = new Yanbal.SFT.Web.Security.Recaptcha.Index.Controller();
        Yanbal.SFT.Web.Security.Recaptcha.Page.Ini();
    });

} catch (ex) {
    alert(ex.message);
}