using System;
using System.Collections.Generic;
using System.Data;
using Yanbal.SFT.Domain.Entities.Policy.Combination;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Combinación Parámetro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140904 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class ParameterCombinationRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterCombinationRequest()
        {
        }

        /// <summary>
        /// Código de Combinación Parámetro
        /// </summary>
        public int? CodeParameterCombination { get; set; }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int? CodeCombination { get; set; }

        /// <summary>
        /// Codigo de Unidad de Negocio
        /// </summary>
        public int? BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? CodeParameter { get; set; }

        /// <summary>
        /// Orden de Combinación
        /// </summary>
        public byte? OrderCombination { get; set; }

        /// <summary>
        /// Valor de Parámetro
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Estado de Registro de la Combinación
        /// </summary>
        public string RegistrationStatusCombination { get; set; }

        /// <summary>
        /// Lista de codigos de combinacion
        /// </summary>
        public List<CombinationTableEN> CodeCombinationList { get; set; }

        /// <summary>
        /// Indica si la combinacion de parametros sera usado para el servicio.
        /// </summary>
        public bool IsForService { get; set; }
    }
}
