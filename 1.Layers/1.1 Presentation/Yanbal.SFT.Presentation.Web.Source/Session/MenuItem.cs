using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Session
{
    /// <summary>
    /// Clase que contiene los items del Menú
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140828 <br />
    /// Modificación:
    /// </remarks>
    public class MenuItem
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public MenuItem()
        {
        }

        /// <summary>
        /// Código del Menú
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// Código de Módulo
        /// </summary>
        public string ParentMenuId{ get; set; }
        
        /// <summary>
        /// Código de Identificación del Menú
        /// </summary>
        public string MenuIdentificationCode { get; set; }
    }
}
