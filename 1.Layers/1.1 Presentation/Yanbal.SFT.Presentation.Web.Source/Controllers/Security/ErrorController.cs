using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Yanbal.SFT.Presentation.Web.Source.Controllers.Security
{
    /// <summary>
    /// Controladora de Error
    /// </summary>
    /// <remarks>
    /// Creación: 	GMD 20140918 <br />
    /// Modificación: 	 <br />
    /// </remarks>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ErrorController()
        {
        }

        #region ActionResult
        /// <summary>
        /// Muestra la vista principal de error
        /// </summary>
        /// <returns>Vista principal de error</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Muestra la vista de página no encontrada de la opción
        /// </summary>
        /// <param name="aspxerrorpath">Ruta de Vista</param>
        /// <returns>Vista de página no encontrada de la opción</returns>
        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewData["error_path"] = aspxerrorpath;
            return View();
        }

        /// <summary>
        /// Muestra la vista de acceso no autorizado de la opción
        /// </summary>
        /// <returns>Vista de acceso no autorizado de la opción</returns>
        public ActionResult NotAuthorized()
        {
            return View();
        }
        #endregion
    }
}
