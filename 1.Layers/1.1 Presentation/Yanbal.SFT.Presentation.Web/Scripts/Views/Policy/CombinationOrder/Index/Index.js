/// <summary>
/// View Script para el index de Orden de Combinación
/// </summary>
/// <remarks>
/// Creación: GMD 20140910 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Index');
try {
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.CombinationOrder.Index.Page.Ini();
        //setActive('mdlPolitica', 'mnuGrupoConsultora');
    });
} catch (ex) {
    alert(ex.message);
}