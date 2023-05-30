using System;
using System.Collections.Generic;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Parámetro Valor
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140622 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class ParameterValueRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterValueRequest()
        {
        }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? CodeParameter { get; set; }
        
        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Código de Sección
        /// </summary>
        public int? CodeSection { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Código del Valor
        /// </summary>
        public int? CodeValue { get; set; }
                
        /// <summary>
        /// Registro de Párametro en tipo Object
        /// </summary>
        public Dictionary<string, object> RecordValueObject { get; set; }

        /// <summary>
        /// Registro de Párametro en tipo String
        /// </summary>
        public Dictionary<string, string> RecordValueString { get; set; }
        /// <summary>
        /// Componente
        /// </summary>
        public int Component { get; set; }
        /// Nombre Componente
		/// </summary>
		public string ComponentName { get; set; }
        /// <summary>
        /// Codigo de Pais
        /// </summary>
        public string CountryCode { get; set; }
    }
}
