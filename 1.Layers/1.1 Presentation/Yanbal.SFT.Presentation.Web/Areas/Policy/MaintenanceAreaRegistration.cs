using System.Web.Mvc;

namespace Yanbal.SFT.Presentation.Web.Areas.Maintenance
{
    /// <summary>
    /// Clase que representa el Mantenimiento de Area
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class MaintenanceAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public MaintenanceAreaRegistration()
        {
        }

        /// <summary>
        /// Nombre de Area
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Policy";
            }
        }

        /// <summary>
        /// Método que Registra una Area
        /// </summary>
        /// <param name="context">Contexto del Area</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Policy_default",
                "Policy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
