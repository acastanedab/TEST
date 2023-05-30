using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Yanbal.SFT.Presentation.Web
{
    /// <summary>
    /// Clase que representa las Aplicaciones Web
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public static class WebApiConfig
    {
        /// <summary>
        /// Clase  Estatica que Registra
        /// </summary>
        /// <param name="config">Configuración</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
