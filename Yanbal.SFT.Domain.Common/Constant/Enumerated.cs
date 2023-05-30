using System;
using System.Configuration;

namespace Yanbal.SFT.FreightManagement.Common
{
	/// <summary>
	/// Clase que Contiene las Constantes Generales del Sistema
	/// </summary>
	public static class Enumerated
	{
		#region Constanst

		/// <summary>
		/// Codigo Identificacion Sistema
		/// </summary>
		public static readonly string CodigoIdentificacionSistema = Convert.ToString(ConfigurationManager.AppSettings["SystemIdentificationCode"]);

		/// <summary>
		/// Nombre Componente
		/// </summary>
		public static readonly string NombreComponente = Convert.ToString(ConfigurationManager.AppSettings["NombreComponente"]);

		/// <summary>
		/// BusinessUnity
		/// </summary>
		public static readonly int NodoCluster = Convert.ToInt32(ConfigurationManager.AppSettings["NodoCluster"]);

		/// <summary>
		/// Filas para tabla de datos
		/// </summary>
		public struct DataTableRow
		{
			/// <summary>
			/// Codigo parametro
			/// </summary>
			public const string CodigoParametro = "CODIGO_PARAMETRO";

			/// <summary>
			/// Valor
			/// </summary>
			public const string Valor = "VALOR";
		}

		/// <summary>
		/// Constantes de Parametro
		/// </summary>
		public struct Parameter
		{
			/// <summary>
			/// Estado Civil
			/// </summary>
			public const string RegistrationStatus = "ETR";
			/// <summary>
			/// Tipo de parámetro
			/// </summary>
			public const string ParameterType = "TPT";
			/// <summary>
			/// Tipo de sección
			/// </summary>
			public const string SectionType = "TSC";
			/// <summary>
			/// Nivel de zona geografica
			/// </summary>
			public const string LevelGeoZone = "NVZ";
			/// <summary>
			/// Tipo de zona
			/// </summary>
			public const string ZoneType = "TZN";
			/// <summary>
			/// Rango de importe
			/// </summary>
			public const string AmountRange = "RMT";
			/// <summary>
			/// Tipo de orden
			/// </summary>
			public const string TypeOrder = "TPD";
			/// <summary>
			/// Año de campaña
			/// </summary>
			public const string YearCampaign = "ACM";
			/// <summary>
			/// Número de campaña
			/// </summary>
			public const string NumberCampaign = "NCM";
			/// <summary>
			/// Número de semana
			/// </summary>
			public const string NumberWeek = "NSM";
			/// <summary>
			/// Tipo de envio
			/// </summary>
			public const string SendType = "TEN";
			/// <summary>
			/// Mostrar durante Informe
			/// </summary>
			public const string DisplayFormReport = "FVR";
			/// <summary>
			/// Claves de reCAPTCHA de google
			/// </summary>
			public const string ClavesReCaptcha = "CRG";
		}

		/// <summary>
		/// Constantes de contexto de acceso común
		/// </summary>
		public struct ContextCommonAccess
		{
			/// <summary>
			/// General
			/// </summary>
			public const string General = "General";
		}

		/// <summary>
		/// Constantes de codigo de identificación de acción
		/// </summary>
		public struct IdentificationCodeAction
		{
			/// <summary>
			/// Visible
			/// </summary>
			public const string Visible = "VIS";
			/// <summary>
			/// Habilitado
			/// </summary>
			public const string Enabled = "ENA";
		}

		/// <summary>
		/// Constantes que representan los Estados de Registro
		/// </summary>
		public struct RegistrationStatus
		{
			/// <summary>
			/// Activo
			/// </summary>
			public const string Active = "1";
			/// <summary>
			/// Cancelado
			/// </summary>
			public const string Cancelled = "0";
		}

		/// <summary>
		/// Constantes que representan los Tipos de Parametros
		/// </summary>
		public struct ParameterType
		{
			/// <summary>
			/// Solo valor
			/// </summary>
			public const string SingleValue = "TP1";
			/// <summary>
			/// Rango de valor
			/// </summary>
			public const string RangeValues = "TP2";
		}

