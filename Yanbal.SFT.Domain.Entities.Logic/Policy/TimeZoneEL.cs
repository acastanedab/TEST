using System;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad Lógica que representa la Zona Horaria
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140922 <br />
    /// Modificación:          <br />
    /// </remarks>
    [Serializable]
    public class TimeZoneEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public TimeZoneEL()
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
        /// Minuto UTC
        /// </summary>
        public short MinuteUtc { get; set; }

        /// <summary>
        /// Descripción de la Zona Horaria
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Descripción Completa de la Zona Horaria
        /// </summary>
        public string FullDescription { get; set; }
    }
}
