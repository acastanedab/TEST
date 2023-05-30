/// <summary>
/// View de la Vista Index del Parámetro Sección 
/// </summary>
/// <remarks>
/// Creación: GMD 20140825 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Index');
try {
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.ParameterValue.Index.Page.Ini();
        //setActive('mdlPolitica', 'mnuParametroValor');
    });

} catch (ex) {
    alert(ex.message);
}