		/// <summary>
		/// Constantes que representan los Tipos de Secciones
		/// </summary>
		public struct SectionType
		{
			/// <summary>
			/// Cadena
			/// </summary>
			public const string String = "TD1";
			/// <summary>
			/// Entero
			/// </summary>
			public const string Integer = "TD2";
			/// <summary>
			/// Decimal
			/// </summary>
			public const string Decimal = "TD3";
			/// <summary>
			/// Fecha
			/// </summary>
			public const string Date = "TD4";
			/// <summary>
			/// Booleano
			/// </summary>
			public const string Boolean = "TD5";
		}

		/// <summary>
		/// Constantes que representan los Formatos de Cadenas
		/// </summary>
		public static class TypeFormatString
		{
			/// <summary>
			/// Fecha
			/// </summary>
			public static readonly string Date = "F";
			/// <summary>
			/// Tiempo
			/// </summary>
			public static readonly string Time = "H";
			/// <summary>
			/// Entero
			/// </summary>
			public static readonly string Integer = "E";
			/// <summary>
			/// Decimal
			/// </summary>
			public static readonly string Decimal = "D";
			/// <summary>
			/// Largo
			/// </summary>
			public static readonly bool Long = true;
			/// <summary>
			/// Corto
			/// </summary>
			public static readonly bool Short = false;
		}

		/// <summary>
		/// Constantes que representan los Tipos de Secciones
		/// </summary>
		public struct RangeType
		{
			/// <summary>
			/// Inicio
			/// </summary>
			public const string Begin = "B";
			/// <summary>
			/// Fin
			/// </summary>
			public const string End = "E";
		}

		/// <summary>
		/// Constantes que representan las Operaciones Matematicas
		/// </summary>
		public struct Operation
		{
			/// <summary>
			/// Suma
			/// </summary>
			public const string Addition = "+";
			/// <summary>
			/// Resta
			/// </summary>
			public const string Subtraction = "-";
			/// <summary>
			/// Multiplicación
			/// </summary>
			public const string Multiplication = "*";
			/// <summary>
			/// División
			/// </summary>
			public const string Division = "/";
		}

		/// <summary>
		/// Constantes que representan los Codigos de Error Base
		/// </summary>
		public struct ErrorCodeBase
		{
			/// <summary>
			/// Exitosa
			/// </summary>
			public const string Successful = "0";
			/// <summary>
			/// Error inesperado
			/// </summary>
			public const string UnExpectedError = "-1";
			/// <summary>
			/// Data no requerida
			/// </summary>
			public const string NoDataRequired = "1";
			/// <summary>
			/// Datos invalidos
			/// </summary>
			public const string DataInvalid = "2";
			/// <summary>
			/// No hay conexión de base de datos
			/// </summary>
			public const string NotConnectionDatabase = "3";
		}

		/// <summary>
		/// Constantes que representan las Descripciónes de Error Base
		/// </summary>
		public struct ErrorDescriptionBase
		{
			/// <summary>
			/// Exitosa
			/// </summary>
			public const string Successful = "Process executed successfully";
			/// <summary>
			/// Error inesperado
			/// </summary>
			public const string UnExpectedError = "An unexpected error occurred in the application";
			/// <summary>
			/// Data no requerida
			/// </summary>
			public const string NoDataRequired = "Required data is not sent";
			/// <summary>
			/// Datos invalidos
			/// </summary>
			public const string DataInvalid = "Invalid data sent";
			/// <summary>
			/// No hay conexión de base de datos
			/// </summary>
			public const string NotConnectionDatabase = "No database connection";
		}

		/// <summary>
		/// Constantes que representan los Codigos de Error del Servicio de Calculo del Servicio
		/// </summary>
		public struct ErrorCodeCombination
		{
			/// <summary>
			/// Combinación inexistente
			/// </summary>
			public const string CombinationNonexistent = "4";
			/// <summary>
			/// Combinación no válida
			/// </summary>
			public const string CombinationInvalid = "5";
			/// <summary>
			/// Fórmula de cálculo incorrecto
			/// </summary>
			public const string CalculationFormulaWrong = "6";
		}

