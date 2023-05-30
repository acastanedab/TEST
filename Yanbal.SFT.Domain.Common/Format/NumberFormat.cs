using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.Format
{
    /// <summary>
    /// Clase de dominio de formato número
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140710 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class NumberFormat
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public NumberFormat()
        {
        }

        /// <summary>
        /// Separador de  Número Decimal 
        /// </summary>
        public string NumberDecimalSeparator { get; set; }

        /// <summary>
        /// Separador de Grupo de Número 
        /// </summary>
        public string NumberGroupSeparator { get; set; }
    }
}
