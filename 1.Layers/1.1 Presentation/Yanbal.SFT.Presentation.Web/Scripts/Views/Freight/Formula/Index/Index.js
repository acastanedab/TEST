/// <summary>
/// View Script para el index de Fórmula
/// </summary>
/// <remarks>
/// Creación: GMD 20140912 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Freight.Formula.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Presentation.Web.Freight.Formula.Index.Page = new Yanbal.SFT.Presentation.Web.Freight.Formula.Index.Controller();
        Yanbal.SFT.Presentation.Web.Freight.Formula.Index.Page.Ini();
        //setActive('mdlPolicy', 'mnuFormula');
    });
} catch (ex) {
    alert(ex.message);
}