using System.Web.Mvc;

namespace Yanbal.SFT.Presentation.Web.Areas.Freight
{
    /// <summary>
    /// Clase que representa la Configuración de Area
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FreightAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FreightAreaRegistration()
        {
        }

        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Freight";
            }
        }

        /// <summary>
        /// Método publico que Registra el Area
        /// </summary>
        /// <param name="context">Contexto</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Freight_default",
                "Freight/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
