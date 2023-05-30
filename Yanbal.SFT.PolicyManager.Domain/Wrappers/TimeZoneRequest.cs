using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Zona Horaria
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140922 <br />
    /// Modificación:          <br />
    /// </remarks>
    [Serializable]
    public class TimeZoneRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public TimeZoneRequest()
        {
        }

        /// <summary>
        /// Código de Zona Horaria
        /// </summary>
        public int TimeZoneCode { get; set; }

        /// <summary>
        /// Hora UTC
        /// </summary>
        public short HourUtc { get; set; }

        /// <summary>
        /// Minutos UTC
        /// </summary>
        public short MinuteUtc { get; set; }

        /// <summary>
        /// Descripción de Zona Horaria
        /// </summary>
        public string Description { get; set; }
    }
}
