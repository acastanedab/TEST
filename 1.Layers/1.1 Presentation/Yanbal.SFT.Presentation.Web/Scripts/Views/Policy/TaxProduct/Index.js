/// <summary>
///  Vista de script para el index de Impuesto por tipo de producto
/// </summary>
/// <remarks>
/// Creacion: 	PBG 26082014 <br />
/// </remarks>
try {
    ns('Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Index');
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.TaxProduct.Index.Page.Ini();
        //setActive('mdlTaxProduct', 'mnuPolicy');
    });
} catch (ex) {
    alert(ex.message);
}