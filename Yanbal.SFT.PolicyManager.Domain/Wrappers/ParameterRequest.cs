using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class ParameterRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterRequest()
        {
        }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int? CodeParameter { get; set; }
        
        /// <summary>
        /// Código de Parámetro Digitado
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Código de Parámetro Digitado Aproximado
        /// </summary>
        public string CodeApproximate { get; set; }
        
        /// <summary>
        /// Nombre de Parámetro
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Descripción de Parámetro
        /// </summary>
        public string ParameterDescription { get; set; }

        /// <summary>
        /// Tipo de Parametro
        /// </summary>
        public string CodeParameterType { get; set; }

        /// <summary>
        /// Indicador de Parámetro de Sistema
        /// </summary>
        public bool? ParameterSystemIndicator { get; set; }
        
        /// <summary>
        /// Permite Agregar Valor
        /// </summary>
        public bool? AllowAddValueIndicator { get; set; }

        /// <summary>
        /// Permite Modificar Valor 
        /// </summary>
        public bool? AllowModifyValueIndicator { get; set; }

        /// <summary>
        /// Etiqueta de Código Sección
        /// </summary>
        public string LabelCodeSection { get; set; }

        /// <summary>
        /// Etiqueta de Descripción Sección
        /// </summary>
        public string LabelDescriptionSection { get; set; }

        /// <summary>
        /// Etiqueta de Inicio Sección
        /// </summary>
        public string LabelBeginSection { get; set; }

        /// <summary>
        /// Label de Fin Section
        /// </summary>
        public string LabelEndSection { get; set; }
    }
}
