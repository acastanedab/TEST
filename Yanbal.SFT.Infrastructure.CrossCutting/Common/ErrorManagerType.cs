using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Common
{
    /// <summary>
    /// Clase de Administración de errores
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140910 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ErrorManagerType
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ErrorManagerType()
        {
        }

        /// <summary>
        /// numero error
        /// </summary>
        public int ErrorNumber { get; set; }  

        /// <summary>
        /// descripción
        /// </summary>
        public string Description    { get; set;}


        /// <summary>
        /// severidad
        /// </summary>
        public int Severity { get; set; }
    }
}
