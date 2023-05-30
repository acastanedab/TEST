using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Párametro Valor
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140822<br />
    /// Modificación: 
    /// </remarks>
    public class ParameterValueEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterValueEL()
        {
        }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodeParameter { get; set; }

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }        

        /// <summary>
        /// Código de Valor
        /// </summary>
        public int CodeValue { get; set; }

        /// <summary>
        /// Código de tipo párametro
        /// </summary>
        public string CodeParameterType { get; set; }

        /// <summary>
        /// Registro de Párametro en tipo Object
        /// </summary>
        public Dictionary<string, object> RecordValueObject { get; set; }

        /// <summary>
        /// Registro de Párametro en tipo String
        /// </summary>
        public Dictionary<string, string> RecordValueString { get; set; }

        /// <summary>
        /// Código de Parámetro Sección
        /// </summary>
        public int CodeSection { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public string Value { get; set; }
    }
}
