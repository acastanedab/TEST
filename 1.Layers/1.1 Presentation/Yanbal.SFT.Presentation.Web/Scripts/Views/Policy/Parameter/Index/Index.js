/// <summary>
/// View Script para el index de Parámetros 
/// </summary>
/// <remarks>
/// Creacion: GMD 20140717 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.Parameter.Index');
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.Parameter.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.Parameter.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.Parameter.Index.Page.Ini();
        //setActive('mdlMantenimientoFletes', 'mnuParameter');
    });
} catch (ex) {
    alert(ex.message);
}