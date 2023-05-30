using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Parámetro Sección
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ParameterSectionRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterSectionRequest()
        {
        }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? CodeParameter { get; set; }

        /// <summary>
        /// Código de Parámetro Sección
        /// </summary>
        public int? CodeParameterSection { get; set; }

        /// <summary>
        /// Nombre de Parámetro Sección
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es Solo de Lectura
        /// </summary>
        public bool? ReadOnlyIndicator { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es un dato Obligatorio a Registrar
        /// </summary>
        public bool? RequiredIndicator { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es un Valor Inicial o un Valor Final del Rango
        /// </summary>
        public string RangeIndicator { get; set; }    

        /// <summary>
        /// Indicador que determina si es una Sección creada automaticamente por el tipo de Parámetro
        /// </summary>
        public bool? CreationIndicator { get; set; }       

        /// <summary>
        /// Tipo de Parametro Sección
        /// </summary>
        public string CodeParameterSectionType { get; set; }

        /// <summary>
        /// Código de Parámetro de Tres Dígitos
        /// </summary>
        public string Code { get; set; }
    }
}
