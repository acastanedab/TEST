/// <summary>
/// View Script para el index de Tipo de Zona de Ubigeo 
/// </summary>
/// <remarks>
/// Creación: GMD 20140827 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Index');
try {
    $(document).ready(function () {
        'use strict';

        Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Index.Page = new Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Index.Controller();
        Yanbal.SFT.Presentation.Web.Policy.UbigeoZoneType.Index.Page.Ini();
        //setActive('mdlPolitica', 'mnuGrupoConsultora');
    });
} catch (ex) {
    alert(ex.message);
}