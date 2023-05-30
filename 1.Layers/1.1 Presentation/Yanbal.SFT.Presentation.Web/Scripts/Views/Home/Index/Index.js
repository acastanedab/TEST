/// <summary>
/// Script de Vista
/// </summary>
/// <remarks>
/// Creación: GMD 20140716 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Web.Base.Home.Index');
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Web.Base.Home.Index.Page = new Yanbal.SFT.Web.Base.Home.Index.Controller();
        Yanbal.SFT.Web.Base.Home.Index.Page.Ini();
    });

} catch (ex) {
    alert(ex.message);
}