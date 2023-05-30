using System;
using Yanbal.SFT.FreightManagement.Common.Paging;

namespace Yanbal.SFT.FreightManagement.Common.Base
{
    /// <summary>
    /// Request que representa a los datos generales
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140731 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class BaseRequest : PagingFilter
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BaseRequest()
        {
        }

        /// <summary>
        /// Codigo de Unidad de Negocio
        /// </summary>
        public int? BusinessUnitCode { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UserCreation { get; set; }

        /// <summary>
        /// Terminal de Creación
        /// </summary>
        public string TerminalCreation { get; set; }

        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime? DateCreation { get; set; }

        /// <summary>
        /// Usuario de Modificación
        /// </summary>
        public string UserModification { get; set; }

        /// <summary>
        /// Terminal de Modificación
        /// </summary>
        public string TerminalModification { get; set; }

        /// <summary>
        /// Fecha de Modificación
        /// </summary>
        public DateTime? DateModification { get; set; }

        /// <summary>
        /// Motivo de Modificación
        /// </summary>
        public string ModificationReason { get; set; }
    }
}