		/// <summary>
		/// Constantes que representan las Descripciónes de Error Base
		/// </summary>
		public struct ErrorDescriptionCombination
		{
			/// <summary>
			/// Combinación inexistente
			/// </summary>
			public const string CombinationNonexistent = "Combination nonexistent";
			/// <summary>
			/// Combinación no válida
			/// </summary>
			public const string CombinationInvalid = "Calculation invalid wrong";
			/// <summary>
			/// Fórmula de cálculo incorrecto
			/// </summary>
			public const string CalculationFormulaWrong = "Calculation formula wrong";
		}

		/// <summary>
		/// Enumerado de tipo de visualización de reporte
		/// </summary>
		public struct ReportDisplayForm
		{
			/// <summary>
			/// Ventana
			/// </summary>
			public const string Window = "V";
			/// <summary>
			/// Pestaña
			/// </summary>
			public const string Tab = "P";
		}

		/// <summary>
		/// Enumerado de Forma de Presentación del Menú
		/// </summary>
		public struct MenuDisplayForm
		{
			/// <summary>
			/// Formulario Ampliado
			/// </summary>
			public const string ExpandedForm = "0";
			/// <summary>
			/// Formulario Contratado
			/// </summary>
			public const string ContractedForm = "1";
		}

		/// <summary>
		/// Enumerado de símbolo negativo
		/// </summary>
		public struct NegativeSymbol
		{
			/// <summary>
			/// Simbolo
			/// </summary>
			public const string Sign = "S";
			/// <summary>
			/// Parantesis
			/// </summary>
			public const string Parenthesis = "P";
		}

		/// <summary>
		/// nombres de archivo para los reportes del sis
		/// </summary>
		public static class ReportFileName
		{
			/// <summary>
			/// Auditoría de Política
			/// </summary>
			public static readonly string PolicyAudit = "FreightAuditPolicy";
			/// <summary>
			/// Auditoría de Política
			/// </summary>
			public static readonly string PolicyAllocationAreas = "FreightAllocationAreas";
			/// <summary>
			/// Auditoría de Política
			/// </summary>
			public static readonly string PolicyCombination = "FreightCombination";
		}
		/// <summary>
		/// Formato de Fechas
		/// </summary>
		public struct FormatDate
		{
			/// <summary>
			/// Formato de respuesta de servicios
			/// </summary>
			public const string ResponseService = "yyyy-MM-ddTHH:mm:ss";
		}

		/// <summary>
		/// Formato de Fechas
		/// </summary>
		public struct FactorType
		{
			/// <summary>
			/// código por monto
			/// </summary>
			public const string Amount = "0";
			/// <summary>
			/// código por porcentaje
			/// </summary>
			public const string Percent = "1";
			/// <summary>
			/// código por valor fijo
			/// </summary>
			public const string FixedValue = "2";
		}

		/// <summary>
		/// Constantes de valor 0
		/// </summary>
		public struct DefaultValue
		{
			/// <summary>
			/// valor por defecto
			/// </summary>
			public const decimal Default = 0;
		}
		public struct Encryption
		{
			/// <summary>
			/// valor de la llave en byte
			/// </summary>
			public const int keyByte = 32;
			/// <summary>
			/// valor del IV en byte
			/// </summary>
			public const int IVByte = 16;
		}

		/// <summary>
		/// VersionCaptcha
		/// </summary>
		public struct PropiedadesCaptcha
		{
			/// <summary>
			/// Const SegundaVersion
			/// </summary>
			public const string SegundaVersion = "2";

			/// <summary>
			/// Const TerceraVersion
			/// </summary>
			public const string TerceraVersion = "3";

			/// <summary>
			/// const Score
			/// </summary>
			public const decimal Score = 0.5M;
		}
		/// <summary>
		/// Keys Clave Publica y Privada
		/// </summary>
		public struct KeysCaptcha
		{
			/// <summary>
			/// Key clave publica
			/// </summary>
			public const string KeyClavePublica = "2";
			/// <summary>
			/// Key clave privada
			/// </summary>
			public const string KeyClavePrivada = "3";

		}
		public struct ActionReCaptcha
		{
			/// <summary>
			/// 
			/// </summary>
			public const string Home = "Home";

