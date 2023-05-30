/// <summary>
/// View de la Vista Index del Parámetro Sección
/// </summary>
/// <remarks>
/// Creación: 	GMD 20140721 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Index');
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.ParameterSection.Index.Page.Ini();
        //setActive('mdlMantenimientoFletes', 'mnuParametro');
    });
} catch (ex) {
    alert(ex.message);
}