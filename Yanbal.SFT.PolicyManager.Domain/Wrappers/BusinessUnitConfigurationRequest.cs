using System;
using Yanbal.SFT.FreightManagement.Common.Base;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa la Configuración de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140730 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class BusinessUnitConfigurationRequest : BaseRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitConfigurationRequest()
        {
        }

        /// <summary>
        /// Código de Unidad de Negocio Configuración
        /// </summary>
        public int? BusinessUnitConfigurationCode { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int? BusinessUnitCodeContext { get; set; }

        /// <summary>
        /// Código de Zona Horaria
        /// </summary>
        public int? TimeZoneCode { get; set; }

        /// <summary>
        /// Descripción de Zona Horaria
        /// </summary>
        public string DescriptionTimeZone { get; set; }

        /// <summary>
        /// Indicador de Contraer Menu
        /// </summary>
        public bool? CollapseMenuIndicator { get; set; }

        /// <summary>
        /// Filas por Página
        /// </summary>
        public byte? RowsPerPage { get; set; }

        /// <summary>
        /// Forma de Visualización de Reporte
        /// </summary>
        public string DisplayFormReport { get; set; }

        /// <summary>
        /// Descripción de Forma de Visualización de Reporte
        /// </summary>
        public string DescriptionDisplayFormReport { get; set; }

        /// <summary>
        /// Logo de Compañia
        /// </summary>
        public byte[] CompanyLogo { get; set; }

        /// <summary>
        /// Ruta de Logo de Compañia
        /// </summary>
        public string PathCompanyLogo { get; set; }

        /// <summary>
        /// Logo de Reporte
        /// </summary>
        public byte[] ReportLogo { get; set; }

        /// <summary>
        /// Ruta de Logo de Reporte
        /// </summary>
        public string PathReportLogo { get; set; }

        /// <summary>
        /// Máximo de Filas por Consulta
        /// </summary>
        public int? MaximumRowsPerVisit { get; set; }

        /// <summary>
        /// Mínimo de Caracteres de Glosa
        /// </summary>
        public byte? MinimumNumberCharactersGloss { get; set; }

        /// <summary>
        /// Mínimo de Vocales de Glosa
        /// </summary>
        public byte? MinimumNumberVowelsGloss { get; set; }

        /// <summary>
        /// Código de Cultura
        /// </summary>
        public string CultureCode { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio Opcional
        /// </summary>
        public int? OptionalBusinessUnitCode { get; set; }
    }
}
