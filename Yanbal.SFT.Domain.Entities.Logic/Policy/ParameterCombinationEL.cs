using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Combinación Parámetro 
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140904 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterCombinationEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterCombinationEL()
        {
        }

        /// <summary>
        /// Código de Combinación Parámetro
        /// </summary>
        public int CodeParameterCombination { get; set; }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int CodeCombination { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodeParameter { get; set; }

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Nombre del Parámetro
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Tipo de Parámetro
        /// </summary>
        public string ParameterType { get; set; }

        /// <summary>
        /// Descripción del Valor
        /// </summary>
        public string DescriptionValue { get; set; }

        /// <summary>
        /// Orden de Combinación
        /// </summary>
        public byte CombinationOrder { get; set; }

        /// <summary>
        /// Improte de Flete
        /// </summary>
        public decimal AmountFreight { get; set; }
        
        /// <summary>
        /// Valor de Parámetro
        /// </summary>
        public string Value { get; set; }
    }
}
