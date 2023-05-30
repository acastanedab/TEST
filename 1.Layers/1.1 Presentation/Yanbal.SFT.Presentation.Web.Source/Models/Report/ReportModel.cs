using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Report
{
    /// <summary>
    /// Modelo que representa Reporte General
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140916 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class ReportModel
    {
        /// <summary>
        /// Constructor que representa la clase
        /// </summary>
        public ReportModel()
        {
            this.Parameters = new List<ReportParameter>();
        }

        /// <summary>
        /// Listado de Parámetros
        /// </summary>
        public List<ReportParameter> Parameters { get; set; }

        /// <summary>
        /// Ruta del reporte
        /// </summary>
        public string PathReport { get; set; }

        /// <summary>
        /// Permite Agregar Parámetros
        /// </summary>
        /// <param name="parameterName">Nombre del Parámetro</param>
        /// <param name="parameterValue">Valor del Parámetro</param>
        public void AddParameter(string parameterName, string parameterValue)
        {
            this.Parameters.Add(new ReportParameter(parameterName, parameterValue));
        }
    }
}