			/// <summary>
			/// 
			/// </summary>
			public const string Mensaje = "Validación de Captcha fallido";
		}
		/// <summary>
		/// ControllerClassName
		/// </summary>
		public struct ControllerClassName
		{
			/// <summary>
			/// Const HomeController
			/// </summary>
			public const string HomeController = "Home";

		}

		public static class SessionKey
		{
			/// <summary>
			/// Versión Componente
			/// </summary>
			public const string VersionComponente = "SK_versionComponente";
		}

		/// <summary>
		/// Componentes
		/// </summary>
		public static class Componente
		{
			/// <summary>
			/// Servicio FreightManager
			/// </summary>
			public static readonly int appSFT = 1;
			/// <summary>
			/// Servicio FreightManager
			/// </summary>
			public static readonly int srvSFTFreight = 2;
		}
		#endregion

		#region Enumerated
		/// <summary>
		/// Enumerado de Parametro
		/// </summary>
		public struct CodeParameter
		{
			/// <summary>
			/// Parámetro de Ejecucion del Proceso de Ejecuciones
			/// </summary>
			public const string DateTimeEjecutionComission = "PEC";
			/// <summary>
			/// Código de comisión
			/// </summary>
			public const string CommissionsCode = "CDC";
			/// <summary>
			/// Tipo de retención
			/// </summary>
			public const string RetentionType = "TRT";
			/// <summary>
			/// Clasificación de impuesto
			/// </summary>
			public const string TaxClassification = "CTR";
			/// <summary>
			/// Tipo de rango valor
			/// </summary>
			public const string ValueRangeType = "TVR";
			/// <summary>
			/// Tipo de fórmula
			/// </summary>
			public const string FormulaType = "TPF";
			/// <summary>
			/// Estado de registro
			/// </summary>
			public const string RegistrationStatus = "ETR";
			/// <summary>
			/// Impuesto
			/// </summary>
			public const string Tax = "TPI";
			/// <summary>
			/// Informe de forma de la pantalla
			/// </summary>
			public const string ReportDisplayForm = "FVR";
			/// <summary>
			/// Tipo de Impuesto por Proceso
			/// </summary>
			public const string TaxProcessType = "TIP";
			/// <summary>
			/// Tipo de orden
			/// </summary>
			public const string OrderType = "TPP";
			/// <summary>
			/// Tipo de parámetro
			/// </summary>
			public const string ParameterType = "TPT";
			/// <summary>
			/// Proceso
			/// </summary>
			public const string Process = "TPR";
			/// <summary>
			/// Original
			/// </summary>
			public const string Origin = "CLO";
			/// <summary>
			/// Tipo de sección
			/// </summary>
			public const string SectionType = "TSC";
			/// <summary>
			/// Nivel de zona géografica
			/// </summary>
			public const string LevelGeoZone = "NZG";
			/// <summary>
			/// Estado Afectación
			/// </summary>
			public const string AffectationStatus = "ETA";
			/// <summary>
			/// Perfil de deducción impuesto
			/// </summary>
			public const string DeductionTaxProfile = "DSC";
			/// <summary>
			/// Año de campaña
			/// </summary>
			public const string YearCampaign = "CAP";
			/// <summary>
			/// Número de campaña
			/// </summary>
			public const string CampaniaNumber = "NCM";
			/// <summary>
			/// Tipo de Persona
			/// </summary>
			public const string TypePerson = "TTP";
			/// <summary>
			/// Código de Equivalencia con J6 de Impuesto
			/// </summary>
			public const string TaxEquivalenceJ6 = "CEJ";
			/// <summary>
			/// Código de Tipo de Afectación de Producto
			/// </summary>
			public const string ProductTypeAllocation = "TAP";
			/// <summary>
			/// Uso de tipo de Párametro
			/// </summary>
			public const string UsingParameterType = "UPV";

			/// <summary>
			/// Código de Estado de Proceso
			/// </summary>
			public const string ProcessStatus = "ECL";
			/// <summary>
			/// Código de Prioridad de Modalidad de Calculo
			/// </summary>
			public const string PriorityCalculationModality = "PMC";
			/// <summary>
			/// Incluye Cálculo de Retención
			/// </summary>
			public const string IncludesRetentionCalculation = "ICR";
			/// <summary>
			/// Claves de reCAPTCHA de google
			/// </summary>
			public const string ClavesReCaptcha = "CRG";

