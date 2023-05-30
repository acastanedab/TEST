using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Custom;

namespace Yanbal.SFT.FreightManagement.Common.Response
{
    /// <summary>
    /// Objeto que representa el resultado del Proceso
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ProcessResult<T> where T : class
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ProcessResult()
        {
        }

        /// <summary>
        /// Indicador de Conformidad del Error
        /// </summary>
        public bool IsSuccess  { get; set; }
        
        /// <summary>
        /// Resultado del Proceso
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Excepción Personalizada del error Ocurrido
        /// </summary>
        public CustomException Exception { get; set; }
    }
}
