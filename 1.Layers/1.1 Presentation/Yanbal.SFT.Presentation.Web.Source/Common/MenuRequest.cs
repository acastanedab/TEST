using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Common
{
    /// <summary>
    /// Request que representa a Menú
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140920 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class MenuRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public MenuRequest()
        {
        }

        /// <summary>
        /// Lista de Menu Principal
        /// </summary>
        public List<MenuResult> MyMenu { get; set; }
    }
}
