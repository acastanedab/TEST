/// <summary>
/// View Script para el index de Combinación
/// </summary>
/// <remarks>
/// Creacion: 	EJHF 05092014 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Freight.Simulator.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Presentation.Web.Freight.Simulator.Index.Page = new Yanbal.SFT.Presentation.Web.Freight.Simulator.Index.Controller();
        Yanbal.SFT.Presentation.Web.Freight.Simulator.Index.Page.Ini();
        //setActive('mdlFreight', 'mnuCombination');
    });
} catch (ex) {
    alert(ex.message);
}