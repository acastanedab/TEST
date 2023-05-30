using System.Web.Mvc;

namespace Yanbal.SFT.Presentation.Web.Areas.General
{
    /// <summary>
    /// Clase que representa el Area General
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class GeneralAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public GeneralAreaRegistration()
        {
        }

        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "General";
            }
        }

        /// <summary>
        /// Método que Registra una Area
        /// </summary>
        /// <param name="context">Contexto del Area</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "General_default",
                "General/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
