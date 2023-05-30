
namespace Yanbal.SFT.FreightManagement.Common
{
    /// <summary>
    /// Clase de dominio común para Enumerados de Tablas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public static class EnumeratedTable
    {
        #region Constanst
        /// <summary>
        /// Colummnas General
        /// </summary>
        public struct GeneralColumm
        {
            /// <summary>
            /// Columna de código unidad de negocio
            /// </summary>
            public const string ColummBusinessUnitCode = "CODIGO_UNIDAD_NEGOCIO";
            /// <summary>
            /// Columna de estado de registro
            /// </summary>
            public const string ColummRegistrationStatus = "ESTADO_REGISTRO";
            /// <summary>
            /// Columna de Motivo de modificación
            /// </summary>
            public const string ColummModificationReason = "OBSERVACION";
            /// <summary>
            /// Columna de Usuario de creación
            /// </summary>
            public const string ColummUserCreation = "USUARIO_CREACION";
            /// <summary>
            /// Columna de Fecha de creación
            /// </summary>
            public const string ColummDateCreation = "FECHA_CREACION";
            /// <summary>
            /// Columna de Terminal de creación
            /// </summary>
            public const string ColummTerminalCreation = "TERMINAL_CREACION";
            /// <summary>
            /// Columna de usuario de modificación
            /// </summary>
            public const string ColummUserModification = "USUARIO_MODIFICACION";
            /// <summary>
            /// Columna de Fecha de modificación
            /// </summary>
            public const string ColummDateModification = "FECHA_MODIFICACION";
            /// <summary>
            /// Columna de Terminal de modificación
            /// </summary>
            public const string ColummTerminalModification = "TERMINAL_MODIFICACION";
        }

        /// <summary>
        /// Enumerado de Combinación
        /// </summary>
        public static class Combinacion
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.COMBINACION";
            /// <summary>
            /// Columna de Código de conbinación
            /// </summary>
            public const string ColumnCombinationCode = "CODIGO_COMBINACION";
        }

        /// <summary>
        /// Enumerado de Combinación de Parámetro
        /// </summary>
        public static class CombinacionParametro
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.COMBINACION_PARAMETRO";
            /// <summary>
            /// Columna de código de parámetro de combinación
            /// </summary>
            public const string ColumnCombinationCodeParameter = "CODIGO_COMBINACION_PARAMETRO";
        }

        /// <summary>
        /// Enumerado de Cultura
        /// </summary>
        public static class Cultura
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.CULTURA";
            /// <summary>
            /// Columna código de cultura
            /// </summary>
            public const string ColumnCultureCode = "CODIGO_CULTURA";
        }

        /// <summary>
        /// Enumerado de Formato de Cadena
        /// </summary>
        public static class FormatoCadena
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT_FORMATO_CADENA";
            /// <summary>
            /// Columna código de formato tipo cadena
            /// </summary>
            public const string ColumnCodeFormatString = "CODIGO_FORMATO_CADENA";
        }

        /// <summary>
        /// Enumerado de Fórmula
        /// </summary>
        public static class Formula
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.FORMULA";
            /// <summary>
            /// Columna código de formula
            /// </summary>
            public const string ColumnFormulaCode = "CODIGO_FORMULA";
        }

        /// <summary>
        /// Enumerado de Idioma
        /// </summary>
        public static class Idioma
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.IDIOMA";
            /// <summary>
            /// Columna de código de idioma
            /// </summary>
            public const string ColumnLanguageCode = "CODIGO_IDIOMA";
        }

        /// <summary>
        /// Enumerado de Orden de Combinación
        /// </summary>
        public static class OrdenCombinacion
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.ORDEN_COMBINACION";
            /// <summary>
            /// Columna de código de orden de combinación
            /// </summary>
            public const string ColumnOrderCodeCombination = "CODIGO_ORDEN_COMBINACION";
        }

        /// <summary>
        /// Enumerado de País
        /// </summary>
        public static class Pais
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.PAIS";
            /// <summary>
            /// Columna código de país
            /// </summary>
            public const string ColumnCountryCode = "CODIGO_PAIS";
        }

        /// <summary>
        /// Enumerado de Parámetro
        /// </summary>
        public static class Parametro
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.PARAMETRO";
            /// <summary>
            /// Columna código de parámetro
            /// </summary>
            public const string ColumnParameterCode = "CODIGO_PARAMETRO";
        }

        /// <summary>
        /// Enumerado de Parámetro Sección
        /// </summary>
        public static class ParametroSeccion
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.PARAMETRO_SECCION";
            /// <summary>
            /// Columna de código de parámetro
            /// </summary>
            public const string ColumnParameterCode = "CODIGO_PARAMETRO";
            /// <summary>
            /// Columna de código de sección
            /// </summary>
            public const string ColumnSeccionCode = "CODIGO_SECCION";
        }

        /// <summary>
        /// Enumerado de Parámetro Valor
        /// </summary>
        public static class ParametroValor
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.PARAMETRO_VALOR";
            /// <summary>
            /// Columna de código de parámetro
            /// </summary>
            public const string ColumnParameterCode = "CODIGO_PARAMETRO";
            /// <summary>
            /// Columna de código de sección
            /// </summary>
            public const string ColumnSeccionCode = "CODIGO_SECCION";
            /// <summary>
            /// Columna de código de valor
            /// </summary>
            public const string ColumnValueCode = "CODIGO_VALOR";
        }

        /// <summary>
        /// Enumerado de Tipo de Zona de Ubigeo
        /// </summary>
        public static class TipoZonaUbigeo
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.TIPO_ZONA_UBIGEO";
            /// <summary>
            /// Columna de código de área de tipo ubigeo
            /// </summary>
            public const string ColumnTypeCodeAreaUbigeo = "CODIGO_TIPO_ZONA_UBIGEO";
        }

        /// <summary>
        /// Enumerado de Unidad de Negocio
        /// </summary>
        public static class UnidadNegocio
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.UNIDAD_NEGOCIO";
        }

        /// <summary>
        /// Enumerado de Unidad de Negocio de Configuración
        /// </summary>
        public static class UnidadNegocioConfiguracion
        {
            /// <summary>
            /// Nombre de tabla
            /// </summary>
            public const string TableName = "MNT.UNIDAD_NEGOCIO_CONFIGURACION";
            /// <summary>
            /// Columna de código de configuración de código de unidad de negocio
            /// </summary>
            public const string ColumnConfigurationCodeBusinessUnit = "CODIGO_UNIDAD_NEGOCIO_CONFIGURACION";
        }
        #endregion
    }
}