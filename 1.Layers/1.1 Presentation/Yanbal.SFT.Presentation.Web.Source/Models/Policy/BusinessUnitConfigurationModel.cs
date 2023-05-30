using System;
using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa la Configuración de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140918 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class BusinessUnitConfigurationModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitConfigurationModel()
        {
        }

        /// <summary>
        /// Código de Unidad de Negocio de Configuración
        /// </summary>
        public int BusinessUnitConfigurationCode { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Cultura
        /// </summary>
        public string CultureCode { get; set; }

        /// <summary>
        /// Código de Zona Horaria
        /// </summary>
        public int TimeZoneCode { get; set; }

        /// <summary>
        /// Forma de Visualización de Reporte
        /// </summary>
        public string DisplayFormReport { get; set; }

        /// <summary>
        /// Logo de Compañía
        /// </summary>
        public byte[] CompanyLogo { get; set; }

        /// <summary>
        /// Logo de Compaña a Editar
        /// </summary>
        public string CompanyLogoEdit { get; set; }

        /// <summary>
        /// Logo de Reporte
        /// </summary>
        public Byte[] ReportLogo { get; set; }

        /// <summary>
        /// Logo de Reporte a Editar
        /// </summary>
        public string ReportLogoEdit { get; set; }

        /// <summary>
        /// Máximo de Filas Por Consulta
        /// </summary>
        public int MaximumRowsPerQuery { get; set; }

        /// <summary>
        /// Filas Por Página
        /// </summary>
        public Byte RowsPerPage { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Descripción de Estado de Registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }

        /// <summary>
        /// Imagen de Logo de Compañía
        /// </summary>
        public byte[] CompanyLogoImage { get; set; }

        /// <summary>
        /// Imagen de Logo de Reporte
        /// </summary>
        public byte[] ReportLogoImage { get; set; }

        /// <summary>
        /// Motivo de Modificación
        /// </summary>
        public string ModificationReason { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio Opcional
        /// </summary>
        public int? OptionalBusinessUnitCode { get; set; }

        /// <summary>
        /// Mínimo de Caracteres de Glosa
        /// </summary>
        public byte? CharactersMinimumGloss { get; set; }

        /// <summary>
        /// Mínimo de Vocales de Glosa
        /// </summary>
        public byte? VowelsMinimumGloss { get; set; }

        /// <summary>
        /// Indicador Contraer Menú
        /// </summary>
        public bool? IndicatorDisplayMenu { get; set; }

        /// <summary>
        /// Nombre de Unidad de Negocio
        /// </summary>
        public string BusinessUnitName { get; set; }

        /// <summary>
        /// Lista de Unidades de Negocio
        /// </summary>
        public List<SelectType> ListBusinessUnit { get; set; }

        /// <summary>
        /// Lista de Culturas
        /// </summary>
        public List<SelectType> ListCulture { get; set; }

        /// <summary>
        /// Lista de Zonas Horarias
        /// </summary>
        public List<SelectType> ListTimeZone { get; set; }

        /// <summary>
        /// Lista de Formas de Visualización de Reporte
        /// </summary>
        public List<SelectType> ListDisplayFormReport { get; set; }

        /// <summary>
        /// Botón Buscar
        /// </summary>
        public ButtonControl Search { get; set; }

        /// <summary>
        /// Botón Nuevo
        /// </summary>
        public ButtonControl Create { get; set; }

        /// <summary>
        /// Botón Grabar
        /// </summary>
        public ButtonControl Save { get; set; }

        /// <summary>
        /// Botón Cancelar
        /// </summary>
        public ButtonControl Cancel { get; set; }

        /// <summary>
        /// Imagen Editar
        /// </summary>
        public ImageControl Edit { get; set; }

        /// <summary>
        /// Imagen a Seleccionar Logo de Compaña
        /// </summary>
        public ImageControl SelectCompanyLogo { get; set; }

        /// <summary>
        /// Seleccionar Logo de Reporte
        /// </summary>
        public ImageControl SelectReportLogo { get; set; }

        /// <summary>
        /// Botón Cargar
        /// </summary>
        public ButtonControl Load { get; set; }
    }
}
