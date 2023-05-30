/// <summary>
/// View Script para el index de Unidad de Negocio
/// </summary>
/// <remarks>
/// Creación: GMD 20140917 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.BusinessUnit.Index.Page.Ini();
        //setActive('mdlPolicy', 'mnuBusinessUnit');
    });
} catch (ex) {
    alert(ex.message);
}