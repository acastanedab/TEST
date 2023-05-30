using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Combinación 
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140901 <br />
    /// Modificación: 
    /// </remarks>
    public class CombinationEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationEL()
        {
        }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int CombinationCode { get; set; }

        /// <summary>
        /// Importe de Flete
        /// </summary>
        public decimal AmountFreight  { get; set; }

        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string AmountFreightString { get; set; }

        /// <summary>
        /// Descripción de la Combinación
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Descripción de la Combinación
        /// </summary>
        public string SendType { get; set; }

        /// <summary>
        /// Lista de Parámetros de la Combinación
        /// </summary>
        public List<ParameterCombinationEL> ListParameterCombination { get; set; }
    }
}
