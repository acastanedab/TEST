/// <summary>
/// View Script para el index de Orden de Combinación
/// </summary>
/// <remarks>
/// Creación: GMD 20140910 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Index');
try {
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Index.Page = new Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Index.Controller();
        Yanbal.SFT.Presentation.Web.Freight.FormulaOrder.Index.Page.Ini();
        //setActive('mdlPolitica', 'mnuGrupoConsultora');
    });
} catch (ex) {
    alert(ex.message);
}