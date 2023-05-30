using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa el Reporte de Auditoría
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140916 <br />
    /// Modificación: 
    /// </remarks>
    public class AuditReportModel : BaseModel
    {
        /// <summary>
        /// Constructo que representa la clase
        /// </summary>
        public AuditReportModel()
        {
            this.ListTable = new List<SelectType>();
            this.ListAttribute = new List<SelectType>();
        }

        /// <summary>
        /// Fecha Desde
        /// </summary>
        public string DateFrom { get; set; }

        /// <summary>
        /// Fecha Hasta
        /// </summary>
        public string DateTo { get; set; }

        /// <summary>
        /// Lista de Tabla
        /// </summary>
        public List<SelectType> ListTable { get; set; }

        /// <summary>
        /// Lista de Atributo
        /// </summary>
        public List<SelectType> ListAttribute { get; set; }

        /// <summary>
        /// Botón Visualizar
        /// </summary>
        public ButtonControl Visualize { get; set; }

        /// <summary>
        /// Botón Limpiar
        /// </summary>
        public ButtonControl Clean { get; set; }
    }
}
