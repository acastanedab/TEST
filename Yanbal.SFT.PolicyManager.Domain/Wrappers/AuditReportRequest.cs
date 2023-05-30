using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a Reporte de Auditoría
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140916 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class AuditReportRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public AuditReportRequest()
        {
        }

        /// <summary>
        /// Código de Tabla
        /// </summary>
        public int? TableCode { get; set; }

        /// <summary>
        /// Descripción de Tabla
        /// </summary>
        public string TableDescription { get; set; }

        /// <summary>
        /// Código de Atributo
        /// </summary>
        public int? AttributeCode { get; set; }

        /// <summary>
        /// Descripción de Atributo
        /// </summary>
        public string AttributeDescription { get; set; }

        /// <summary>
        /// Usuario de Auditoría
        /// </summary>
        public string UserTransaction { get; set; }

        /// <summary>
        /// Rango de Fecha Desde
        /// </summary>
        public string DateFrom { get; set; }

        /// <summary>
        /// Rango de Fecha Hasta
        /// </summary>
        public string DateTo { get; set; }
    }
}
