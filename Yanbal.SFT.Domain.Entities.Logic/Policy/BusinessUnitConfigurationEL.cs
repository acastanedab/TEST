using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad de Lógica que representa la Unidad de Negocio Configuración
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140731 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class BusinessUnitConfigurationEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitConfigurationEL()
        {
        }

        /// <summary>
        /// Código de Unidad de Negocio Configuración
        /// </summary>
        public int BusinessUnitConfigurationCode { get; set; }
        
        /// <summary>
        /// Nombre de Unidad de Negocio
        /// </summary>
        public string BusinessUnitName { get; set; }

        /// <summary>
        /// Código de Zona Horaria
        /// </summary>
        public int TimeZoneCode { get; set; }

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
        public byte RowsPerPage { get; set; }

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
        public int MaximumRowsPerVisit { get; set; }

        /// <summary>
        /// Máximo de Filas por Consulta de tipo Cadena
        /// </summary>
        public string MaximumRowsPerVisitString { get; set; }
        
        /// <summary>
        /// Mínimo de Caracteres de Glosa
        /// </summary>
        public byte? MinimumNumberCharactersGloss { get; set; }

        /// <summary>
        /// Mínimo de Vocales de Glosa
        /// </summary>
        public byte? MinimumNumberVowelGloss { get; set; }

        /// <summary>
        /// Cultura de la Unidad de Negocio
        /// </summary>
        public CultureEL Culture { get; set; }

        /// <summary>
        /// Cantidad de Filas
        /// </summary>
        public string NumberRows { get; set; }
    }
}
