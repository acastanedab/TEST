using Yanbal.SFT.FreightManagement.Common.Format;

namespace Yanbal.SFT.Domain.Entities.Logic.Common
{
    /// <summary>
    /// Entidad Lógica que representa la onfiguración del entorno sobre el que trabaja la aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140428 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class EnvironmentEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public EnvironmentEL()
        {
        }

        /// <summary>
        /// Código de unidad de negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de usuario
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Terminal del usuario
        /// </summary>
        public string Terminal { get; set; }

        /// <summary>
        /// Formato de Fecha Corta
        /// </summary>
        public string ShortDateFormat { get; set; }

        /// <summary>
        /// Formato de Fecha Larga
        /// </summary>
        public string LongDateFormat { get; set; }

        /// <summary>
        /// Formato de Hora Corta
        /// </summary>
        public string ShortTimeFormat { get; set; }

        /// <summary>
        /// Formato de Hora Larga
        /// </summary>
        public string LongTimeFormat { get; set; }

        /// <summary>
        /// Formato decimal
        /// </summary>
        public string DecimalFormat{ get; set; }

        /// <summary>
        /// Formato entero
        /// </summary>
        public string IntegerFormat { get; set; }

        /// <summary>
        /// Detalle del formato decimal
        /// </summary>
        public NumberFormat InformationDecimalFormat { get; set; }

        /// <summary>
        /// Detalle del formato entero
        /// </summary>
        public NumberFormat InformationIntegerFormat { get; set; }
    }
}