			/// <summary>
			/// Log4Net Configuración
			/// </summary>
			public const string Log4NetConfig = "CLF";

			/// <summary>
			/// Parámetros Integration J6
			/// </summary>
			public const string ParametroIntegrationJ6 = "IJ6";
			/// <summary>
			/// Control de Check para Cargar IVA desde ICE
			/// </summary>
			public const string ParametroCheckCargarIVA = "CCC";

			/// <summary>
			/// Codigo ReCaptcha Google
			/// </summary>
			public const string CodigoReCaptchaGoogle = "CRG";
			/// <summary>
			/// Parámetros appSettings - key
			/// </summary>
			public const string appSettingsParameters = "APC";

			/// <summary>
			/// Parámetros endPoint
			/// </summary>
			public const string endPointParameters = "ENP";
		}
		#endregion

		/// <summary>
		/// Clase de enumerado para obtener la Unidad de Negocio
		/// </summary>
		public static class UnidadNegocio
		{
			/// <summary>
			/// Descripción abreviada de la unidad de negocio
			/// </summary>
			public static readonly string NombreUnidadNegocio = ConfigurationManager.AppSettings["BusinessUnity"];
		}
		/// <summary>
		/// Enumerado de Estado LoggingFlag
		/// </summary>
		public struct EstadoLoggingFlag
		{
			/// <summary>
			/// Activo
			/// </summary>
			public const string Activo = "1";
			/// <summary>
			/// Inactivo
			/// </summary>
			public const string Inactivo = "0";
		}

		/// <summary>
		/// Seccion Parametro Config
		/// </summary>
		public struct SeccionParametrosConfig
		{
			/// <summary>
			/// Codigo
			/// </summary>
			public const int Codigo = 1;
			/// <summary>
			/// Componentes
			/// </summary>
			public const int Componentes = 2;
			/// <summary>
			/// Valor
			/// </summary>
			public const int Valor = 3;
			/// <summary>
			/// Descripcion
			/// </summary>
			public const int Descripcion = 4;
		}

		/// <summary>
		/// Seccion EndPoint Config
		/// </summary>
		public struct SeccionEndPointConfig
		{
			/// <summary>
			/// Codigo
			/// </summary>
			public const int Codigo = 1;
			/// <summary>
			/// Componentes
			/// </summary>
			public const int Componentes = 2;
			/// <summary>
			/// Valor
			/// </summary>
			public const int Descripcion = 3;
		}

		/// <summary>
		/// Nombre Configuración EndPoint
		/// </summary>
		public struct EndPointConfig
		{
			/// <summary>
			/// SRA Security Service 
			/// </summary>
			public const string srvMSFSecurity = "BasicHttpBinding_ISRAService";
			/// <summary>
			/// SRA Security Service 
			/// </summary>
			public const string srvMSFTokenSecurity = "basic1";
		}

		/// <summary>
		/// Codigo Parametro Config
		/// </summary>
		public struct CodigoParametroConfig
		{
			/// <summary>
			/// Codigo de cookie J6
			/// </summary>
			public const string cookieNameJ6 = "CookieNameJ6";
			/// <summary>
			/// Url de reporting
			/// </summary>
			public const string reportingUrl = "SrvReportingUrl";
			/// <summary>
			/// User de reporting
			/// </summary>
			public const string reportingUser = "SrvReportingUser";
			/// <summary>
			/// Password reporting
			/// </summary>
			public const string reportingPassword = "SrvReportingPassword";
			/// <summary>
			/// Domain reporting
			/// </summary>
			public const string reportingDomain = "SrvReportingDomain";
			/// <summary>
			/// Domain reporting
			/// </summary>
			public const string reportingWorkspace = "SrvReportingWorkspace";
			/// <summary>
			/// PathSecurity reporting
			/// </summary>
			public const string reportingPathPolicy = "SrvReportingPathPolicy";
		}
	}
}