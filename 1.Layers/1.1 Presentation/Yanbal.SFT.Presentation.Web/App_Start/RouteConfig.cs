using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Yanbal.SFT.Presentation.Web
{
    /// <summary>
    /// Clase que representa Configura la Ruta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class RouteConfig
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        protected RouteConfig()
        {
        }

        /// <summary>
        /// Clase Estatica que registra Rutas
        /// </summary>
        /// <param name="routes">Ruta</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

            var routersArea = routes.Where(r => r is Route).ToList();
            routersArea.ForEach(r =>
            {
                Route route = (Route)r;
                if (route != null && route.DataTokens != null && route.DataTokens.ContainsKey("Namespaces"))
                {
                    route.DataTokens["Namespaces"] = "Yanbal.SFT.Presentation.Web.Source.Controllers.*";
                }
            });

        }
    }
}