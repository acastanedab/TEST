using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad de Lógica que representa la Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CombinationOrderEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationOrderEL()
        {
        }

        /// <summary>
        /// Código de Orden de Combinación
        /// </summary>
        public int OrderCodeCombination { get; set; }
        
        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int ParameterCode { get; set; }        

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Nombre de Parámetro
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Orden del Párametro en la Combinación
        /// </summary>
        public byte Order { get; set; }
    }
}
