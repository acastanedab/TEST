using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.Models
{
    /// <summary>
    /// Clase Log4NetConfig
    /// </summary>
    public class Log4NetConfig
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Log4NetConfig()
        {
            RutasArchivoLog = new List<RutaNodo>();
        }
        /// <summary>
        /// Nombre Componente
        /// </summary>
        public string Componente { get; set; }
        /// <summary>
        /// Indicador DEBUG INTERNAL log4net
        /// </summary>
        public bool InternalDebug { get; set; }
        /// <summary>
        /// Indicador INFO
        /// </summary>
        public bool Info { get; set; }
        /// <summary>
        /// Indicador ERROR
        /// </summary>
        public bool Error { get; set; }
        /// <summary>
        /// Indicador DEBUG
        /// </summary>
        public bool Debug { get; set; }
        /// <summary>
        /// Listado RUTAS por NODO
        /// </summary>
        public List<RutaNodo> RutasArchivoLog { get; set; }
    }
    /// <summary>
    /// Clase RUTAS NODO
    /// </summary>
    public class RutaNodo
    {
        /// <summary>
        /// ID NODO del Componente
        /// </summary>
        public int IdNodo { get; set; }
        /// <summary>
        /// Ruta LOG NODO
        /// </summary>
        public string RutaArchivoLog { get; set; }
    }
}
