/// <summary>
/// View Script para el index de Combinación
/// </summary>
/// <remarks>
/// Creacion: GMD 20140905 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Freight.Combination.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Presentation.Web.Freight.Combination.Index.Page = new Yanbal.SFT.Presentation.Web.Freight.Combination.Index.Controller();
        Yanbal.SFT.Presentation.Web.Freight.Combination.Index.Page.Ini();
        //setActive('mdlFreight', 'mnuCombination');
    });
} catch (ex) {
    alert(ex.message);
}