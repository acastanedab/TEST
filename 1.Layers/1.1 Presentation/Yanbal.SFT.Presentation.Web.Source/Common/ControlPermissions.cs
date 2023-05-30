using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Common
{
    /// <summary>
    /// Clase básica de permisos de control
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140717 <br />
    /// Modificación: 
    /// </remarks>
    public class ControlPermissions
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ControlPermissions()
        {
        }

        /// <summary>
        /// Activado
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }
    }
}
