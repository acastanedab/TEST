/// <summary>
/// View Script para el index de Cultura
/// </summary>
/// <remarks>
/// Creación: GMD 20140922 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.Culture.Index');
try {
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.Culture.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.Culture.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.Culture.Index.Page.Ini();
        //setActive('mdlPolicy', 'mnuCulture');
    });

} catch (ex) {
    alert(ex.message);
}