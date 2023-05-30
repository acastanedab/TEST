using System;
using System.Collections.Generic;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Combinacion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140810 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class CombinationRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationRequest()
        {
        }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int? CombinationCode { get; set; }

        /// <summary>
        /// Importe de Flete
        /// </summary>
        public decimal? AmountFreight  { get; set; }

        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string AmountFreightString { get; set; }
        
        /// <summary>
        /// Indicador que determina si se obtiene la descripcion de la combinación
        /// </summary>
        public bool GetParametersCombination { get; set; }
        
        /// <summary>
        /// Diccionario que contiene de el Parametro y su Valor
        /// </summary>
        public Dictionary<string,string> Parameter { get; set; }

        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }

        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string ParameterCode { get; set; }
        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string DescriptionParameterCode { get; set; }
        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string ParameterValue { get; set; }
        /// <summary>
        /// Importe de Flete con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string DescriptionParameterValue { get; set; }

        /// <summary>
        /// Indica si la combinacion sera usada para el servicio.
        /// </summary>
        public bool IsForService { get; set; }

    }
}
