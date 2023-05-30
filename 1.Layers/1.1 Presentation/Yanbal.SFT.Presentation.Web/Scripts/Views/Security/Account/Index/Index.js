/// <summary>
/// Script de Controladora de la Vista Index de Ingreso de Sistema
/// </summary>
/// <remarks>
/// Creación: GMD 20140828 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Security.Account.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Presentation.Web.Security.Account.Index.Page = new Yanbal.SFT.Presentation.Web.Security.Account.Index.Controller();
        Yanbal.SFT.Presentation.Web.Security.Account.Index.Page.Ini();
    });

} catch (ex) {
    alert(ex.message);
}