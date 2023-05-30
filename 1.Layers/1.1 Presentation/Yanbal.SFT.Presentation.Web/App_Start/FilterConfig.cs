using System.Web;
using System.Web.Mvc;

namespace Yanbal.SFT.Presentation.Web
{
    /// <summary>
    /// Clase que representa la Configuracion de Filtro
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FilterConfig
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        protected FilterConfig()
        {
        }

        /// <summary>
        /// Clase estatica que Registra Filtros Golbales
        /// </summary>
        /// <param name="filters">Filtro</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}