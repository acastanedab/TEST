/// <summary>
/// Script de Vista 
/// </summary>
/// <remarks>
/// Creación: GMD 20141609 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.AuditReport.Index');
try {
    $(document).ready(function () {
        'use strict';
        Yanbal.SFT.Presentation.Web.Policy.AuditReport.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.AuditReport.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.AuditReport.Index.Page.Ini();
        //setActive('mdlPolitica', 'mnuReporteAuditoriaPoliticas');
    });
} catch (ex) {
    alert(ex.message);
}