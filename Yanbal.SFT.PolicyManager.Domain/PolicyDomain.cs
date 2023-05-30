using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Yanbal.SFT.Domain.Entities.Audit.Policy;
using Yanbal.SFT.Domain.Entities.General;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.Domain.Entities.Logic.UpdateVersion;
using Yanbal.SFT.Domain.Entities.Policy.BusinessUnit;
using Yanbal.SFT.Domain.Entities.Policy.BusinessUnitConfiguration;
using Yanbal.SFT.Domain.Entities.Policy.City;
using Yanbal.SFT.Domain.Entities.Policy.Combination;
using Yanbal.SFT.Domain.Entities.Policy.CombinationOrder;
using Yanbal.SFT.Domain.Entities.Policy.Country;
using Yanbal.SFT.Domain.Entities.Policy.Culture;
using Yanbal.SFT.Domain.Entities.Policy.District;
using Yanbal.SFT.Domain.Entities.Policy.Formula;
using Yanbal.SFT.Domain.Entities.Policy.FreightUbication;
using Yanbal.SFT.Domain.Entities.Policy.Language;
using Yanbal.SFT.Domain.Entities.Policy.Parameter;
using Yanbal.SFT.Domain.Entities.Policy.ParameterCombination;
using Yanbal.SFT.Domain.Entities.Policy.ParameterSection;
using Yanbal.SFT.Domain.Entities.Policy.ParameterValue;
using Yanbal.SFT.Domain.Entities.Policy.Province;
using Yanbal.SFT.Domain.Entities.Policy.StringFormat;
using Yanbal.SFT.Domain.Entities.Policy.TimeZone;
using Yanbal.SFT.Domain.Entities.Policy.UbigeoZoneType;
using Yanbal.SFT.Domain.Entities.UpdateVersion;
using Yanbal.SFT.Domain.Mappers.Combination;
using Yanbal.SFT.Domain.Mappers.ParameterCombination;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Custom;
using Yanbal.SFT.FreightManagement.Common.Parametros;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Infrastructure.CrossCutting;
using Yanbal.SFT.Infrastructure.CrossCutting.Integracion;
using Yanbal.SFT.Infrastructure.CrossCutting.Repositories;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;

namespace Yanbal.SFT.PolicyManager.Domain
{
	/// <summary>
	/// Dominio que representa las Políticas Generales
	/// </summary>
	public class PolicyDomain : IPolicyDomain
	{
		private readonly IDbContext dbContext;
		private readonly EnvironmentEL environment;
		private ICountry country;
		private ITimeZone timeZone;
		private IBusinessUnit businessUnit;
		private IBusinessUnitConfiguration businessUnitConfiguration;
		private ICulture culture;
		private ILanguage language;
		private IStringFormat stringFormat;
		private IParameter parameter;
		private IParameterSection parameterSection;
		private IParameterValue parameterValue;
		private IDynamicEntity dynamicEntity;
		private IProvince province;
		private ICity city;
		private IDistrict district;
		private IUbigeoZoneType ubigeoZoneType;
		private ICombinationOrder combinationOrder;
		private IParameterCombination parameterCombination;
		private ICombination combination;
		private IFormula formula;
		private IPolicyAudit policyAudit;
		private IPolicyAuditTable policyAuditTable;
		private IPolicyAuditColumn policyAuditColumn;
		private IDateTimeBusinessUnit dateTimeBusinessUnit;
		private IFreightUbication freightUbication;
		private IUpdateVersionComponente updateVersionComponente;

		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public PolicyDomain()
		{
			dbContext = new DataBaseContext();
		}

		/// <summary>
		/// Constructor por Defecto de implementación de la clase basado en el Entorno
		/// </summary>
		/// <param name="environment">Entorno del Sistema</param>
		public PolicyDomain(EnvironmentEL environment)
		{
			dbContext = new DataBaseContext();
			this.environment = environment;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<CountryEL>> CountrySearch(CountryRequest filter)
		{
			var processResult = new ProcessResult<List<CountryEL>>();
			try
			{
				var resultCountryEn = new List<CountryEN>();

				using (country = new CountryEN(new RepositoryStoredProcedure<CountryEN>(dbContext)))
				{
					resultCountryEn = country.CountrySearch(filter.CountryCode, filter.CountryZoneCode);
				}
				var listCountry = new List<CountryEL>();
				foreach (var item in resultCountryEn)
				{
					var countryEl = new CountryEL();
					countryEl.CountryCode = item.CodigoPais;
					countryEl.CountryZoneCode = item.CodigoPaisZona;
					countryEl.CountryName = item.Nombre;
					listCountry.Add(countryEl);
				}
				processResult.Result = listCountry;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<LanguageEL>> LanguageSearch(LanguageRequest filter)
		{
			var processResult = new ProcessResult<List<LanguageEL>>();
			try
			{
				var resultLanguageEn = new List<LanguageEN>();

				using (language = new LanguageEN(new RepositoryStoredProcedure<LanguageEN>(dbContext)))
				{
					resultLanguageEn = language.LanguageSearch(filter.LanguageCode, filter.Name, filter.RegistrationStatus);
				}
				var listLanguage = new List<LanguageEL>();
				foreach (var item in resultLanguageEn)
				{
					var languageEl = new LanguageEL();
					languageEl.LanguageCode = item.CodigoIdioma;
					languageEl.Name = item.Nombre;
					languageEl.RegistrationStatus = item.EstadoRegistro;
					listLanguage.Add(languageEl);
				}
				processResult.Result = listLanguage;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<StringFormatEL>> StringFormatSearch(StringFormatRequest filter)
		{
			var processResult = new ProcessResult<List<StringFormatEL>>();
			try
			{
				var resultStringFormatEn = new List<StringFormatEN>();

				using (stringFormat = new StringFormatEN(new RepositoryStoredProcedure<StringFormatEN>(dbContext)))
				{
					resultStringFormatEn = stringFormat.StringFormatSearch(filter.StringFormatCode, filter.Format, filter.FormatType, filter.LongFormat, filter.RegistrationStatus);
				}
				var listStringFormat = new List<StringFormatEL>();
				foreach (var item in resultStringFormatEn)
				{
					var stringFormatEl = new StringFormatEL();
					stringFormatEl.StringFormatCode = item.CodigoFormatoCadena;
					stringFormatEl.Format = item.Formato;
					stringFormatEl.FormatType = item.TipoFormato;
					stringFormatEl.LongFormat = item.FormatoLargo;
					stringFormatEl.RegistrationStatus = item.EstadoRegistro;
					listStringFormat.Add(stringFormatEl);
				}
				processResult.Result = listStringFormat;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Zonas Horarias
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<TimeZoneEL>> TimeZoneSearch(TimeZoneRequest filter)
		{
			var processResult = new ProcessResult<List<TimeZoneEL>>();
			try
			{
				var resultTimeZoneEn = new List<TimeZoneEN>();

				using (timeZone = new TimeZoneEN(new RepositoryStoredProcedure<TimeZoneEN>(dbContext)))
				{
					resultTimeZoneEn = timeZone.TimeZoneSearch(filter.TimeZoneCode, filter.HourUtc, filter.MinuteUtc, filter.Description, filter.RegistrationStatus, filter.PageNo, filter.PageSize);
				}
				var listTimeZone = new List<TimeZoneEL>();
				foreach (var item in resultTimeZoneEn)
				{
					var timeZoneEl = new TimeZoneEL();
					timeZoneEl.TimeZoneCode = item.CodigoZonaHoraria;
					timeZoneEl.HourUtc = item.HoraUtc;
					timeZoneEl.MinuteUtc = item.MinutoUtc;
					timeZoneEl.MinuteUtc = item.MinutoUtc;
					timeZoneEl.Description = item.Descripcion;
					timeZoneEl.FullDescription = item.DescripcionCompleta;
					listTimeZone.Add(timeZoneEl);
				}
				processResult.Result = listTimeZone;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<BusinessUnitEL>> BusinessUnitSearch(BusinessUnitRequest filter)
		{
			var processResult = new ProcessResult<List<BusinessUnitEL>>();
			try
			{
				var resultBusinessUnitEn = new List<BusinessUnitEN>();

				using (businessUnit = new BusinessUnitEN(new RepositoryStoredProcedure<BusinessUnitEN>(dbContext)))
				{
					resultBusinessUnitEn = businessUnit.BusinessUnitSearch(filter.BusinessUnitCode,
																		filter.BusinessUnitCodeContext,
																		filter.Name,
																		filter.BusinessUnitName,
																		filter.CountryCode,
																		filter.RegistrationStatus,
																		filter.PageNo,
																		filter.PageSize);
				}
				var listBusinessUnit = new List<BusinessUnitEL>();
				foreach (var item in resultBusinessUnitEn)
				{
					var businessUnitEl = new BusinessUnitEL();
					businessUnitEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					businessUnitEl.Name = item.Nombre;
					businessUnitEl.CountryCode = item.CodigoPais;
					businessUnitEl.CountryZoneCode = item.CodigoPaisZona;
					businessUnitEl.CountryName = item.NombrePais;
					businessUnitEl.BusinessName = item.RazonSocialCompania;
					businessUnitEl.BusinessAddress = item.DireccionCompania;
					businessUnitEl.BusinessPaper = item.DocumentoCompania;
					businessUnitEl.RegistrationStatus = item.EstadoRegistro;
					businessUnitEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					if (filter.GetBusinessUnitConfigurationIndicator)
					{
						businessUnitEl.BusinessUnitConfiguration = BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitCode = item.CodigoUnidadNegocio, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
					}

					businessUnitEl.RowId = item.RowId;
					businessUnitEl.RowNumber = item.RowNumber;
					businessUnitEl.RowsTotal = item.RowsTotal;

					listBusinessUnit.Add(businessUnitEl);
				}
				processResult.Result = listBusinessUnit;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Unidad de Negocio a registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Fórmula existente</returns>
		public ProcessResult<string> BusinessUnitRegister(BusinessUnitRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCodeContext == null
					|| string.IsNullOrEmpty(filter.Name)
					|| string.IsNullOrEmpty(filter.CountryCode)
					|| string.IsNullOrEmpty(filter.BusinessUnitName)
					|| string.IsNullOrEmpty(filter.Address)
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var resultBusinessUnitSearch = BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = filter.CountryCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultBusinessUnitSearch.Count > 0)
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;

				var currentQueryBusinessUnitCode = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_UNIDAD_NEGOCIO" + "]), 0) + 1" }, new List<string>() { "MNT.UNIDAD_NEGOCIO" }, null);
				var currentRecordBusinessUnitCode = ExecuteDynamicQuery(currentQueryBusinessUnitCode).FirstOrDefault();
				filter.BusinessUnitCode = Convert.ToInt32(currentRecordBusinessUnitCode[currentRecordBusinessUnitCode.Keys.FirstOrDefault()]);

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				using (businessUnit = new BusinessUnitEN(new RepositoryStoredProcedure<BusinessUnitEN>(dbContext)))
				{
					var businessUnitEn = new BusinessUnitEN()
					{
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						Nombre = filter.Name,
						CodigoPais = filter.CountryCode,
						RazonSocialCompania = filter.BusinessUnitName,
						DireccionCompania = filter.Address,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation,
						CodigoUnidadNegocioContexto = Convert.ToInt32(filter.BusinessUnitCodeContext)
					};

					quantityAffectedRecords = businessUnit.BusinessUnitRegister(businessUnitEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewBusinessUnitSearch = BusinessUnitSearch(new BusinessUnitRequest() { BusinessUnitCode = filter.BusinessUnitCode, BusinessUnitCodeContext = filter.BusinessUnitCodeContext }).Result;
						this.PolicyAuditRegister(EnumeratedTable.UnidadNegocio.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCodeContext),
																	   filter.BusinessUnitCode.ToString(),
																	   null,
																	   businessUnitEn.UsuarioCreacion,
																	   businessUnitEn.TerminalCreacion,
																	   null,
																	   resultNewBusinessUnitSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modificación de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Unidad de Negocio a modificar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Fórmula existente</returns>
		public ProcessResult<string> BusinessUnitUpdate(BusinessUnitRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| filter.BusinessUnitCodeContext == null
					|| string.IsNullOrEmpty(filter.Name)
					|| string.IsNullOrEmpty(filter.CountryCode)
					|| string.IsNullOrEmpty(filter.BusinessUnitName)
					|| string.IsNullOrEmpty(filter.Address)
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var resultBusinessUnitSearch = BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = filter.CountryCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

					if (resultBusinessUnitSearch.Any(item => item.BusinessUnitCode != filter.BusinessUnitCode))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}
				}

				int quantityAffectedRecords = 0;

				using (businessUnit = new BusinessUnitEN(new RepositoryStoredProcedure<BusinessUnitEN>(dbContext)))
				{
					var businessUnitEn = new BusinessUnitEN()
					{
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						Nombre = filter.Name,
						CodigoPais = filter.CountryCode,
						RazonSocialCompania = filter.BusinessUnitName,
						DireccionCompania = filter.Address,
						Observacion = filter.ModificationReason,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification,
						CodigoUnidadNegocioContexto = Convert.ToInt32(filter.BusinessUnitCodeContext)
					};

					var resultOldBusinessUnitSearch = BusinessUnitSearch(new BusinessUnitRequest() { BusinessUnitCode = filter.BusinessUnitCode, BusinessUnitCodeContext = filter.BusinessUnitCodeContext }).Result;

					quantityAffectedRecords = businessUnit.BusinessUnitUpdate(businessUnitEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentBusinessUnitSearch = BusinessUnitSearch(new BusinessUnitRequest() { BusinessUnitCode = filter.BusinessUnitCode, BusinessUnitCodeContext = filter.BusinessUnitCodeContext }).Result;
						this.PolicyAuditRegister(EnumeratedTable.UnidadNegocio.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCodeContext),
																	   filter.BusinessUnitCode.ToString(),
																	   businessUnitEn.Observacion,
																	   businessUnitEn.UsuarioModificacion,
																	   businessUnitEn.TerminalModificacion,
																	   resultOldBusinessUnitSearch.FirstOrDefault(),
																	   resultCurrentBusinessUnitSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}

				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<BusinessUnitConfigurationEL>> BusinessUnitConfigurationSearch(BusinessUnitConfigurationRequest filter)
		{
			var processResult = new ProcessResult<List<BusinessUnitConfigurationEL>>();
			try
			{
				var resultBusinessUnitConfigurationEn = new List<BusinessUnitConfigurationEN>();

				using (businessUnitConfiguration = new BusinessUnitConfigurationEN(new RepositoryStoredProcedure<BusinessUnitConfigurationEN>(dbContext)))
				{
					resultBusinessUnitConfigurationEn = businessUnitConfiguration.BusinessUnitConfigurationSearch(
																									filter.BusinessUnitCode,
																									filter.BusinessUnitConfigurationCode,
																									filter.BusinessUnitCodeContext,
																									filter.CultureCode,
																									filter.RegistrationStatus,
																									filter.PageNo,
																									filter.PageSize);
				}
				var listBusinessUnitConfiguration = new List<BusinessUnitConfigurationEL>();
				foreach (var item in resultBusinessUnitConfigurationEn)
				{
					var businessUnitConfigurationEl = new BusinessUnitConfigurationEL();
					businessUnitConfigurationEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					businessUnitConfigurationEl.BusinessUnitConfigurationCode = item.CodigoUnidadNegocioConfiguracion;
					businessUnitConfigurationEl.Culture = CultureSearch(new CultureRequest() { CultureCode = item.CodigoCultura, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
					businessUnitConfigurationEl.TimeZoneCode = item.CodigoZonaHoraria;
					businessUnitConfigurationEl.DescriptionTimeZone = item.DescripcionZonaHoraria;
					businessUnitConfigurationEl.RowsPerPage = item.FilasPorPagina;
					businessUnitConfigurationEl.DisplayFormReport = item.FormaVisualizacionReporte;
					businessUnitConfigurationEl.DescriptionDisplayFormReport = item.DescripcionFormaVisualizacionReporte;
					businessUnitConfigurationEl.MinimumNumberCharactersGloss = item.MinimoCaracteresGlosa;
					businessUnitConfigurationEl.MinimumNumberVowelGloss = item.MinimoVocalesGlosa;
					businessUnitConfigurationEl.CompanyLogo = item.LogoCompania;
					businessUnitConfigurationEl.ReportLogo = item.LogoReporte;
					businessUnitConfigurationEl.CollapseMenuIndicator = item.IndicadorContraerMenu;
					businessUnitConfigurationEl.RegistrationStatus = item.EstadoRegistro;
					businessUnitConfigurationEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;
					businessUnitConfigurationEl.RowId = item.RowId;
					businessUnitConfigurationEl.RowNumber = item.RowNumber;
					businessUnitConfigurationEl.RowsTotal = item.RowsTotal;

					listBusinessUnitConfiguration.Add(businessUnitConfigurationEl);
				}
				processResult.Result = listBusinessUnitConfiguration;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite registrar la Configuración de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Configuración de Unidad de Negocio</param>
		/// <returns>Indicador de Conformidad</returns>
		public ProcessResult<string> BusinessUnitConfigurationRegister(BusinessUnitConfigurationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCodeContext == null
					|| filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.CultureCode)
					|| filter.TimeZoneCode == null
					|| string.IsNullOrEmpty(filter.DisplayFormReport)
					|| filter.RowsPerPage == null
					|| filter.MinimumNumberCharactersGloss == null
					|| filter.MinimumNumberVowelsGloss == null
					|| filter.CollapseMenuIndicator == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var resultBusinessUnitConfigurationSearch = BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitCode = Convert.ToInt32(filter.BusinessUnitCode), RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultBusinessUnitConfigurationSearch.Count > 0)
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;

				var currentQueryBusinessUnitConfigurationCode = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_UNIDAD_NEGOCIO_CONFIGURACION" + "]), 0) + 1" }, new List<string>() { "MNT.UNIDAD_NEGOCIO_CONFIGURACION" }, null);
				var currentRecordBusinessUnitConfigurationCode = ExecuteDynamicQuery(currentQueryBusinessUnitConfigurationCode).FirstOrDefault();
				filter.BusinessUnitConfigurationCode = Convert.ToInt32(currentRecordBusinessUnitConfigurationCode[currentRecordBusinessUnitConfigurationCode.Keys.FirstOrDefault()]);

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				using (businessUnitConfiguration = new BusinessUnitConfigurationEN(new RepositoryStoredProcedure<BusinessUnitConfigurationEN>(dbContext)))
				{
					var businessUnitConfigurationEn = new BusinessUnitConfigurationEN()
					{
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoUnidadNegocioConfiguracion = Convert.ToInt32(filter.BusinessUnitConfigurationCode),
						CodigoCultura = filter.CultureCode,
						CodigoZonaHoraria = Convert.ToInt32(filter.TimeZoneCode),
						FormaVisualizacionReporte = filter.DisplayFormReport,
						LogoCompania = filter.CompanyLogo,
						LogoReporte = filter.ReportLogo,
						FilasPorPagina = Convert.ToByte(filter.RowsPerPage),
						MinimoCaracteresGlosa = filter.MinimumNumberCharactersGloss,
						MinimoVocalesGlosa = filter.MinimumNumberVowelsGloss,
						IndicadorContraerMenu = filter.CollapseMenuIndicator,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation,
						CodigoUnidadNegocioContexto = Convert.ToInt32(filter.BusinessUnitCodeContext)
					};

					quantityAffectedRecords = businessUnitConfiguration.BusinessUnitConfigurationRegister(businessUnitConfigurationEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewBusinessUnitConfigurationSearch = BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitCode = filter.BusinessUnitCode, BusinessUnitConfigurationCode = filter.BusinessUnitConfigurationCode, BusinessUnitCodeContext = filter.BusinessUnitCodeContext }).Result;
						this.PolicyAuditRegister(EnumeratedTable.UnidadNegocio.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCodeContext),
																	   filter.BusinessUnitConfigurationCode.ToString(),
																	   null,
																	   businessUnitConfigurationEn.UsuarioCreacion,
																	   businessUnitConfigurationEn.TerminalCreacion,
																	   null,
																	   resultNewBusinessUnitConfigurationSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite actualizar la Configuración de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Configuración de Unidad de Negocio</param>
		/// <returns>Indicador de conformidad</returns>
		public ProcessResult<string> BusinessUnitConfigurationUpdate(BusinessUnitConfigurationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitConfigurationCode == null
					|| filter.BusinessUnitCodeContext == null
					|| filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.CultureCode)
					|| filter.TimeZoneCode == null
					|| string.IsNullOrEmpty(filter.DisplayFormReport)
					|| filter.RowsPerPage == null
					|| filter.MinimumNumberCharactersGloss == null
					|| filter.MinimumNumberVowelsGloss == null
					|| filter.CollapseMenuIndicator == null
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var resultBusinessUnitConfigurationSearch = BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitConfigurationCode = filter.BusinessUnitConfigurationCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

					if (resultBusinessUnitConfigurationSearch.Any(item => item.BusinessUnitConfigurationCode != filter.BusinessUnitConfigurationCode))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}
				}

				int quantityAffectedRecords = 0;

				using (businessUnitConfiguration = new BusinessUnitConfigurationEN(new RepositoryStoredProcedure<BusinessUnitConfigurationEN>(dbContext)))
				{
					var businessUnitConfigurationEn = new BusinessUnitConfigurationEN()
					{
						CodigoUnidadNegocioConfiguracion = Convert.ToInt32(filter.BusinessUnitConfigurationCode),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoCultura = filter.CultureCode,
						CodigoZonaHoraria = Convert.ToInt32(filter.TimeZoneCode),
						FormaVisualizacionReporte = filter.DisplayFormReport,
						LogoCompania = filter.CompanyLogo,
						LogoReporte = filter.ReportLogo,
						FilasPorPagina = Convert.ToByte(filter.RowsPerPage),
						MinimoCaracteresGlosa = filter.MinimumNumberCharactersGloss,
						MinimoVocalesGlosa = filter.MinimumNumberVowelsGloss,
						IndicadorContraerMenu = filter.CollapseMenuIndicator,
						Observacion = filter.ModificationReason,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification,
						CodigoUnidadNegocioContexto = Convert.ToInt32(filter.BusinessUnitCodeContext)
					};

					var resultOldBusinessUnitConfigurationSearch = BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitConfigurationCode = filter.BusinessUnitConfigurationCode, BusinessUnitCodeContext = filter.BusinessUnitCodeContext }).Result;

					quantityAffectedRecords = businessUnitConfiguration.BusinessUnitConfigurationUpdate(businessUnitConfigurationEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentBusinessUnitConfigurationSearch = BusinessUnitConfigurationSearch(new BusinessUnitConfigurationRequest() { BusinessUnitConfigurationCode = filter.BusinessUnitConfigurationCode, BusinessUnitCodeContext = filter.BusinessUnitCodeContext }).Result;
						this.PolicyAuditRegister(EnumeratedTable.UnidadNegocioConfiguracion.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCodeContext),
																	   filter.BusinessUnitConfigurationCode.ToString(),
																	   businessUnitConfigurationEn.Observacion,
																	   businessUnitConfigurationEn.UsuarioModificacion,
																	   businessUnitConfigurationEn.TerminalModificacion,
																	   resultOldBusinessUnitConfigurationSearch.FirstOrDefault(),
																	   resultCurrentBusinessUnitConfigurationSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}

				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite obtener Logos de Configuración de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Configuración de Unidad de Negocio</param>
		/// <returns>Lista de Logos de Configuración de Unidad de Negocio</returns>
		public List<BusinessUnitConfigurationEL> GetLogoBusinessUnitConfiguration(BusinessUnitConfigurationRequest filter)
		{
			List<BusinessUnitConfigurationEL> businessUnitConfigurationEl = new List<BusinessUnitConfigurationEL>();
			using (businessUnitConfiguration = new BusinessUnitConfigurationEN(new RepositoryStoredProcedure<BusinessUnitConfigurationEN>(dbContext)))
			{
				var listBusinessUnitConfiguration = businessUnitConfiguration.GetLogoBusinessUnitConfiguration(Convert.ToInt32(filter.BusinessUnitConfigurationCode)).ToList();
				foreach (var itemUnidadNegocioConfiguracion in listBusinessUnitConfiguration)
				{
					BusinessUnitConfigurationEL lstBusinessUnitConfiguration = new BusinessUnitConfigurationEL();
					lstBusinessUnitConfiguration.CompanyLogo = itemUnidadNegocioConfiguracion.LogoCompania;
					lstBusinessUnitConfiguration.ReportLogo = itemUnidadNegocioConfiguracion.LogoReporte;
					businessUnitConfigurationEl.Add(lstBusinessUnitConfiguration);
				}
			}
			return businessUnitConfigurationEl;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Unidad de Negocio
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<CultureEL>> CultureSearch(CultureRequest filter)
		{
			var processResult = new ProcessResult<List<CultureEL>>();
			try
			{
				var resultCultureEn = new List<CultureEN>();

				using (culture = new CultureEN(new RepositoryStoredProcedure<CultureEN>(dbContext)))
				{
					resultCultureEn = culture.CultureSearch(filter.BusinessUnitCode,
															filter.CultureCode,
															filter.LanguageCode,
															filter.CountryCode,
															filter.CodeShortDateFormat,
															filter.CodeLongDateFormat,
															filter.CodeShortTimeFormat,
															filter.CodeLongTimeFormat,
															filter.CodeFormatIntegerNumber,
															filter.CodeFormatDecimalNumber,
															filter.UpperLimitYear,
															filter.RegistrationStatus,
															filter.PageNo,
															filter.PageSize);
				}
				var listCulture = new List<CultureEL>();
				foreach (var item in resultCultureEn)
				{
					var cultureEl = new CultureEL();
					cultureEl.CultureCode = item.CodigoCultura;
					cultureEl.LanguageCode = item.CodigoIdioma;
					cultureEl.LanguageName = item.NombreIdioma;
					cultureEl.CountryCode = item.CodigoPais;
					cultureEl.CountryName = item.NombrePais;
					cultureEl.CodeShortDateFormat = item.CodigoFormatoFechaCorta;
					cultureEl.DescriptionShortDateFormat = item.DescripcionFormatoFechaCorta;
					cultureEl.CodeLongDateFormat = item.CodigoFormatoFechaLarga;
					cultureEl.DescriptionLongDateFormat = item.DescripcionFormatoFechaLarga;
					cultureEl.CodeShortTimeFormat = item.CodigoFormatoHoraCorta;
					cultureEl.DescriptionShortTimeFormat = item.DescripcionFormatoHoraCorta;
					cultureEl.CodeLongTimeFormat = item.CodigoFormatoHoraLarga;
					cultureEl.DescriptionLongTimeFormat = item.DescripcionFormatoHoraLarga;
					cultureEl.CodeFormatIntegerNumber = item.CodigoFormatoNumeroEntero;
					cultureEl.DescriptionFormatIntegerNumber = item.DescripcionFormatoNumeroEntero;
					cultureEl.CodeFormatDecimalNumber = item.CodigoFormatoNumeroDecimal;
					cultureEl.DescriptionFormatDecimalNumber = item.DescripcionFormatoNumeroDecimal;
					cultureEl.UpperLimitYear = item.LimiteSuperiorAnio;
					cultureEl.LowerLimitYear = (short)(item.LimiteSuperiorAnio - 99);
					cultureEl.RangeLimitConcatenatedYear = cultureEl.LowerLimitYear + " - " + cultureEl.UpperLimitYear;
					cultureEl.RegistrationStatus = item.EstadoRegistro;
					cultureEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					switch (item.DescripcionFormatoNumeroEntero)
					{
						case "#,##0":
							cultureEl.IntegerThousandsSeparator = ",";
							break;
						case "#.##0":
							cultureEl.IntegerThousandsSeparator = ".";
							break;
					}

					switch (item.DescripcionFormatoNumeroDecimal)
					{
						case "#,##0.00":
							cultureEl.DecimalThousandsSeparator = ",";
							cultureEl.DecimalSeparator = ".";
							break;
						case "#.##0,00":
							cultureEl.DecimalThousandsSeparator = ".";
							cultureEl.DecimalSeparator = ",";
							break;
					}
					cultureEl.RowId = item.RowId;
					cultureEl.RowNumber = item.RowNumber;
					cultureEl.RowsTotal = item.RowsTotal;

					listCulture.Add(cultureEl);
				}
				processResult.Result = listCulture;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Cultura
		/// </summary>
		/// <param name="filter">Cultura a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Cultura existente</returns>
		public ProcessResult<string> CultureRegister(CultureRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (string.IsNullOrEmpty(filter.CultureCode)
					|| string.IsNullOrEmpty(filter.LanguageCode)
					|| string.IsNullOrEmpty(filter.CountryCode)
					|| filter.CodeShortDateFormat == null
					|| filter.CodeLongDateFormat == null
					|| filter.CodeShortTimeFormat == null
					|| filter.CodeLongTimeFormat == null
					|| filter.CodeFormatIntegerNumber == null
					|| filter.CodeFormatDecimalNumber == null
					|| filter.UpperLimitYear == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var resultCultureSearch = CultureSearch(new CultureRequest() { CultureCode = filter.CultureCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultCultureSearch.Count > 0)
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				using (culture = new CultureEN(new RepositoryStoredProcedure<CultureEN>(dbContext)))
				{
					var cultureEn = new CultureEN()
					{
						CodigoCultura = filter.CultureCode,
						CodigoIdioma = filter.LanguageCode,
						CodigoPais = filter.CountryCode,
						CodigoFormatoFechaCorta = Convert.ToInt32(filter.CodeShortDateFormat),
						CodigoFormatoFechaLarga = Convert.ToInt32(filter.CodeLongDateFormat),
						CodigoFormatoHoraCorta = Convert.ToInt32(filter.CodeShortTimeFormat),
						CodigoFormatoHoraLarga = Convert.ToInt32(filter.CodeLongTimeFormat),
						CodigoFormatoNumeroEntero = Convert.ToInt32(filter.CodeFormatIntegerNumber),
						CodigoFormatoNumeroDecimal = Convert.ToInt32(filter.CodeFormatDecimalNumber),
						LimiteSuperiorAnio = (short)filter.UpperLimitYear,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation,
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode)
					};

					quantityAffectedRecords = culture.CultureRegister(cultureEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewCultureSearch = CultureSearch(new CultureRequest() { CultureCode = filter.CultureCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Cultura.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.CultureCode.ToString(),
																	   null,
																	   cultureEn.UsuarioCreacion,
																	   cultureEn.TerminalCreacion,
																	   null,
																	   resultNewCultureSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modificación de Cultura
		/// </summary>
		/// <param name="filter">Cultura a Modificar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Cultura existente</returns>
		public ProcessResult<string> CultureUpdate(CultureRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (string.IsNullOrEmpty(filter.CultureCode)
					|| string.IsNullOrEmpty(filter.LanguageCode)
					|| string.IsNullOrEmpty(filter.CountryCode)
					|| filter.CodeShortDateFormat == null
					|| filter.CodeLongDateFormat == null
					|| filter.CodeShortTimeFormat == null
					|| filter.CodeLongTimeFormat == null
					|| filter.CodeFormatIntegerNumber == null
					|| filter.CodeFormatDecimalNumber == null
					|| filter.UpperLimitYear == null
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var resultCultureSearch = CultureSearch(new CultureRequest() { CultureCode = filter.CultureCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

					if (resultCultureSearch.Any(item => item.CultureCode != filter.CultureCode))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);

						return processResult;
					}
				}

				int quantityAffectedRecords = 0;

				using (culture = new CultureEN(new RepositoryStoredProcedure<CultureEN>(dbContext)))
				{
					var culturaEn = new CultureEN()
					{
						CodigoCultura = filter.CultureCode,
						CodigoIdioma = filter.LanguageCode,
						CodigoPais = filter.CountryCode,
						CodigoFormatoFechaCorta = Convert.ToInt32(filter.CodeShortDateFormat),
						CodigoFormatoFechaLarga = Convert.ToInt32(filter.CodeLongDateFormat),
						CodigoFormatoHoraCorta = Convert.ToInt32(filter.CodeShortTimeFormat),
						CodigoFormatoHoraLarga = Convert.ToInt32(filter.CodeLongTimeFormat),
						CodigoFormatoNumeroEntero = Convert.ToInt32(filter.CodeFormatIntegerNumber),
						CodigoFormatoNumeroDecimal = Convert.ToInt32(filter.CodeFormatDecimalNumber),
						LimiteSuperiorAnio = (short)filter.UpperLimitYear,
						Observacion = filter.ModificationReason,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification,
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode)
					};

					var resultOldCulturaSearch = CultureSearch(new CultureRequest() { CultureCode = filter.CultureCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = culture.CultureUpdate(culturaEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentCultureSearch = CultureSearch(new CultureRequest() { CultureCode = filter.CultureCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Cultura.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.CultureCode.ToString(),
																	   culturaEn.Observacion,
																	   culturaEn.UsuarioModificacion,
																	   culturaEn.TerminalModificacion,
																	   resultOldCulturaSearch.FirstOrDefault(),
																	   resultCurrentCultureSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}

				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Parametros
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<ParameterEL>> ParameterSearch(ParameterRequest filter)
		{
			var processResult = new ProcessResult<List<ParameterEL>>();
			try
			{
				var resultParameterEn = new List<ParameterEN>();

				using (parameter = new ParameterEN(new RepositoryStoredProcedure<ParameterEN>(dbContext)))
				{
					resultParameterEn = parameter.ParameterSearch(
						filter.BusinessUnitCode,
						filter.CodeParameter,
						filter.Code,
						filter.CodeApproximate,
						filter.ParameterName,
						filter.ParameterDescription,
						filter.CodeParameterType,
						filter.ParameterSystemIndicator,
						filter.AllowAddValueIndicator,
						filter.AllowModifyValueIndicator,
						filter.RegistrationStatus,
						filter.PageNo,
						filter.PageSize);
				}
				var listParameterEl = new List<ParameterEL>();
				foreach (var item in resultParameterEn)
				{
					var parameterEl = new ParameterEL();
					parameterEl.CodeParameter = item.CodigoParametro;
					parameterEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					parameterEl.Code = item.Codigo;
					parameterEl.NameParameter = item.Nombre;
					parameterEl.DescriptionParameter = item.Descripcion;
					parameterEl.ParameterSystemIndicator = item.IndicadorParametroSistema;
					parameterEl.AllowAddValueIndicator = item.IndicadorPermiteAgregarValor;
					parameterEl.AllowModifyValueIndicator = item.IndicadorPermiteModificarValor;
					parameterEl.CodeParameterType = item.TipoParametro;
					parameterEl.DescriptionParameterType = item.DescripcionTipoParametro;
					parameterEl.RegistrationStatus = item.EstadoRegistro;
					parameterEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					parameterEl.RowId = item.RowId;
					parameterEl.RowNumber = item.RowNumber;
					parameterEl.RowsTotal = item.RowsTotal;

					listParameterEl.Add(parameterEl);
				}
				processResult.Result = listParameterEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de un Parámetro
		/// </summary>
		/// <param name="filter">Parámetro a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Existe otro parametro en la misma unidad de negocio y con el mismo nombre</returns>
		public ProcessResult<string> ParameterRegister(ParameterRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.Code)
					|| string.IsNullOrEmpty(filter.CodeParameterType)
					|| string.IsNullOrEmpty(filter.ParameterName)
					|| string.IsNullOrEmpty(filter.ParameterDescription)
					|| filter.AllowAddValueIndicator == null
					|| filter.AllowModifyValueIndicator == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				var resultParameterSearch = ParameterSearch(new ParameterRequest() { BusinessUnitCode = filter.BusinessUnitCode, RegistrationStatus = filter.RegistrationStatus }).Result;

				if (resultParameterSearch.Any(item => item.Code.ToUpper().Trim() == filter.Code.ToUpper().Trim() || item.NameParameter.ToUpper().Trim() == filter.ParameterName.ToUpper().Trim()))
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;
				var queryActual = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_PARAMETRO" + "]), 0) + 1" }, new List<string>() { "MNT.PARAMETRO" });
				var registroActual = ExecuteDynamicQuery(queryActual).FirstOrDefault();
				filter.CodeParameter = Convert.ToInt32(registroActual[registroActual.Keys.FirstOrDefault()]);
				using (parameter = new ParameterEN(new RepositoryStoredProcedure<ParameterEN>(dbContext)))
				{
					var parameterEn = new ParameterEN()
					{
						CodigoParametro = Convert.ToInt32(filter.CodeParameter),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						Codigo = filter.Code,
						Nombre = filter.ParameterName,
						Descripcion = filter.ParameterDescription,
						TipoParametro = filter.CodeParameterType,
						IndicadorPermiteAgregarValor = Convert.ToBoolean(filter.AllowAddValueIndicator),
						IndicadorPermiteModificarValor = Convert.ToBoolean(filter.AllowModifyValueIndicator),
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation
					};

					quantityAffectedRecords = parameter.ParameterRegister(parameterEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewParameterSearch = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Parametro.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.Code,
																	   null,
																	   parameterEn.UsuarioCreacion,
																	   parameterEn.TerminalCreacion,
																	   null,
																	   resultNewParameterSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/

						var resultSecction1 = ParameterSectionRegister(new ParameterSectionRequest()
						{
							Name = filter.LabelCodeSection,
							CodeParameterSectionType = Enumerated.SectionType.String,
							ReadOnlyIndicator = true,
							RequiredIndicator = true,
							CreationIndicator = true,
							CodeParameter = filter.CodeParameter,
							BusinessUnitCode = filter.BusinessUnitCode,
							UserCreation = filter.UserCreation,
							TerminalCreation = filter.TerminalCreation
						});
						if (resultSecction1.Result != "1")
						{
							return resultSecction1;
						}
						var resultSecction2 = ParameterSectionRegister(new ParameterSectionRequest()
						{
							Name = filter.LabelDescriptionSection,
							CodeParameterSectionType = Enumerated.SectionType.String,
							ReadOnlyIndicator = false,
							RequiredIndicator = false,
							CreationIndicator = true,
							CodeParameter = filter.CodeParameter,
							BusinessUnitCode = filter.BusinessUnitCode,
							UserCreation = filter.UserCreation,
							TerminalCreation = filter.TerminalCreation
						});
						if (resultSecction2.Result != "1")
						{
							return resultSecction2;
						}
						if (filter.CodeParameterType == Enumerated.ParameterType.RangeValues)
						{
							var resultSecction3 = ParameterSectionRegister(new ParameterSectionRequest()
							{
								Name = filter.LabelBeginSection,
								CodeParameterSectionType = Enumerated.SectionType.Decimal,
								ReadOnlyIndicator = false,
								RequiredIndicator = true,
								RangeIndicator = Enumerated.RangeType.Begin,
								CreationIndicator = true,
								CodeParameter = filter.CodeParameter,
								BusinessUnitCode = filter.BusinessUnitCode,
								UserCreation = filter.UserCreation,
								TerminalCreation = filter.TerminalCreation
							});
							if (resultSecction3.Result != "1")
							{
								return resultSecction3;
							}
							var resultSecction4 = ParameterSectionRegister(new ParameterSectionRequest()
							{
								Name = filter.LabelEndSection,
								CodeParameterSectionType = Enumerated.SectionType.Decimal,
								ReadOnlyIndicator = false,
								RequiredIndicator = false,
								CreationIndicator = true,
								RangeIndicator = Enumerated.RangeType.End,
								CodeParameter = filter.CodeParameter,
								BusinessUnitCode = filter.BusinessUnitCode,
								UserCreation = filter.UserCreation,
								TerminalCreation = filter.TerminalCreation
							});
							if (resultSecction4.Result != "1")
							{
								return resultSecction4;
							}
						}
						result = "1";
						processResult.Result = result;
						processResult.IsSuccess = true;
						processResult.Exception = null;
						return processResult;
					}
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modificación de un Parámetro
		/// </summary>
		/// <param name="filter">Parámetro a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Existe otro parámetro en la misma unidad de negocio y con el mismo nombre</returns>
		public ProcessResult<string> ParameterUpdate(ParameterRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.ParameterName)
					|| string.IsNullOrEmpty(filter.ParameterDescription)
					|| filter.AllowAddValueIndicator == null
					|| filter.AllowModifyValueIndicator == null
					|| filter.RegistrationStatus == null
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				filter.RegistrationStatus = filter.RegistrationStatus ?? Enumerated.RegistrationStatus.Active;

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var resultParameterSearch = ParameterSearch(new ParameterRequest() { BusinessUnitCode = filter.BusinessUnitCode, RegistrationStatus = filter.RegistrationStatus }).Result;

					if (resultParameterSearch.Any(item => (item.Code.ToUpper().Trim() == filter.Code.ToUpper().Trim() || item.NameParameter.ToUpper().Trim() == filter.ParameterName.ToUpper().Trim()) && item.CodeParameter != filter.CodeParameter))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);

						return processResult;
					}
				}
				else
				{
					var resultParameterSearchInTableCombinationOrder = CombinationOrderSearch(new CombinationOrderRequest() { BusinessUnitCode = filter.BusinessUnitCode, ParameterCode = filter.CodeParameter, RegistrationStatus = Enumerated.RegistrationStatus.Active });
					var resultParameterSearchInTableFormula = FormulaSearch(new FormulaRequest() { BusinessUnitCode = filter.BusinessUnitCode, ParameterCode = filter.CodeParameter, RegistrationStatus = Enumerated.RegistrationStatus.Active });

					if (resultParameterSearchInTableFormula.Result.Count > 0 && resultParameterSearchInTableCombinationOrder.Result.Count > 0)
					{
						result = "4";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}

					if (resultParameterSearchInTableCombinationOrder.Result.Count > 0)
					{
						result = "5";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}

					if (resultParameterSearchInTableFormula.Result.Count > 0)
					{
						result = "6";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}
				}

				int quantityAffectedRecords = 0;
				using (parameter = new ParameterEN(new RepositoryStoredProcedure<ParameterEN>(dbContext)))
				{
					var parameterEn = new ParameterEN()
					{
						CodigoParametro = Convert.ToInt32(filter.CodeParameter),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						Nombre = filter.ParameterName,
						Descripcion = filter.ParameterDescription,
						IndicadorPermiteAgregarValor = Convert.ToBoolean(filter.AllowAddValueIndicator),
						IndicadorPermiteModificarValor = Convert.ToBoolean(filter.AllowModifyValueIndicator),
						EstadoRegistro = filter.RegistrationStatus,
						Observacion = filter.ModificationReason,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					/**Auditoría**/
					var resultOldParameterSearch = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = parameter.ParameterUpdate(parameterEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentParameterSearch = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Parametro.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   resultOldParameterSearch.FirstOrDefault().Code,
																	   parameterEn.Observacion,
																	   parameterEn.UsuarioModificacion,
																	   parameterEn.TerminalModificacion,
																	   resultOldParameterSearch.FirstOrDefault(),
																	   resultCurrentParameterSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}

				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Parametros
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<ParameterSectionEL>> ParameterSectionSearch(ParameterSectionRequest filter)
		{
			var processResult = new ProcessResult<List<ParameterSectionEL>>();
			try
			{
				var resultParameterSectionEn = new List<ParameterSectionEN>();

				using (parameterSection = new ParameterSectionEN(new RepositoryStoredProcedure<ParameterSectionEN>(dbContext)))
				{
					resultParameterSectionEn = parameterSection.ParameterSectionSearch(filter.BusinessUnitCode,
																						filter.CodeParameter,
																						filter.CodeParameterSection,
																						filter.Name,
																						filter.ReadOnlyIndicator,
																						filter.RequiredIndicator,
																						filter.CodeParameterSectionType,
																						filter.RegistrationStatus,
																						filter.PageNo,
																						filter.PageSize
																						);
				}

				var listParameterSectionEl = new List<ParameterSectionEL>();

				foreach (var item in resultParameterSectionEn)
				{
					var parameterSectionEl = new ParameterSectionEL();
					parameterSectionEl.CodeParameter = item.CodigoParametro;
					parameterSectionEl.CodeSection = item.CodigoSeccion;
					parameterSectionEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					parameterSectionEl.NameSection = item.Nombre;
					parameterSectionEl.ReadOnlyIndicator = item.IndicadorSoloLectura;
					parameterSectionEl.RequiredIndicator = item.IndicadorObligatorio;
					parameterSectionEl.RangeIndicator = item.IndicadorRango;
					parameterSectionEl.CreationIndicator = item.IndicadorCreacion;
					parameterSectionEl.CodeParameterSectionType = item.TipoSeccion;
					parameterSectionEl.DescriptionParameterSectionType = item.DescripcionTipoSeccion;
					parameterSectionEl.RegistrationStatus = item.EstadoRegistro;
					parameterSectionEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					parameterSectionEl.RowId = item.RowId;
					parameterSectionEl.RowNumber = item.RowNumber;
					parameterSectionEl.RowsTotal = item.RowsTotal;

					listParameterSectionEl.Add(parameterSectionEl);
				}

				processResult.Result = listParameterSectionEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de un Parámetro
		/// </summary>
		/// <param name="filter">Parámetro a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Existe otro parametro sección en la misma unidad de negocio y con el mismo nombre</returns>
		public ProcessResult<string> ParameterSectionRegister(ParameterSectionRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| filter.CodeParameter == null
					|| string.IsNullOrEmpty(filter.Name)
					|| string.IsNullOrEmpty(filter.CodeParameterSectionType)
					|| filter.ReadOnlyIndicator == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}
				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;

				var resultParameterSectionSearch = ParameterSectionSearch(new ParameterSectionRequest() { BusinessUnitCode = filter.BusinessUnitCode, CodeParameter = filter.CodeParameter, RegistrationStatus = filter.RegistrationStatus }).Result;

				if (resultParameterSectionSearch.Any(item => item.NameSection.ToUpper() == filter.Name.ToUpper()))
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;
				Dictionary<string, string> conditionsCurrent = new Dictionary<string, string>();
				conditionsCurrent.Add("CODIGO_PARAMETRO", " = " + filter.CodeParameter);
				var queryActual = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_SECCION" + "]), 0) + 1" }, new List<string>() { "MNT.PARAMETRO_SECCION" }, conditionsCurrent);
				var registroActual = ExecuteDynamicQuery(queryActual).FirstOrDefault();
				int codeParameterSection = Convert.ToInt32(registroActual[registroActual.Keys.FirstOrDefault()]);

				using (parameterSection = new ParameterSectionEN(new RepositoryStoredProcedure<ParameterSectionEN>(dbContext)))
				{
					var parameterSectionEn = new ParameterSectionEN()
					{
						CodigoParametro = Convert.ToInt32(filter.CodeParameter),
						CodigoSeccion = codeParameterSection,
						Nombre = filter.Name,
						IndicadorSoloLectura = Convert.ToBoolean(filter.ReadOnlyIndicator),
						IndicadorObligatorio = Convert.ToBoolean(filter.RequiredIndicator),
						IndicadorRango = filter.RangeIndicator,
						IndicadorCreacion = Convert.ToBoolean(filter.CreationIndicator),
						TipoSeccion = filter.CodeParameterSectionType,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation,
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode)
					};

					quantityAffectedRecords = parameterSection.ParameterSectionRegister(parameterSectionEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var parameterCodeThreeDigits = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						var resultNewParameterSectionSearch = ParameterSectionSearch(new ParameterSectionRequest() { CodeParameter = filter.CodeParameter, CodeParameterSection = codeParameterSection, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.ParametroSeccion.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   parameterCodeThreeDigits.FirstOrDefault().Code,
																	   null,
																	   parameterSectionEn.UsuarioCreacion,
																	   parameterSectionEn.TerminalCreacion,
																	   null,
																	   resultNewParameterSectionSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la Modificación de un Parámetro
		/// </summary>
		/// <param name="filter">Parámetro a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Existe otro parametro sección en la misma unidad de negocio y con el mismo nombre</returns>
		public ProcessResult<string> ParameterSectionUpdate(ParameterSectionRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| filter.CodeParameter == null
					|| string.IsNullOrEmpty(filter.Name)
					|| string.IsNullOrEmpty(filter.CodeParameterSectionType)
					|| filter.ReadOnlyIndicator == null
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}
				filter.RegistrationStatus = (filter.RegistrationStatus == null || filter.RegistrationStatus.Trim() == "") ? Enumerated.RegistrationStatus.Active : filter.RegistrationStatus;
				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var resultParameterSectionSearch = ParameterSectionSearch(new ParameterSectionRequest() { BusinessUnitCode = filter.BusinessUnitCode, CodeParameter = filter.CodeParameter, RegistrationStatus = filter.RegistrationStatus }).Result;

					if (resultParameterSectionSearch.Any(item => item.NameSection.ToUpper() == filter.Name.ToUpper() && item.CodeSection != filter.CodeParameterSection))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}
				}

				int quantityAffectedRecords = 0;

				using (parameterSection = new ParameterSectionEN(new RepositoryStoredProcedure<ParameterSectionEN>(dbContext)))
				{
					var parameterSectionEn = new ParameterSectionEN()
					{
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoParametro = Convert.ToInt32(filter.CodeParameter),
						CodigoSeccion = Convert.ToInt32(filter.CodeParameterSection),
						Nombre = filter.Name,
						IndicadorSoloLectura = Convert.ToBoolean(filter.ReadOnlyIndicator),
						IndicadorObligatorio = Convert.ToBoolean(filter.RequiredIndicator),
						IndicadorCreacion = Convert.ToBoolean(filter.CreationIndicator),
						TipoSeccion = filter.CodeParameterSectionType,
						Observacion = filter.ModificationReason,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					/**Auditoría**/
					var resultOldParameterSectionSearch = ParameterSectionSearch(new ParameterSectionRequest() { CodeParameter = filter.CodeParameter, CodeParameterSection = filter.CodeParameterSection, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = parameterSection.ParameterSectionUpdate(parameterSectionEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var parameterCodeThreeDigits = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						var resultCurrentParameterSectionSearch = ParameterSectionSearch(new ParameterSectionRequest() { CodeParameter = filter.CodeParameter, CodeParameterSection = filter.CodeParameterSection, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.ParametroSeccion.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   parameterCodeThreeDigits.FirstOrDefault().Code,
																	   parameterSectionEn.Observacion,
																	   parameterSectionEn.UsuarioModificacion,
																	   parameterSectionEn.TerminalModificacion,
																	   resultOldParameterSectionSearch.FirstOrDefault(),
																	   resultCurrentParameterSectionSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Parametros
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<ParameterValueEL>> ParameterValueSearch(ParameterValueRequest filter)
		{
			var processResult = new ProcessResult<List<ParameterValueEL>>();
			try
			{
				var resultParametervalueEn = new List<ParameterValueEN>();

				using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
				{
					resultParametervalueEn = parameterValue.ParameterValueSearch(Convert.ToInt32(filter.BusinessUnitCode), filter.CodeParameter, filter.Code, filter.CodeSection, filter.CodeValue, filter.Value, filter.RegistrationStatus);
				}

				var listParameterValueEl = new List<ParameterValueEL>();
				ParameterValueEL parameterValueEl = new ParameterValueEL();
				parameterValueEl.RecordValueString = new Dictionary<string, string>();
				parameterValueEl.RecordValueObject = new Dictionary<string, object>();
				for (var iterator = 0; iterator < resultParametervalueEn.Count; iterator++)
				{
					var itemValue = resultParametervalueEn[iterator];
					string valorString = null;
					object valorObject = null;
					try
					{
						switch (itemValue.TipoSeccion)
						{
							case Enumerated.SectionType.Integer:
								valorObject = Convert.ToInt32(itemValue.Valor);
								valorString = (environment != null) ? Utility.IntFormatString((int)valorObject, environment.IntegerFormat, environment.InformationIntegerFormat) : "";
								break;
							case Enumerated.SectionType.Decimal:
								string[] value = itemValue.Valor.Split('.');
								int partIntegerValue = 0;
								int partDecimalValue = 0;

								partIntegerValue = Convert.ToInt32(value[0]);
								partDecimalValue = 0;

								if (value.Count() == 2)
								{
									partDecimalValue = Convert.ToInt32(value[1]);
								}
								valorObject = Convert.ToDecimal(partIntegerValue + ((value.Count() == 2) ? (partDecimalValue / Math.Pow(10, value[1].Length)) : 0));
								valorString = (environment != null) ? Utility.DecimalFormatString((decimal)valorObject, environment.DecimalFormat, environment.InformationDecimalFormat) : "";
								break;
							case Enumerated.SectionType.Date:
								valorObject = Utility.StringFormatDatetime(itemValue.Valor);
								valorString = (environment != null) ? Utility.DatetimeFormatString((DateTime)valorObject, environment.ShortDateFormat) : "";
								break;
							default:
								valorObject = itemValue.Valor;
								valorString = itemValue.Valor;
								break;
						}
					}
					catch (Exception)
					{
						valorObject = null;
						valorString = "";
					}

					//Setear la Sección con su respectivo Valor
					parameterValueEl.RecordValueString.Add(itemValue.CodigoSeccion.ToString(), valorString);

					parameterValueEl.RecordValueObject.Add(itemValue.CodigoSeccion.ToString(), valorObject);

					if (parameterValueEl.RegistrationStatus == null || parameterValueEl.RegistrationStatus == Enumerated.RegistrationStatus.Cancelled)
					{
						parameterValueEl.RegistrationStatus = itemValue.EstadoRegistro;
						parameterValueEl.DescriptionRegistrationStatus = itemValue.DescripcionEstadoRegistro;
					}

					//Añade el registro en la Lista de Parametros según su quiebre
					if (iterator == resultParametervalueEn.Count - 1 || itemValue.CodigoValor != resultParametervalueEn[iterator + 1].CodigoValor)
					{
						parameterValueEl.CodeValue = itemValue.CodigoValor;
						parameterValueEl.Code = itemValue.Codigo;
						parameterValueEl.CodeParameterType = itemValue.TipoParametro;
						parameterValueEl.CodeParameter = itemValue.CodigoParametro;
						listParameterValueEl.Add(parameterValueEl);
						//Limpiar variable
						parameterValueEl = new ParameterValueEL();
						parameterValueEl.RecordValueString = new Dictionary<string, string>();
						parameterValueEl.RecordValueObject = new Dictionary<string, object>();
					}
				}

				processResult.Result = listParameterValueEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Parámetro Valor
		/// </summary>
		/// <param name="filter">Parametro Valor a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: No se puede repetir el Registro</returns>
		public ProcessResult<string> ParameterValueRegister(ParameterValueRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if ((filter.RecordValueString == null)
					|| filter.CodeParameter == null
					|| filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				filter.Code = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter }).Result.FirstOrDefault().Code;

				Dictionary<string, string> conditionsCurrent = new Dictionary<string, string>();
				conditionsCurrent.Add("CODIGO_UNIDAD_NEGOCIO", " = " + filter.BusinessUnitCode);
				conditionsCurrent.Add("CODIGO_PARAMETRO", " = " + filter.CodeParameter);
				var queryActual = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_VALOR" + "]), 0) + 1" }, new List<string>() { "MNT.PARAMETRO_VALOR" }, conditionsCurrent);
				var registroActual = ExecuteDynamicQuery(queryActual).FirstOrDefault();
				filter.CodeValue = Convert.ToInt32(registroActual[registroActual.Keys.FirstOrDefault()]);

				foreach (var item in filter.RecordValueString)
				{
					int quantityAffectedRecords = 0;
					string value = null;
					ParameterSectionEL sectionCurrent = ParameterSectionSearch(new ParameterSectionRequest() { CodeParameter = filter.CodeParameter, CodeParameterSection = Convert.ToInt32(item.Key), RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();

					switch (sectionCurrent.CodeParameterSectionType)
					{
						case Enumerated.SectionType.Integer:
							value = Convert.ToString(Utility.StringFormatInt(item.Value, environment.IntegerFormat, environment.InformationIntegerFormat));
							break;
						case Enumerated.SectionType.Decimal:
							value = Convert.ToString(Utility.StringFormatDecimal(item.Value, environment.DecimalFormat, environment.InformationDecimalFormat)).Replace(',', '.');
							break;
						case Enumerated.SectionType.Date:
							value = Utility.DatetimeFormatString(Utility.StringFormatDatetime(item.Value, environment.ShortDateFormat));
							break;
						default:
							value = item.Value;
							break;
					}
					if (sectionCurrent.CodeSection == 1)
					{
						var parameterValueCodeValidation = ParameterValueSearch(new ParameterValueRequest() { CodeParameter = filter.CodeParameter, CodeSection = 1, BusinessUnitCode = filter.BusinessUnitCode, RegistrationStatus = Enumerated.RegistrationStatus.Active });
						if (parameterValueCodeValidation.IsSuccess && parameterValueCodeValidation.Result.Any(itemCodeValidation => itemCodeValidation.RecordValueString.Any(itemRecordValueString => itemRecordValueString.Value == value)))
						{
							result = "3";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);

							return processResult;
						}
					}

					var parameterValueEn = new ParameterValueEN()
					{
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoParametro = Convert.ToInt32(filter.CodeParameter),
						CodigoSeccion = Convert.ToInt32(item.Key),
						CodigoValor = (int)filter.CodeValue,
						Valor = value,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation
					};

					using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
					{
						quantityAffectedRecords = parameterValue.ParameterValueRegister(parameterValueEn);
					}
					if (quantityAffectedRecords > 0)
					{
						result = "1";
						processResult.Result = result;
						processResult.IsSuccess = true;
						processResult.Exception = null;

						//** Proceso para la Auditoria - Inicio **/
						var resultParametervalueEn = new List<ParameterValueEN>();
						using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
						{
							resultParametervalueEn = parameterValue.ParameterValueSearch(Convert.ToInt32(filter.BusinessUnitCode), filter.CodeParameter, filter.Code, Convert.ToInt32(item.Key), filter.CodeValue, null, null);
						}

						this.PolicyAuditRegister(EnumeratedTable.ParametroValor.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.Code,
																	   null,
																	   parameterValueEn.UsuarioCreacion,
																	   parameterValueEn.TerminalCreacion,
																	   null,
																	   resultParametervalueEn.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modifición de Parámetro Valor
		/// </summary>
		/// <param name="filter">Parámetro valor a Modificar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: No se puede repetir el Registro</returns>
		public ProcessResult<string> ParameterValueUpdate(ParameterValueRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.RecordValueString == null
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				var resultParameterSectionSearch = ParameterSectionSearch(new ParameterSectionRequest()
				{
					BusinessUnitCode = filter.BusinessUnitCode,
					CodeParameter = filter.CodeParameter,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result;

				foreach (var itemSection in resultParameterSectionSearch)
				{
					if (itemSection.ReadOnlyIndicator)
					{
						var valueReadOnly = ParameterValueSearch(new ParameterValueRequest()
						{
							BusinessUnitCode = filter.BusinessUnitCode,
							CodeParameter = filter.CodeParameter,
							CodeValue = filter.CodeValue
						}).Result.FirstOrDefault().RecordValueString;

						string value = (valueReadOnly.Any(item => item.Key == itemSection.CodeSection.ToString())) ? valueReadOnly[itemSection.CodeSection.ToString()] : null;

						filter.RecordValueString.Add(itemSection.CodeSection.ToString(), value);
					}
					else
					{
						filter.RecordValueString[itemSection.CodeSection.ToString()] = filter.RecordValueString[itemSection.CodeSection.ToString()].ToString();
					}
				}

				if (filter.RecordValueString.Any(item => item.Key == "1") && filter.RecordValueString["1"] != null)
				{
					var parameterValueOld = ParameterValueSearch(new ParameterValueRequest()
					{
						BusinessUnitCode = filter.BusinessUnitCode,
						CodeParameter = filter.CodeParameter,
						CodeValue = filter.CodeValue
					}).Result.FirstOrDefault();

					string codeOld = parameterValueOld.RecordValueString.Where(item => item.Key == "1").FirstOrDefault().Value;

					if (codeOld != filter.RecordValueString["1"]
					 || (parameterValueOld.CodeParameterType == Enumerated.ParameterType.RangeValues &&
						(parameterValueOld.RecordValueString.Where(item => item.Key == "3").FirstOrDefault().Value != filter.RecordValueString["3"] || parameterValueOld.RecordValueString.Where(item => item.Key == "4").FirstOrDefault().Value != filter.RecordValueString["4"]))
					 || filter.RegistrationStatus == Enumerated.RegistrationStatus.Cancelled)
					{
						var resultParameterValueInTableParameterCombinationSearch = ParameterCombinationSearch(new ParameterCombinationRequest() { BusinessUnitCode = filter.BusinessUnitCode, CodeParameter = filter.CodeParameter, Value = codeOld, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;
						var resultParameterValueInTableFormulaSearch = FormulaSearch(new FormulaRequest() { BusinessUnitCode = filter.BusinessUnitCode, ParameterCode = filter.CodeParameter, Value = codeOld, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

						var countParameterCombination = 0;
						foreach (var item in resultParameterValueInTableParameterCombinationSearch)
						{
							countParameterCombination = CombinationSearch(new CombinationRequest() { BusinessUnitCode = filter.BusinessUnitCode, CombinationCode = item.CodeCombination, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.Count;
						}

						if (countParameterCombination > 0 && resultParameterValueInTableFormulaSearch.Count > 0)
						{
							result = "4";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);
							return processResult;
						}

						if (countParameterCombination > 0)
						{
							result = "5";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);
							return processResult;
						}

						if (resultParameterValueInTableFormulaSearch.Count > 0)
						{
							result = "6";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);
							return processResult;
						}
					}
				}

				filter.Code = ParameterSearch(new ParameterRequest() { CodeParameter = filter.CodeParameter }).Result.FirstOrDefault().Code;

				foreach (var item in filter.RecordValueString)
				{
					int quantityAffectedRecords = 0;
					string value = null;
					ParameterSectionEL sectionCurrent = ParameterSectionSearch(new ParameterSectionRequest() { CodeParameter = filter.CodeParameter, CodeParameterSection = Convert.ToInt32(item.Key), RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();

					switch (sectionCurrent.CodeParameterSectionType)
					{
						case Enumerated.SectionType.Integer:
							value = Convert.ToString(Utility.StringFormatInt(item.Value, environment.IntegerFormat, environment.InformationIntegerFormat));
							break;
						case Enumerated.SectionType.Decimal:
							value = Convert.ToString(Utility.StringFormatDecimal(item.Value, environment.DecimalFormat, environment.InformationDecimalFormat)).Replace(',', '.');
							break;
						case Enumerated.SectionType.Date:
							value = Utility.DatetimeFormatString(Utility.StringFormatDatetime(item.Value, environment.ShortDateFormat));
							break;
						default:
							value = item.Value;
							break;
					}
					if (sectionCurrent.CodeSection == 1)
					{
						var parameterValueCodeValidation = ParameterValueSearch(new ParameterValueRequest() { CodeParameter = filter.CodeParameter, CodeSection = 1, BusinessUnitCode = filter.BusinessUnitCode, RegistrationStatus = Enumerated.RegistrationStatus.Active });
						if (parameterValueCodeValidation.IsSuccess && parameterValueCodeValidation.Result.Any(itemCodeValidation => itemCodeValidation.CodeValue != filter.CodeValue && itemCodeValidation.RecordValueString.Any(itemRecordValueString => itemRecordValueString.Value == value)))
						{
							result = "3";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);

							return processResult;
						}
					}

					/**Auditoría**/
					var resultOldParametervalueEn = new List<ParameterValueEN>();
					using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
					{
						resultOldParametervalueEn = parameterValue.ParameterValueSearch(Convert.ToInt32(filter.BusinessUnitCode), filter.CodeParameter, filter.Code, Convert.ToInt32(item.Key), filter.CodeValue, null, null);
					}

					var resultOldParameterValueSearch = ParameterValueSearch(new ParameterValueRequest() { CodeParameter = filter.CodeParameter, CodeSection = Convert.ToInt32(item.Key), CodeValue = Convert.ToInt32(filter.CodeValue), BusinessUnitCode = filter.BusinessUnitCode }).Result;
					if (resultOldParameterValueSearch.Count > 0)
					{
						var parameterValueEn = new ParameterValueEN()
						{
							CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
							CodigoParametro = Convert.ToInt32(filter.CodeParameter),
							CodigoSeccion = Convert.ToInt32(item.Key),
							CodigoValor = Convert.ToInt32(filter.CodeValue),
							Valor = value,
							Observacion = filter.ModificationReason,
							EstadoRegistro = filter.RegistrationStatus,
							UsuarioModificacion = filter.UserModification,
							TerminalModificacion = filter.TerminalModification
						};
						using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
						{
							quantityAffectedRecords += parameterValue.ParameterValueUpdate(parameterValueEn);
						}
					}
					else
					{
						var parameterValueRegisterEn = new ParameterValueEN()
						{
							CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
							CodigoParametro = Convert.ToInt32(filter.CodeParameter),
							CodigoSeccion = Convert.ToInt32(item.Key),
							CodigoValor = Convert.ToInt32(filter.CodeValue),
							Valor = value,
							EstadoRegistro = filter.RegistrationStatus,
							UsuarioCreacion = filter.UserModification,
							TerminalCreacion = filter.TerminalModification
						};

						using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
						{
							quantityAffectedRecords = parameterValue.ParameterValueRegister(parameterValueRegisterEn);
						}
					}
					if (quantityAffectedRecords > 0)
					{
						result = "1";
						processResult.Result = result;
						processResult.IsSuccess = true;
						processResult.Exception = null;

						//** Proceso para la Auditoria - Inicio **/
						var resultNewParametervalueEn = new List<ParameterValueEN>();
						using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
						{
							resultNewParametervalueEn = parameterValue.ParameterValueSearch(Convert.ToInt32(filter.BusinessUnitCode), filter.CodeParameter, filter.Code, Convert.ToInt32(item.Key), filter.CodeValue, null, null);
						}
						this.PolicyAuditRegister(EnumeratedTable.ParametroValor.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.Code,
																	   filter.ModificationReason,
																	   filter.UserModification,
																	   filter.TerminalModification,
																	   (resultOldParametervalueEn.Count > 0) ? resultOldParametervalueEn.FirstOrDefault() : null,
																	   resultNewParametervalueEn.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite Buscar Provincias
		/// </summary>
		/// <param name="filter">Filtro de Provincia</param>
		/// <returns>Lista de Provincias</returns>
		public ProcessResult<List<ProvinceEL>> ProvinceSearch(ProvinceRequest filter)
		{
			var processResult = new ProcessResult<List<ProvinceEL>>();
			try
			{
				var resultProvinceEn = new List<ProvinceEN>();

				using (province = new ProvinceEN(new RepositoryStoredProcedure<ProvinceEN>(dbContext)))
				{
					resultProvinceEn = province.ProvinceSearch(filter.CountryCode, filter.ProvinceCode);
				}
				var listProvinceEl = new List<ProvinceEL>();
				foreach (var item in resultProvinceEn)
				{
					var provinceEl = new ProvinceEL();
					provinceEl.CountryCode = item.CodigoPais;
					provinceEl.ProvinceCode = item.CodigoProvincia;
					provinceEl.ProvinceName = item.NombreProvincia;
					listProvinceEl.Add(provinceEl);
				}

				processResult.Result = listProvinceEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite buscar Ciudades
		/// </summary>
		/// <param name="filter">Filtro de Ciudades</param>
		/// <returns>Lista de Ciudades</returns>
		public ProcessResult<List<CityEL>> CitySearch(CityRequest filter)
		{
			var processResult = new ProcessResult<List<CityEL>>();
			try
			{
				var resultCityEn = new List<CityEN>();

				using (city = new CityEN(new RepositoryStoredProcedure<CityEN>(dbContext)))
				{
					resultCityEn = city.CitySearch(filter.ProvinceCode, filter.CityCode);
				}
				var listCityEl = new List<CityEL>();
				foreach (var item in resultCityEn)
				{
					var cityEl = new CityEL();
					cityEl.ProvinceCode = item.CodigoProvincia;
					cityEl.CityCode = item.CodigoCiudad;
					cityEl.CityName = item.NombreCiudad;
					listCityEl.Add(cityEl);
				}

				processResult.Result = listCityEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite buscar Distritos
		/// </summary>
		/// <param name="filter">Filtro de Distritos</param>
		/// <returns>Lista de Distritos</returns>
		public ProcessResult<List<DistrictEL>> DistrictSearch(DistrictRequest filter)
		{
			var processResult = new ProcessResult<List<DistrictEL>>();
			try
			{
				var resultProvinceEn = new List<DistrictEN>();

				using (district = new DistrictEN(new RepositoryStoredProcedure<DistrictEN>(dbContext)))
				{
					resultProvinceEn = district.DistrictSearch(filter.CityCode, filter.DistrictCode);
				}
				var listDistrictEl = new List<DistrictEL>();
				foreach (var item in resultProvinceEn)
				{
					var districtEL = new DistrictEL();
					districtEL.CityCode = item.CodigoCiudad;
					districtEL.DistrictCode = item.CodigoDistrito;
					districtEL.DistrictName = item.NombreDistrito;
					listDistrictEl.Add(districtEL);
				}

				processResult.Result = listDistrictEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Tipos de Zonas de Ubigeos
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<UbigeoZoneTypeEL>> UbigeoZoneTypeSearch(UbigeoZoneTypeRequest filter)
		{
			var processResult = new ProcessResult<List<UbigeoZoneTypeEL>>();
			try
			{
				var resultubigeoZoneTypeEn = new List<UbigeoZoneTypeEN>();

				using (ubigeoZoneType = new UbigeoZoneTypeEN(new RepositoryStoredProcedure<UbigeoZoneTypeEN>(dbContext)))
				{
					resultubigeoZoneTypeEn = ubigeoZoneType.UbigeoZoneTypeSearch(filter.CodeTypeZoneUbigeo, filter.BusinessUnitCode, filter.CodeZone, filter.CodeCountry,
																				 filter.CodeLevel1, filter.Level1, filter.CodeLevel2, filter.Level2, filter.CodeLevel3,
																				 filter.Level3, filter.CodeTypeZone, filter.RegistrationStatus,
																				 filter.PageNo,
																				filter.PageSize);
				}
				var listUbigeoZoneTypeEl = new List<UbigeoZoneTypeEL>();
				foreach (var item in resultubigeoZoneTypeEn)
				{
					var ubigeoZoneTypeEl = new UbigeoZoneTypeEL();
					ubigeoZoneTypeEl.CodeTypeZoneUbigeo = item.CodigoTipoZonaUbigeo;
					ubigeoZoneTypeEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					ubigeoZoneTypeEl.CodeZone = item.CodigoZona;
					ubigeoZoneTypeEl.CodeCountry = item.CodigoPais;
					ubigeoZoneTypeEl.DescriptionCountry = item.DescripcionPais;
					ubigeoZoneTypeEl.CodeLevel1 = item.CodigoNivel1;
					ubigeoZoneTypeEl.Level1 = item.Nivel1;
					ubigeoZoneTypeEl.CodeLevel2 = item.CodigoNivel2;
					ubigeoZoneTypeEl.Level2 = item.Nivel2;
					ubigeoZoneTypeEl.CodeLevel3 = item.CodigoNivel3;
					ubigeoZoneTypeEl.Level3 = item.Nivel3;
					ubigeoZoneTypeEl.CodeTypeZone = item.CodigoTipoZona;
					ubigeoZoneTypeEl.RegistrationStatus = item.EstadoRegistro;
					ubigeoZoneTypeEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					ubigeoZoneTypeEl.RowId = item.RowId;
					ubigeoZoneTypeEl.RowNumber = item.RowNumber;
					ubigeoZoneTypeEl.RowsTotal = item.RowsTotal;

					listUbigeoZoneTypeEl.Add(ubigeoZoneTypeEl);
				}

				processResult.Result = listUbigeoZoneTypeEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Tipos de Zona por Ubigeo
		/// </summary>
		/// <param name="filter">Tipo de Zona de Ubigeo a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Ubigeo repetido</returns>
		public ProcessResult<string> UbigeoZoneTypeRegister(UbigeoZoneTypeRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.CodeCountry)
					|| string.IsNullOrEmpty(filter.CodeTypeZone)
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				if (filter.CodeLevel1 != null && filter.CodeLevel1.Trim() == "")
				{
					filter.CodeLevel1 = null;
				}

				if (filter.CodeLevel2 != null && filter.CodeLevel2.Trim() == "")
				{
					filter.CodeLevel2 = null;
				}

				if (filter.CodeLevel3 != null && filter.CodeLevel3.Trim() == "")
				{
					filter.CodeLevel3 = null;
				}

				if (filter.CodeLevel3 != null && filter.CodeLevel3.Trim() != "")
				{
					filter.CodeZone = filter.CodeLevel3;
				}
				else if (filter.CodeLevel2 != null && filter.CodeLevel2.Trim() != "")
				{
					filter.CodeZone = filter.CodeLevel2;
				}
				else if (filter.CodeLevel1 != null && filter.CodeLevel1.Trim() != "")
				{
					filter.CodeZone = filter.CodeLevel1;
				}
				else
				{
					filter.CodeZone = filter.CodeCountry;
				}

				var resultUbigeoZoneTypeSearch = UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { BusinessUnitCode = filter.BusinessUnitCode, CodeZone = filter.CodeZone, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultUbigeoZoneTypeSearch.Count > 0)
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				filter.Level1 = null;
				filter.Level2 = null;
				filter.Level3 = null;
				//Obtener Nombres de Zonas 
				if (filter.CodeLevel1 != null)
				{
					var countryp = CountrySearch(new CountryRequest() { CountryZoneCode = filter.CodeCountry }).Result.FirstOrDefault();

					var provinceCurrent = ProvinceSearch(new ProvinceRequest()
					{
						CountryCode = countryp.CountryCode,
						ProvinceCode = filter.CodeLevel1,
					}).Result.FirstOrDefault();

					if (provinceCurrent != null)
					{
						filter.Level1 = provinceCurrent.ProvinceName;
					}

					if (filter.CodeLevel2 != null)
					{
						var cityCurrent = CitySearch(new CityRequest()
						{
							ProvinceCode = filter.CodeLevel1,
							CityCode = filter.CodeLevel2
						}).Result.FirstOrDefault();

						if (cityCurrent != null)
						{
							filter.Level2 = cityCurrent.CityName;
						}

						if (filter.CodeLevel3 != null)
						{
							var districtCurrent = DistrictSearch(new DistrictRequest()
							{
								CityCode = filter.CodeLevel2,
								DistrictCode = filter.CodeLevel3
							}).Result.FirstOrDefault();

							if (districtCurrent != null)
							{
								filter.Level3 = districtCurrent.DistrictName;
							}
						}
					}
				}

				int quantityAffectedRecords = 0;
				var queryActual = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_TIPO_ZONA_UBIGEO" + "]), 0) + 1" }, new List<string>() { "MNT.TIPO_ZONA_UBIGEO" }, null);
				var registroActual = ExecuteDynamicQuery(queryActual).FirstOrDefault();
				filter.CodeTypeZoneUbigeo = Convert.ToInt32(registroActual[registroActual.Keys.FirstOrDefault()]);
				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				using (ubigeoZoneType = new UbigeoZoneTypeEN(new RepositoryStoredProcedure<UbigeoZoneTypeEN>(dbContext)))
				{
					var ubigeoZoneTypeEn = new UbigeoZoneTypeEN()
					{
						CodigoTipoZonaUbigeo = Convert.ToInt32(filter.CodeTypeZoneUbigeo),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoZona = filter.CodeZone,
						CodigoPais = filter.CodeCountry,
						CodigoNivel1 = filter.CodeLevel1,
						Nivel1 = filter.Level1,
						CodigoNivel2 = filter.CodeLevel2,
						Nivel2 = filter.Level2,
						CodigoNivel3 = filter.CodeLevel3,
						Nivel3 = filter.Level3,
						CodigoTipoZona = filter.CodeTypeZone,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation
					};

					quantityAffectedRecords = ubigeoZoneType.UbigeoZoneTypeRegister(ubigeoZoneTypeEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewUbigeoZoneTypeSearch = UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { CodeTypeZoneUbigeo = filter.CodeTypeZoneUbigeo, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.TipoZonaUbigeo.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.CodeTypeZoneUbigeo.ToString(),
																	   null,
																	   ubigeoZoneTypeEn.UsuarioCreacion,
																	   ubigeoZoneTypeEn.TerminalCreacion,
																	   null,
																	   resultNewUbigeoZoneTypeSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modificación de Tipos de Zona por Ubigeo
		/// </summary>
		/// <param name="filter">Tipo de Zona de Ubigeo a Actualizar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Ubigeo repetya asignadoido</returns>
		public ProcessResult<string> UbigeoZoneTypeUpdate(UbigeoZoneTypeRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.CodeTypeZoneUbigeo == null
					|| filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.CodeCountry)
					|| string.IsNullOrEmpty(filter.CodeTypeZone)
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				if (filter.CodeLevel1 != null && filter.CodeLevel1.Trim() == "")
				{
					filter.CodeLevel1 = null;
				}

				if (filter.CodeLevel2 != null && filter.CodeLevel2.Trim() == "")
				{
					filter.CodeLevel2 = null;
				}

				if (filter.CodeLevel3 != null && filter.CodeLevel3.Trim() == "")
				{
					filter.CodeLevel3 = null;
				}

				if (filter.CodeLevel3 != null && filter.CodeLevel3.Trim() != "")
				{
					filter.CodeZone = filter.CodeLevel3;
				}
				else if (filter.CodeLevel2 != null && filter.CodeLevel2.Trim() != "")
				{
					filter.CodeZone = filter.CodeLevel2;
				}
				else if (filter.CodeLevel1 != null && filter.CodeLevel1.Trim() != "")
				{
					filter.CodeZone = filter.CodeLevel1;
				}
				else
				{
					filter.CodeZone = filter.CodeCountry;
				}

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var resultUbigeoZoneTypeSearch = UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { BusinessUnitCode = filter.BusinessUnitCode, CodeZone = filter.CodeZone, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

					if (resultUbigeoZoneTypeSearch.Any(item => item.CodeTypeZoneUbigeo != filter.CodeTypeZoneUbigeo))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);

						return processResult;
					}
				}

				filter.Level1 = null;
				filter.Level2 = null;
				filter.Level3 = null;
				//Obtener Nombres de Zonas 
				if (filter.CodeLevel1 != null)
				{
					var countryp = CountrySearch(new CountryRequest() { CountryZoneCode = filter.CodeCountry }).Result.FirstOrDefault();

					var provinceCurrent = ProvinceSearch(new ProvinceRequest()
					{
						CountryCode = countryp.CountryCode,
						ProvinceCode = filter.CodeLevel1,
					}).Result.FirstOrDefault();

					if (provinceCurrent != null)
					{
						filter.Level1 = provinceCurrent.ProvinceName;
					}

					if (filter.CodeLevel2 != null)
					{
						var cityCurrent = CitySearch(new CityRequest()
						{
							ProvinceCode = filter.CodeLevel1,
							CityCode = filter.CodeLevel2
						}).Result.FirstOrDefault();

						if (cityCurrent != null)
						{
							filter.Level2 = cityCurrent.CityName;
						}

						if (filter.CodeLevel3 != null)
						{
							var districtCurrent = DistrictSearch(new DistrictRequest()
							{
								CityCode = filter.CodeLevel2,
								DistrictCode = filter.CodeLevel3
							}).Result.FirstOrDefault();

							if (districtCurrent != null)
							{
								filter.Level3 = districtCurrent.DistrictName;
							}
						}
					}
				}

				int quantityAffectedRecords = 0;
				using (ubigeoZoneType = new UbigeoZoneTypeEN(new RepositoryStoredProcedure<UbigeoZoneTypeEN>(dbContext)))
				{
					var ubigeoZoneTypeEn = new UbigeoZoneTypeEN()
					{
						CodigoTipoZonaUbigeo = Convert.ToInt32(filter.CodeTypeZoneUbigeo),
						CodigoZona = filter.CodeZone,
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoPais = filter.CodeCountry,
						CodigoNivel1 = filter.CodeLevel1,
						Nivel1 = filter.Level1,
						CodigoNivel2 = filter.CodeLevel2,
						Nivel2 = filter.Level2,
						CodigoNivel3 = filter.CodeLevel3,
						Nivel3 = filter.Level3,
						CodigoTipoZona = filter.CodeTypeZone,
						EstadoRegistro = filter.RegistrationStatus,
						Observacion = filter.ModificationReason,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					/**Auditoría**/
					var resultOldUbigeoZoneTypeSearch = UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { CodeTypeZoneUbigeo = filter.CodeTypeZoneUbigeo, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = ubigeoZoneType.UbigeoZoneTypeUpdate(ubigeoZoneTypeEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentUbigeoZoneTypeSearch = UbigeoZoneTypeSearch(new UbigeoZoneTypeRequest() { CodeTypeZoneUbigeo = filter.CodeTypeZoneUbigeo, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.TipoZonaUbigeo.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.CodeTypeZoneUbigeo.ToString(),
																	   ubigeoZoneTypeEn.Observacion,
																	   ubigeoZoneTypeEn.UsuarioModificacion,
																	   ubigeoZoneTypeEn.TerminalModificacion,
																	   resultOldUbigeoZoneTypeSearch.FirstOrDefault(),
																	   resultCurrentUbigeoZoneTypeSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Orden de Combinación
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Respuesta del Proceso</returns>
		public ProcessResult<List<CombinationOrderEL>> CombinationOrderSearch(CombinationOrderRequest filter)
		{
			var processResult = new ProcessResult<List<CombinationOrderEL>>();
			try
			{
				var resultCombinationOrderEn = new List<CombinationOrderEN>();

				using (combinationOrder = new CombinationOrderEN(new RepositoryStoredProcedure<CombinationOrderEN>(dbContext)))
				{
					resultCombinationOrderEn = combinationOrder.CombinationOrderSearch(filter.OrderCodeCombination,
																						filter.BusinessUnitCode,
																						filter.ParameterCode,
																						filter.Code,
																						filter.Order,
																						filter.RegistrationStatus,
																						filter.PageNo,
																						filter.PageSize);
				}
				var listCombinationOrderEl = new List<CombinationOrderEL>();
				foreach (var item in resultCombinationOrderEn)
				{
					var combinationOrderEl = new CombinationOrderEL();
					combinationOrderEl.OrderCodeCombination = item.CodigoOrdenCombinacion;
					combinationOrderEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					combinationOrderEl.ParameterCode = item.CodigoParametro;
					combinationOrderEl.Code = item.Codigo;
					combinationOrderEl.ParameterName = item.NombreParametro;
					combinationOrderEl.Order = item.Orden;
					combinationOrderEl.RegistrationStatus = item.EstadoRegistro;
					combinationOrderEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					combinationOrderEl.RowId = item.RowId;
					combinationOrderEl.RowNumber = item.RowNumber;
					combinationOrderEl.RowsTotal = item.RowsTotal;

					listCombinationOrderEl.Add(combinationOrderEl);
				}

				processResult.Result = listCombinationOrderEl;
				processResult.IsSuccess = true;
			}
			catch (SqlException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			catch (Exception ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Orden de Combinación de Parámetros
		/// </summary>
		/// <param name="filter">Orden de Combinación de Parámetros a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Parámetro Repetido</returns>
		public ProcessResult<string> CombinationOrderRegister(CombinationOrderRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| filter.ParameterCode == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var resultCombinationOrderSearch = CombinationOrderSearch(new CombinationOrderRequest() { BusinessUnitCode = filter.BusinessUnitCode, ParameterCode = filter.ParameterCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultCombinationOrderSearch.Count > 0)
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;
				var currentQueryOrderCodeCombination = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_ORDEN_COMBINACION" + "]), 0) + 1" }, new List<string>() { "MNT.ORDEN_COMBINACION" });
				var currentRecordOrderCodeCombination = ExecuteDynamicQuery(currentQueryOrderCodeCombination).FirstOrDefault();
				filter.OrderCodeCombination = Convert.ToInt32(currentRecordOrderCodeCombination[currentRecordOrderCodeCombination.Keys.FirstOrDefault()]);

				Dictionary<string, string> conditionsCurrentOrder = new Dictionary<string, string>();
				conditionsCurrentOrder.Add("CODIGO_UNIDAD_NEGOCIO", " = " + filter.BusinessUnitCode);
				conditionsCurrentOrder.Add("ESTADO_REGISTRO", " = " + Enumerated.RegistrationStatus.Active);
				var currentQueryOrder = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "ORDEN" + "]), 0) + 1" }, new List<string>() { "MNT.ORDEN_COMBINACION" }, conditionsCurrentOrder);
				var currentRecordOrder = ExecuteDynamicQuery(currentQueryOrder).FirstOrDefault();
				filter.Order = Convert.ToByte(currentRecordOrder[currentRecordOrder.Keys.FirstOrDefault()]);

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				using (combinationOrder = new CombinationOrderEN(new RepositoryStoredProcedure<CombinationOrderEN>(dbContext)))
				{
					var combinationOrderEn = new CombinationOrderEN()
					{
						CodigoOrdenCombinacion = Convert.ToInt32(filter.OrderCodeCombination),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoParametro = Convert.ToInt32(filter.ParameterCode),
						Orden = Convert.ToByte(filter.Order),
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation
					};

					quantityAffectedRecords = combinationOrder.CombinationOrderRegister(combinationOrderEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewCombinationOrderSearch = CombinationOrderSearch(new CombinationOrderRequest() { OrderCodeCombination = filter.OrderCodeCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.OrdenCombinacion.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.OrderCodeCombination.ToString(),
																	   null,
																	   combinationOrderEn.UsuarioCreacion,
																	   combinationOrderEn.TerminalCreacion,
																	   null,
																	   resultNewCombinationOrderSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modificación de Orden de Combinación de Parámetros
		/// </summary>
		/// <param name="filter">Orden de Combinación de Parámetros a Modificar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Parámetro Repetido</returns>
		public ProcessResult<string> CombinationOrderUpdate(CombinationOrderRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| filter.OrderCodeCombination == null
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var resultCombinationSearch = CombinationSearch(new CombinationRequest() { BusinessUnitCode = filter.BusinessUnitCode, GetParametersCombination = true, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultCombinationSearch.Any(item => item.ListParameterCombination.Any(itemAny => itemAny.CodeParameter == filter.ParameterCode)))
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Cancelled;
				using (combinationOrder = new CombinationOrderEN(new RepositoryStoredProcedure<CombinationOrderEN>(dbContext)))
				{
					var combinationOrderEn = new CombinationOrderEN()
					{
						CodigoOrdenCombinacion = Convert.ToInt32(filter.OrderCodeCombination),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						Observacion = filter.ModificationReason,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					/**Auditoría**/
					var resultOldCombinationOrderSearch = CombinationOrderSearch(new CombinationOrderRequest() { OrderCodeCombination = filter.OrderCodeCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = combinationOrder.CombinationOrderUpdate(combinationOrderEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentCombinationOrderSearch = CombinationOrderSearch(new CombinationOrderRequest() { OrderCodeCombination = filter.OrderCodeCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.OrdenCombinacion.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.OrderCodeCombination.ToString(),
																	   combinationOrderEn.Observacion,
																	   combinationOrderEn.UsuarioModificacion,
																	   combinationOrderEn.TerminalModificacion,
																	   resultOldCombinationOrderSearch.FirstOrDefault(),
																	   resultCurrentCombinationOrderSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Combinaciones
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Resultado de Búsqueda</returns>
		public ProcessResult<List<CombinationEL>> CombinationSearch(CombinationRequest filter)
		{
			ProcessResult<List<CombinationEL>> processResult = new ProcessResult<List<CombinationEL>>();

			if (filter.AmountFreight == null && environment != null)
			{
				filter.AmountFreight = Utility.StringFormatDecimal(filter.AmountFreightString, environment.DecimalFormat, environment.InformationDecimalFormat);
			}
			try
			{
				int? parameterCode = null;
				string value = null;
				if (filter.Parameter != null && !string.IsNullOrEmpty(filter.Parameter.FirstOrDefault().Key))
				{
					parameterCode = Convert.ToInt32(filter.Parameter.FirstOrDefault().Key);
					if (!string.IsNullOrEmpty(filter.Parameter.FirstOrDefault().Value))
					{
						value = filter.Parameter.FirstOrDefault().Value;
					}
				}

				List<CombinationEN> resultCombinationEn = new List<CombinationEN>();
				using (combination = new CombinationEN(new RepositoryStoredProcedure<CombinationEN>(dbContext)))
				{
					resultCombinationEn = combination.CombinationSearch(filter.BusinessUnitCode, filter.CombinationCode, filter.AmountFreight,
																		parameterCode, value, filter.RegistrationStatus, filter.PageNo, filter.PageSize);
				}

				ParameterCombinationRequest parameterCombinationRequestTest = new ParameterCombinationRequest
				{
					CodeCombinationList = resultCombinationEn.ToCombinationTable(),
					BusinessUnitCode = filter.BusinessUnitCode,
					RegistrationStatus = Enumerated.RegistrationStatus.Active,
					IsForService = filter.IsForService,
				};

				List<ParameterCombinationEL> resultCombinationSearch = ParameterCombinationSearch(parameterCombinationRequestTest).Result;

				List<CombinationEL> listCombinationEL = new List<CombinationEL>();
				foreach (var item in resultCombinationEn)
				{
					CombinationEL combinationEl = new CombinationEL();
					combinationEl.CombinationCode = item.CodigoCombinacion;
					combinationEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					combinationEl.AmountFreight = item.ImporteFlete;
					if (environment != null)
					{
						combinationEl.AmountFreightString = Utility.DecimalFormatString(item.ImporteFlete, environment.DecimalFormat, environment.InformationDecimalFormat);
					}
					combinationEl.RegistrationStatus = item.EstadoRegistro;
					combinationEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;

					combinationEl.ListParameterCombination = resultCombinationSearch.FilterAndRemoveCombinations(item.CodigoCombinacion);

					combinationEl.Description = item.Combinacion;

					if (!filter.IsForService)
					{
						combinationEl.RowId = item.RowId;
						combinationEl.RowNumber = item.RowNumber;
						combinationEl.RowsTotal = item.RowsTotal;
					}

					listCombinationEL.Add(combinationEl);
				}

				processResult.Result = listCombinationEL;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Combinaciones
		/// </summary>
		/// <param name="filter">Combinación de Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Combinación existente</returns>
		public ProcessResult<string> CombinationRegister(CombinationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.AmountFreightString)
					|| filter.Parameter.Count() == 0
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				var validationRange = ValidationParameterCombination((int)filter.BusinessUnitCode, filter.Parameter);

				if (!validationRange.IsSuccess)
				{
					return validationRange;
				}

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;

				filter.AmountFreight = Utility.StringFormatDecimal(filter.AmountFreightString, environment.DecimalFormat, environment.InformationDecimalFormat);
				int quantityAffectedRecords = 0;

				var queryActual = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_COMBINACION" + "]), 0) + 1" }, new List<string>() { "MNT.COMBINACION" });
				var registroActual = ExecuteDynamicQuery(queryActual).FirstOrDefault();
				filter.CombinationCode = Convert.ToInt32(registroActual[registroActual.Keys.FirstOrDefault()]);

				using (combination = new CombinationEN(new RepositoryStoredProcedure<CombinationEN>(dbContext)))
				{
					var combinationEn = new CombinationEN()
					{
						CodigoCombinacion = Convert.ToInt32(filter.CombinationCode),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						ImporteFlete = Convert.ToDecimal(filter.AmountFreight),
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation
					};
					quantityAffectedRecords = combination.CombinationRegister(combinationEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewCombinationSearch = CombinationSearch(new CombinationRequest() { CombinationCode = filter.CombinationCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Combinacion.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.CombinationCode.ToString(),
																	   null,
																	   combinationEn.UsuarioCreacion,
																	   combinationEn.TerminalCreacion,
																	   null,
																	   resultNewCombinationSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/

						foreach (var item in filter.Parameter.Keys)
						{
							var resultParameterCombination = ParameterCombinationRegister(new ParameterCombinationRequest()
							{
								CodeCombination = filter.CombinationCode,
								CodeParameter = Convert.ToInt32(item),
								Value = filter.Parameter[item],
								UserCreation = filter.UserCreation,
								TerminalCreation = filter.TerminalCreation,
								BusinessUnitCode = filter.BusinessUnitCode
							});

							if (resultParameterCombination.Result != "1")
							{
								result = "-1";
								processResult.Result = result;
								processResult.IsSuccess = false;
								processResult.Exception = resultParameterCombination.Exception;
							}
						}
						result = "1";
						processResult.Result = result;
						processResult.IsSuccess = true;
						processResult.Exception = null;
					}
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		#region Private Methods

		/// <summary>
		/// Permite Validar los Parámetros de la Combinación
		/// </summary>
		/// <param name="businessUnitCode">Código de Unidad de Negocio</param>
		/// <param name="parameters">Parámetro</param>
		/// <returns>Indicador de Conformidad</returns>
		private ProcessResult<string> ValidationParameterCombination(int businessUnitCode, Dictionary<string, string> parameters, int? combinationCode = null)
		{
			ProcessResult<string> processResult = new ProcessResult<string>();
			processResult.Result = "1";
			processResult.IsSuccess = true;
			processResult.Exception = new CustomException(processResult.Result);

			var combinationValidation = CombinationSearch(new CombinationRequest()
			{
				BusinessUnitCode = businessUnitCode,
				GetParametersCombination = true,
				RegistrationStatus = Enumerated.RegistrationStatus.Active
			}).Result;

			if (combinationCode != null)
			{
				combinationValidation = combinationValidation.Where(item => item.CombinationCode != combinationCode).ToList();
			}

			bool indicatorRangeInvalid = false;
			foreach (var itemCombination in combinationValidation)
			{
				itemCombination.ListParameterCombination = itemCombination.ListParameterCombination.OrderBy(item => item.CombinationOrder).ToList();
				int countCombination = itemCombination.ListParameterCombination.Count;
				int countCombinationRepeated = 0;

				foreach (var itemParameterCombination in itemCombination.ListParameterCombination)
				{
					if (parameters.Any(item => item.Key == Convert.ToString(itemParameterCombination.CodeParameter) && item.Value == itemParameterCombination.Value))
					{
						countCombinationRepeated++;
					}
					else if (itemParameterCombination.ParameterType == Enumerated.ParameterType.RangeValues
						&& !indicatorRangeInvalid
						&& countCombinationRepeated + 1 == (int)itemParameterCombination.CombinationOrder)
					{
						indicatorRangeInvalid = ValidateRangeCombination(businessUnitCode, parameters, itemParameterCombination);
					}
				}
				if (parameters.Count == countCombinationRepeated && countCombination == countCombinationRepeated)
				{
					processResult.Result = "3";
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(processResult.Result);
					return processResult;
				}
			}
			if (indicatorRangeInvalid)
			{
				processResult.Result = "4";
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(processResult.Result);
				return processResult;
			}
			return processResult;
		}

		/// <summary>
		/// Permite Validar los Parámetros de tipo Rango la Combinación
		/// </summary>
		/// <param name="businessUnitCode">Código de Unidad de Negocio</param>
		/// <param name="parameters">Parametros</param>
		/// <param name="parameterCombination">Parámetro de la Combinación</param>
		/// <returns>Indicador de invalides</returns>
		private bool ValidateRangeCombination(int businessUnitCode, Dictionary<string, string> parameters, ParameterCombinationEL parameterCombinationp)
		{
			if (parameters.Any(item => item.Key == Convert.ToString(parameterCombinationp.CodeParameter)))
			{
				var itemParameter = parameters.Where(item => item.Key == Convert.ToString(parameterCombinationp.CodeParameter)).FirstOrDefault();

				var parameterSectionCurrent = ParameterSectionSearch(new ParameterSectionRequest()
				{
					CodeParameter = parameterCombinationp.CodeParameter,
					BusinessUnitCode = businessUnitCode,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result;

				var sectionRangeBegin = parameterSectionCurrent.Where(itemWhere => itemWhere.RangeIndicator == Enumerated.RangeType.Begin).FirstOrDefault();
				var sectionRangeEnd = parameterSectionCurrent.Where(itemWhere => itemWhere.RangeIndicator == Enumerated.RangeType.End).FirstOrDefault();

				var parameterValueCurrent = ParameterValueSearch(new ParameterValueRequest()
				{
					CodeParameter = Convert.ToInt32(itemParameter.Key),
					BusinessUnitCode = businessUnitCode,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result.Where(item => item.RecordValueString["1"] == itemParameter.Value).FirstOrDefault();

				var parameterValueCombination = ParameterValueSearch(new ParameterValueRequest()
				{
					CodeParameter = parameterCombinationp.CodeParameter,
					BusinessUnitCode = businessUnitCode,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result.Where(item => item.RecordValueString["1"] == parameterCombinationp.Value).FirstOrDefault();

				int validationBeginEnd = 0;
				int validationBeginBegin = 0;
				int validationEndBegin = 0;
				int validationEndEnd = 0;

				bool infinityParameterCurrent = false;
				bool infinityParameterCombination = false;

				switch (sectionRangeBegin.CodeParameterSectionType)
				{
					case Enumerated.SectionType.Integer:
						if (parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == null || parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == "")
						{
							parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] = Int32.MaxValue;
							infinityParameterCurrent = true;
						}

						if (parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == null || parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == "")
						{
							parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] = Int32.MaxValue;
							infinityParameterCombination = true;
						}

						validationBeginEnd = Convert.ToInt32(parameterValueCurrent.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]);

						validationBeginBegin = Convert.ToInt32(parameterValueCurrent.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

						validationEndBegin = Convert.ToInt32(parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

						validationEndEnd = Convert.ToInt32(parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]);
						break;

					case Enumerated.SectionType.Decimal:
						if (parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == null || parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == "")
						{
							parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] = Decimal.MaxValue;
							infinityParameterCurrent = true;
						}

						if (parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == null || parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == "")
						{
							parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] = Decimal.MaxValue;
							infinityParameterCombination = true;
						}

						validationBeginEnd = Convert.ToDecimal(parameterValueCurrent.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]);

						validationBeginBegin = Convert.ToDecimal(parameterValueCurrent.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

						validationEndBegin = Convert.ToDecimal(parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

						validationEndEnd = Convert.ToDecimal(parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]).CompareTo(
																	parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]);
						break;

					case Enumerated.SectionType.Date:
						if (parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == null || parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == "")
						{
							parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] = DateTime.MaxValue;
							infinityParameterCurrent = true;
						}

						if (parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == null || parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] == "")
						{
							parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()] = DateTime.MaxValue;
							infinityParameterCombination = true;
						}

						validationBeginEnd = Convert.ToDateTime(parameterValueCurrent.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]).CompareTo(
																		parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]);

						validationBeginBegin = Convert.ToDateTime(parameterValueCurrent.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]).CompareTo(
																		parameterValueCombination.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

						validationEndBegin = Convert.ToDateTime(parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]).CompareTo(
																		parameterValueCombination.RecordValueObject[sectionRangeBegin.CodeSection.ToString()]);

						validationEndEnd = Convert.ToDateTime(parameterValueCurrent.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]).CompareTo(
																		parameterValueCombination.RecordValueObject[sectionRangeEnd.CodeSection.ToString()]);
						break;
				}

				if ((validationBeginBegin >= 0 && validationBeginEnd < 0) || (validationEndBegin > 0 && (validationEndEnd < 0 || (infinityParameterCurrent && infinityParameterCombination))))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Permite realizar el registro de Combinación de Parámetro
		/// </summary>
		/// <param name="filter">Parámetro de Combinación de Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Combinación existente</returns>
		private ProcessResult<string> ParameterCombinationRegister(ParameterCombinationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.CodeCombination == null
					|| filter.CodeParameter == null
					|| filter.Value == null
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				filter.OrderCombination = CombinationOrderSearch(new CombinationOrderRequest()
				{
					ParameterCode = filter.CodeParameter,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result.FirstOrDefault().Order;

				int quantityAffectedRecords = 0;

				var parameterCombinationEl = ParameterCombinationSearch(new ParameterCombinationRequest()
				{
					CodeCombination = filter.CodeCombination,
					CodeParameter = filter.CodeParameter,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result.FirstOrDefault();

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;

				if (parameterCombinationEl != null && parameterCombinationEl.Value == filter.Value)
				{
					using (parameterCombination = new ParameterCombinationEN(new RepositoryStoredProcedure<ParameterCombinationEN>(dbContext)))
					{
						var parameterCombinationEn = new ParameterCombinationEN()
						{
							CodigoCombinacionParametro = Convert.ToInt32(parameterCombinationEl.CodeParameterCombination),
							CodigoCombinacion = Convert.ToInt32(filter.CodeCombination),
							CodigoParametro = Convert.ToInt32(filter.CodeParameter),
							OrdenCombinacion = Convert.ToByte(filter.OrderCombination),
							Valor = filter.Value,
							EstadoRegistro = filter.RegistrationStatus,
							Observacion = filter.ModificationReason,
							UsuarioModificacion = filter.UserCreation,
							TerminalModificacion = filter.TerminalCreation
						};

						/**Auditoría**/
						var resultOldParameterCombinationSearch = ParameterCombinationSearch(new ParameterCombinationRequest() { CodeParameterCombination = parameterCombinationEl.CodeParameterCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;

						quantityAffectedRecords = parameterCombination.ParameterCombinationUpdate(parameterCombinationEn);

						if (quantityAffectedRecords > 0)
						{
							//** Proceso para la Auditoria - Inicio **/
							var resultCurrentParameterCombinationSearch = ParameterCombinationSearch(new ParameterCombinationRequest() { CodeParameterCombination = parameterCombinationEl.CodeParameterCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;
							this.PolicyAuditRegister(EnumeratedTable.CombinacionParametro.TableName,
																		   this.environment.BusinessUnitCode,
																		   parameterCombinationEl.CodeParameterCombination.ToString(),
																		   parameterCombinationEn.Observacion,
																		   parameterCombinationEn.UsuarioModificacion,
																		   parameterCombinationEn.TerminalModificacion,
																		   resultOldParameterCombinationSearch.FirstOrDefault(),
																		   resultCurrentParameterCombinationSearch.FirstOrDefault());
							//** Proceso para la Auditoria - Fin **/
						}
					}
				}
				else
				{
					if (parameterCombinationEl != null)
					{
						var resultParameterCombination = ParameterCombinationDelete(new ParameterCombinationRequest()
						{
							CodeCombination = Convert.ToInt32(parameterCombinationEl.CodeCombination),
							CodeParameter = Convert.ToInt32(filter.CodeParameter),
							ModificationReason = filter.ModificationReason,
							UserModification = filter.UserCreation,
							TerminalModification = filter.TerminalCreation
						});
						if (resultParameterCombination.Result != "1")
						{
							result = "-1";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result, "", resultParameterCombination.Exception);
							return processResult;
						}
					}
					filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
					var queryActual = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_COMBINACION_PARAMETRO" + "]), 0) + 1" }, new List<string>() { "MNT.COMBINACION_PARAMETRO" });
					var registroActual = ExecuteDynamicQuery(queryActual).FirstOrDefault();
					int parameterCombinationCode = Convert.ToInt32(registroActual[registroActual.Keys.FirstOrDefault()]);

					using (parameterCombination = new ParameterCombinationEN(new RepositoryStoredProcedure<ParameterCombinationEN>(dbContext)))
					{
						var parameterCombinationEn = new ParameterCombinationEN()
						{
							CodigoCombinacionParametro = parameterCombinationCode,
							CodigoCombinacion = Convert.ToInt32(filter.CodeCombination),
							CodigoParametro = Convert.ToInt32(filter.CodeParameter),
							OrdenCombinacion = Convert.ToByte(filter.OrderCombination),
							Valor = filter.Value,
							EstadoRegistro = filter.RegistrationStatus,
							UsuarioCreacion = filter.UserCreation,
							TerminalCreacion = filter.TerminalCreation,
							CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode)
						};

						quantityAffectedRecords = parameterCombination.ParameterCombinationRegister(parameterCombinationEn);

						if (quantityAffectedRecords >= 1)
						{
							//** Proceso para la Auditoria - Inicio **/
							var resultNewParameterCombinationSearch = ParameterCombinationSearch(new ParameterCombinationRequest() { CodeParameterCombination = parameterCombinationCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
							this.PolicyAuditRegister(EnumeratedTable.CombinacionParametro.TableName,
																		   Convert.ToInt32(filter.BusinessUnitCode),
																		   parameterCombinationCode.ToString(),
																		   null,
																		   parameterCombinationEn.UsuarioCreacion,
																		   parameterCombinationEn.TerminalCreacion,
																		   null,
																		   resultNewParameterCombinationSearch.FirstOrDefault());
							//** Proceso para la Auditoria - Fin **/
						}
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la Eliminación Logica de Combinación de Parámetro
		/// </summary>
		/// <param name="filter">Parámetro de Combinación a Eliminar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro</returns>
		private ProcessResult<string> ParameterCombinationDelete(ParameterCombinationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.CodeCombination == null
					|| filter.CodeParameter == null
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}
				int quantityAffectedRecords = 0;
				using (parameterCombination = new ParameterCombinationEN(new RepositoryStoredProcedure<ParameterCombinationEN>(dbContext)))
				{
					var parameterCombinationEn = new ParameterCombinationEN()
					{
						CodigoCombinacionParametro = filter.CodeParameterCombination,
						CodigoCombinacion = Convert.ToInt32(filter.CodeCombination),
						CodigoParametro = Convert.ToInt32(filter.CodeParameter),
						EstadoRegistro = Enumerated.RegistrationStatus.Cancelled,
						Observacion = filter.ModificationReason,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					/**Auditoría**/
					var resultOldParameterCombinationSearch = ParameterCombinationSearch(new ParameterCombinationRequest() { CodeParameterCombination = filter.CodeParameterCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = parameterCombination.ParameterCombinationUpdate(parameterCombinationEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentParameterCombinationSearch = ParameterCombinationSearch(new ParameterCombinationRequest() { CodeParameterCombination = filter.CodeParameterCombination, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.CombinacionParametro.TableName,
																	   this.environment.BusinessUnitCode,
																	   filter.CodeParameterCombination.ToString(),
																	   parameterCombinationEn.Observacion,
																	   parameterCombinationEn.UsuarioModificacion,
																	   parameterCombinationEn.TerminalModificacion,
																	   resultOldParameterCombinationSearch.FirstOrDefault(),
																	   resultCurrentParameterCombinationSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}

				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		#endregion

		/// <summary>
		/// Permite realizar la modificación de Combinaciones
		/// </summary>
		/// <param name="filter">Combinación a Modificar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Combinación existente</returns>
		public ProcessResult<string> CombinationUpdate(CombinationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.CombinationCode == null
					|| filter.BusinessUnitCode == null
					|| string.IsNullOrEmpty(filter.AmountFreightString)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active)
				{
					var combinationOrderCurrent = CombinationOrderSearch(new CombinationOrderRequest()
					{
						BusinessUnitCode = filter.BusinessUnitCode,
						RegistrationStatus = Enumerated.RegistrationStatus.Active
					}).Result;

					var combinationsCurrent = CombinationSearch(new CombinationRequest()
					{
						BusinessUnitCode = filter.BusinessUnitCode,
						GetParametersCombination = true
					}).Result;

					var combinationCurrent = combinationsCurrent.Where(item => item.CombinationCode == filter.CombinationCode).FirstOrDefault();

					foreach (var itemCombination in combinationsCurrent.Where(item => item.RegistrationStatus == Enumerated.RegistrationStatus.Active))
					{
						int countCombination = itemCombination.ListParameterCombination.Count;
						int countCombinationRepeated = 0;
						if (combinationCurrent.ListParameterCombination.Count == countCombination)
						{
							foreach (var itemParameter in combinationCurrent.ListParameterCombination)
							{
								countCombinationRepeated += itemCombination.ListParameterCombination.Where(itemWhere => itemWhere.CodeCombination != filter.CombinationCode && itemWhere.CodeParameter == itemParameter.CodeParameter && itemWhere.Value == itemParameter.Value).ToList().Count;
							}
						}
						if (countCombination == countCombinationRepeated)
						{
							result = "3";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);
							return processResult;
						}
					}

					foreach (var itemParameter in combinationCurrent.ListParameterCombination)
					{
						if (!combinationOrderCurrent.Any(item => item.ParameterCode == itemParameter.CodeParameter))
						{
							result = "4";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = new CustomException(result);

							return processResult;
						}
					}
				}

				filter.AmountFreight = Utility.StringFormatDecimal(filter.AmountFreightString, environment.DecimalFormat, environment.InformationDecimalFormat);
				int quantityAffectedRecords = 0;

				using (combination = new CombinationEN(new RepositoryStoredProcedure<CombinationEN>(dbContext)))
				{
					var combinationEn = new CombinationEN()
					{
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoCombinacion = Convert.ToInt32(filter.CombinationCode),
						ImporteFlete = Convert.ToDecimal(filter.AmountFreight),
						Observacion = filter.ModificationReason,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					/**Auditoría**/
					var resultOldCombinationSearch = CombinationSearch(new CombinationRequest() { CombinationCode = filter.CombinationCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;

					quantityAffectedRecords = combination.CombinationUpdate(combinationEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentCombinationSearch = CombinationSearch(new CombinationRequest() { CombinationCode = filter.CombinationCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Combinacion.TableName,
																	   this.environment.BusinessUnitCode,
																	   filter.CombinationCode.ToString(),
																	   combinationEn.Observacion,
																	   combinationEn.UsuarioModificacion,
																	   combinationEn.TerminalModificacion,
																	   resultOldCombinationSearch.FirstOrDefault(),
																	   resultCurrentCombinationSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}

				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Combinación de Parámetro
		/// </summary>
		/// <param name="filter">Combinación de Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrio un Error al Procesar
		///                                     0: No se realizo ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Combinación existente</returns>
		public ProcessResult<string> ParameterCombinationUpdate(CombinationRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.CombinationCode == null
					|| filter.Parameter.Count() == 0
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var validationRange = ValidationParameterCombination((int)filter.BusinessUnitCode, filter.Parameter, filter.CombinationCode);

				if (!validationRange.IsSuccess)
				{
					return validationRange;
				}

				foreach (var item in filter.Parameter.Keys)
				{
					var resultParameterCombination = ParameterCombinationRegister(new ParameterCombinationRequest()
					{
						CodeCombination = filter.CombinationCode,
						CodeParameter = Convert.ToInt32(item),
						Value = filter.Parameter[item],
						ModificationReason = filter.ModificationReason,
						UserCreation = filter.UserModification,
						TerminalCreation = filter.TerminalModification,
						BusinessUnitCode = filter.BusinessUnitCode
					});

					if (resultParameterCombination.Result != "1")
					{
						result = "-1";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = resultParameterCombination.Exception;
						return processResult;
					}
				}

				var combinationCurrent = CombinationSearch(new CombinationRequest()
				{
					CombinationCode = Convert.ToInt32(filter.CombinationCode),
					BusinessUnitCode = filter.BusinessUnitCode,
					GetParametersCombination = true,
					RegistrationStatus = Enumerated.RegistrationStatus.Active
				}).Result.FirstOrDefault();

				foreach (var item in combinationCurrent.ListParameterCombination)
				{
					if (!filter.Parameter.Any(itemParameter => Convert.ToInt32(itemParameter.Key) == item.CodeParameter))
					{
						var resultParameterCombination = ParameterCombinationDelete(new ParameterCombinationRequest()
						{
							CodeParameterCombination = item.CodeParameterCombination,
							CodeCombination = filter.CombinationCode,
							CodeParameter = item.CodeParameter,
							ModificationReason = filter.ModificationReason,
							UserModification = filter.UserModification,
							TerminalModification = filter.TerminalModification
						});

						if (resultParameterCombination.Result != "1")
						{
							result = "-1";
							processResult.Result = result;
							processResult.IsSuccess = false;
							processResult.Exception = resultParameterCombination.Exception;
							return processResult;
						}
					}
				}

				result = "1";
				processResult.Result = result;
				processResult.IsSuccess = true;
				processResult.Exception = null;
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Combinaciones
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Resultado de Búsqueda</returns>
		public ProcessResult<List<ParameterCombinationEL>> ParameterCombinationSearch(ParameterCombinationRequest filter)
		{
			ProcessResult<List<ParameterCombinationEL>> processResult = new ProcessResult<List<ParameterCombinationEL>>();
			try
			{
				List<ParameterCombinationEN> resultParameterCombinationEN = new List<ParameterCombinationEN>();

				using (parameterCombination = new ParameterCombinationEN(new RepositoryStoredProcedure<ParameterCombinationEN>(dbContext)))
				{
					if (filter.IsForService)
					{
						resultParameterCombinationEN = parameterCombination.ParameterCombinationSearchService(filter.CodeParameterCombination, filter.CodeCombinationList, filter.BusinessUnitCode,
																			   filter.CodeParameter, filter.OrderCombination, filter.Value, filter.RegistrationStatus,
																			   filter.RegistrationStatusCombination);

						processResult.Result = resultParameterCombinationEN.ToParameterCombinationELUnpage();
					}
					else
					{
						resultParameterCombinationEN = parameterCombination.ParameterCombinationSearch(filter.CodeParameterCombination,
																			   resultParameterCombinationEN.ToNonNullable(filter.CodeCombinationList, filter.CodeCombination),
																			   filter.BusinessUnitCode,
																			   filter.CodeParameter, filter.OrderCombination, filter.Value, filter.RegistrationStatus,
																			   filter.RegistrationStatusCombination, filter.PageNo, filter.PageSize);

						processResult.Result = resultParameterCombinationEN.ToParameterCombinationEL();
					}
				}

				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la búsqueda de Fórmulas
		/// </summary>
		/// <param name="filter">Filtro de Búsqueda</param>
		/// <returns>Resultado de Búsqueda</returns>
		public ProcessResult<List<FormulaEL>> FormulaSearch(FormulaRequest filter)
		{
			var processResult = new ProcessResult<List<FormulaEL>>();
			if (filter.Factor == null && environment != null)
			{
				filter.Factor = Utility.StringFormatDecimal(filter.FactorString, environment.DecimalFormat, environment.InformationDecimalFormat);
			}
			try
			{
				var resultFormulaEn = new List<FormulaEN>();

				using (formula = new FormulaEN(new RepositoryStoredProcedure<FormulaEN>(dbContext)))
				{
					resultFormulaEn = formula.FormulaSearch(filter.FormulaCode,
															filter.BusinessUnitCode,
															filter.ParameterCode,
															filter.Value,
															filter.Operation,
															filter.Factor,
															filter.FactorType,
															filter.RegistrationStatus,
															filter.PageNo,
															filter.PageSize);
				}
				var listFormulaEl = new List<FormulaEL>();
				foreach (var item in resultFormulaEn)
				{
					var formulaEl = new FormulaEL();
					formulaEl.FormulaCode = item.CodigoFormula;
					formulaEl.BusinessUnitCode = item.CodigoUnidadNegocio;
					formulaEl.ParameterCode = Convert.ToInt32(item.CodigoParametro);
					formulaEl.Code = item.Codigo;
					formulaEl.ParameterDescription = item.DescripcionParametro;
					formulaEl.Value = item.Valor;
					formulaEl.ValueDescription = item.DescripcionValor;
					formulaEl.Operation = item.Operacion;
					formulaEl.Factor = Convert.ToDecimal(item.Factor);
					if (environment != null)
					{
						formulaEl.FactorString = Utility.DecimalFormatString(item.Factor, environment.DecimalFormat, environment.InformationDecimalFormat);
					}
					formulaEl.FactorType = item.TipoFactor;
					formulaEl.RegistrationStatus = item.EstadoRegistro;
					formulaEl.ValueSendType = item.ValorTipoEnvio;
					if (string.IsNullOrEmpty(formulaEl.ValueSendType))
						formulaEl.DescriptionSendType = "Todos";
					else
						formulaEl.DescriptionSendType = item.DescripcionTipoEnvio;
					formulaEl.DescriptionRegistrationStatus = item.DescripcionEstadoRegistro;
					formulaEl.Order = item.Orden;
					formulaEl.RowId = item.RowId;
					formulaEl.RowNumber = item.RowNumber;
					formulaEl.RowsTotal = item.RowsTotal;

					listFormulaEl.Add(formulaEl);
				}

				processResult.Result = listFormulaEl;
				processResult.IsSuccess = true;
			}
			catch (CustomException ex)
			{
				processResult.Result = null;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException("-1", "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar el registro de Fórmula
		/// </summary>
		/// <param name="filter">Fórmula a Registrar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Fórmula existente</returns>
		public ProcessResult<string> FormulaRegister(FormulaRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.BusinessUnitCode == null
					|| filter.ParameterCode == null
					|| string.IsNullOrEmpty(filter.Value)
					|| string.IsNullOrEmpty(filter.Operation)
					|| string.IsNullOrEmpty(filter.FactorString)
					|| string.IsNullOrEmpty(filter.FactorType)
					|| string.IsNullOrEmpty(filter.UserCreation)
					|| string.IsNullOrEmpty(filter.TerminalCreation)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				var resultFormulaSearch = FormulaSearch(new FormulaRequest() { BusinessUnitCode = filter.BusinessUnitCode, ParameterCode = filter.ParameterCode, Value = filter.Value, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

				if (resultFormulaSearch.Count > 0)
				{
					result = "3";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);

					return processResult;
				}

				int quantityAffectedRecords = 0;

				var currentQueryFormulaCode = Utility.GenerateQuery(new List<string>() { "ISNULL(MAX([" + "CODIGO_FORMULA" + "]), 0) + 1" }, new List<string>() { "MNT.FORMULA" });
				var currentRecordFormulaCode = ExecuteDynamicQuery(currentQueryFormulaCode).FirstOrDefault();
				filter.FormulaCode = Convert.ToInt32(currentRecordFormulaCode[currentRecordFormulaCode.Keys.FirstOrDefault()]);

				filter.RegistrationStatus = Enumerated.RegistrationStatus.Active;
				using (formula = new FormulaEN(new RepositoryStoredProcedure<FormulaEN>(dbContext)))
				{
					var formulaEn = new FormulaEN()
					{
						CodigoFormula = Convert.ToInt32(filter.FormulaCode),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoParametro = Convert.ToInt32(filter.ParameterCode),
						Valor = filter.Value,
						Operacion = filter.Operation,
						Factor = Convert.ToDecimal(Utility.StringFormatDecimal(filter.FactorString, environment.DecimalFormat, environment.InformationDecimalFormat)),
						ValorTipoEnvio = filter.ValueSendType,
						TipoFactor = filter.FactorType,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioCreacion = filter.UserCreation,
						TerminalCreacion = filter.TerminalCreation
					};

					quantityAffectedRecords = formula.FormulaRegister(formulaEn);

					if (quantityAffectedRecords >= 1)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultNewFormulaSearch = FormulaSearch(new FormulaRequest() { FormulaCode = filter.FormulaCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Formula.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.FormulaCode.ToString(),
																	   null,
																	   formulaEn.UsuarioCreacion,
																	   formulaEn.TerminalCreacion,
																	   null,
																	   resultNewFormulaSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}
				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite realizar la modificación de Fórmula
		/// </summary>
		/// <param name="filter">Fórmula a Modificar</param>
		/// <returns>Resultado del Proceso:    -1: Ocurrió un Error al Procesar
		///                                     0: No se realizó ninguna acción
		///                                     1: Registro Correcto
		///                                     2: No se enviaron los datos Obligatorios para el Registro
		///                                     3: Fórmula existente</returns>
		public ProcessResult<string> FormulaUpdate(FormulaRequest filter)
		{
			string result = "0";
			var processResult = new ProcessResult<string>();
			try
			{
				if (filter.FormulaCode == null
					|| filter.BusinessUnitCode == null
					|| (filter.ParameterCode == null && filter.Order == null)
					|| (string.IsNullOrEmpty(filter.Value) && filter.Order == null)
					|| (string.IsNullOrEmpty(filter.Operation) && filter.Order == null)
					|| (string.IsNullOrEmpty(filter.FactorString) && filter.Order == null)
					|| (string.IsNullOrEmpty(filter.FactorType) && filter.Order == null)
					|| string.IsNullOrEmpty(filter.RegistrationStatus)
					|| string.IsNullOrEmpty(filter.ModificationReason)
					|| string.IsNullOrEmpty(filter.UserModification)
					|| string.IsNullOrEmpty(filter.TerminalModification)
					)
				{
					result = "2";
					processResult.Result = result;
					processResult.IsSuccess = false;
					processResult.Exception = new CustomException(result);
					return processResult;
				}

				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Active && filter.ParameterCode != null && !string.IsNullOrEmpty(filter.Value)
					&& !string.IsNullOrEmpty(filter.Operation))
				{
					var resultFormulaSearch = FormulaSearch(new FormulaRequest() { BusinessUnitCode = filter.BusinessUnitCode, ParameterCode = filter.ParameterCode, Value = filter.Value, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result;

					if (resultFormulaSearch.Any(item => item.FormulaCode != filter.FormulaCode))
					{
						result = "3";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);

						return processResult;
					}
				}
				if (filter.RegistrationStatus == Enumerated.RegistrationStatus.Cancelled)
				{
					var resultFormulaCurrent = FormulaSearch(new FormulaRequest() { FormulaCode = filter.FormulaCode, BusinessUnitCode = filter.BusinessUnitCode, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();

					if (resultFormulaCurrent.Order != null && resultFormulaCurrent.Order >= 1)
					{
						result = "4";
						processResult.Result = result;
						processResult.IsSuccess = false;
						processResult.Exception = new CustomException(result);
						return processResult;
					}
				}
				if (filter.Factor == null && environment != null && !string.IsNullOrEmpty(filter.FactorString))
				{
					filter.Factor = Utility.StringFormatDecimal(filter.FactorString, environment.DecimalFormat, environment.InformationDecimalFormat);
				}
				int quantityAffectedRecords = 0;

				using (formula = new FormulaEN(new RepositoryStoredProcedure<FormulaEN>(dbContext)))
				{
					var formulaEn = new FormulaEN()
					{
						CodigoFormula = Convert.ToInt32(filter.FormulaCode),
						CodigoUnidadNegocio = Convert.ToInt32(filter.BusinessUnitCode),
						CodigoParametro = filter.ParameterCode,
						Valor = filter.Value,
						Operacion = filter.Operation,
						Factor = filter.Factor,
						TipoFactor = filter.FactorType,
						Orden = filter.Order,
						Observacion = filter.ModificationReason,
						ValorTipoEnvio = filter.ValueSendType,
						EstadoRegistro = filter.RegistrationStatus,
						UsuarioModificacion = filter.UserModification,
						TerminalModificacion = filter.TerminalModification
					};

					var resultOldFormulaSearch = FormulaSearch(new FormulaRequest() { FormulaCode = filter.FormulaCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
					quantityAffectedRecords = formula.FormulaUpdate(formulaEn);

					if (quantityAffectedRecords > 0)
					{
						//** Proceso para la Auditoria - Inicio **/
						var resultCurrentFormulaSearch = FormulaSearch(new FormulaRequest() { FormulaCode = filter.FormulaCode, BusinessUnitCode = filter.BusinessUnitCode }).Result;
						this.PolicyAuditRegister(EnumeratedTable.Formula.TableName,
																	   Convert.ToInt32(filter.BusinessUnitCode),
																	   filter.FormulaCode.ToString(),
																	   formulaEn.Observacion,
																	   formulaEn.UsuarioModificacion,
																	   formulaEn.TerminalModificacion,
																	   resultOldFormulaSearch.FirstOrDefault(),
																	   resultCurrentFormulaSearch.FirstOrDefault());
						//** Proceso para la Auditoria - Fin **/
					}

				}
				if (quantityAffectedRecords > 0)
				{
					result = "1";
					processResult.Result = result;
					processResult.IsSuccess = true;
					processResult.Exception = null;
					return processResult;
				}
			}
			catch (Exception ex)
			{
				result = "-1";
				processResult.Result = result;
				processResult.IsSuccess = false;
				processResult.Exception = new CustomException(result, "", ex);
			}
			return processResult;
		}

		/// <summary>
		/// Permite Registar el Orden de Ejecución de una Formula
		/// </summary>
		/// <param name="filter">Formula</param>
		/// <returns>Indicador de Conformidad</returns>
		public ProcessResult<string> FormulaOrderRegister(FormulaRequest filter)
		{
			ProcessResult<string> result = new ProcessResult<string>();
			result.Result = "0";
			result.IsSuccess = false;

			var formulaValidation = FormulaSearch(new FormulaRequest()
			{
				BusinessUnitCode = filter.BusinessUnitCode,
				RegistrationStatus = Enumerated.RegistrationStatus.Active
			}).Result.OrderBy(item => item.Order);

			byte orderFormula = Convert.ToByte(Convert.ToByte(formulaValidation.LastOrDefault().Order) + 1);
			if (!formulaValidation.Any(item => item.FormulaCode == filter.FormulaCode && item.Order != null && item.Order >= 1))
			{
				var resultFormulaUpdate = FormulaUpdate(new FormulaRequest()
				{
					FormulaCode = filter.FormulaCode,
					BusinessUnitCode = filter.BusinessUnitCode,
					Order = orderFormula,
					RegistrationStatus = Enumerated.RegistrationStatus.Active,
					ModificationReason = "Asignación de Orden",
					UserModification = filter.UserModification,
					TerminalModification = filter.TerminalModification
				}
					);
				if (resultFormulaUpdate.Result == "1" || resultFormulaUpdate.Result == "-1")
				{
					result = resultFormulaUpdate;
				}
			}
			else
			{
				result.Result = "2";
				result.IsSuccess = false;
			}
			return result;
		}

		/// <summary>
		/// Permite Actualizar el Orden de Ejecución de una Formula
		/// </summary>
		/// <param name="filter">Formula</param>
		/// <returns>Indicador de Conformidad</returns>
		public ProcessResult<string> FormulaOrderUpdate(FormulaRequest filter)
		{
			ProcessResult<string> result = new ProcessResult<string>();
			result.Result = "0";
			result.IsSuccess = false;
			var resultFormulaUpdate = FormulaUpdate(new FormulaRequest()
			{
				FormulaCode = filter.FormulaCode,
				BusinessUnitCode = filter.BusinessUnitCode,
				Order = 0,
				ModificationReason = filter.ModificationReason,
				UserModification = filter.UserModification,
				TerminalModification = filter.TerminalModification,
				RegistrationStatus = Enumerated.RegistrationStatus.Active
			}
			);

			if (resultFormulaUpdate.Result == "1" || resultFormulaUpdate.Result == "-1")
			{
				result = resultFormulaUpdate;
			}

			return result;
		}

		/// <summary>
		/// Permite generar Consulta Dinamica
		/// </summary>
		/// <param name="query">Script a Ejecutar</param>
		/// <returns>Lista de Resultado</returns>
		public List<Dictionary<string, object>> ExecuteDynamicQuery(string query)
		{
			var resultado = new List<Dictionary<string, object>>();
			try
			{
				using (dynamicEntity = new DynamicEntityEN(new RepositoryStoredProcedure<DynamicEntityEN>(dbContext)))
				{
					resultado = dynamicEntity.ExecuteDynamicQueryDictionary(query);
				}
			}
			catch (Exception)
			{
				resultado = new List<Dictionary<string, object>>();
			}
			return resultado;
		}

		/// <summary>
		/// Permite el registro de Auditoría General
		/// </summary>
		/// <param name="tableName">Nombre de Tabla</param>
		/// <param name="businessUnitCode">Código de Unidad de Negocio</param>
		/// <param name="registrationTableCode">Código de registro de tabla</param>
		/// <param name="gloss">Glosa</param>
		/// <param name="userAudit">Usuario de Auditoría</param>
		/// <param name="terminalAudit">Terminal de Auditoría</param>
		/// <param name="currentValue">Valor Actual</param>
		/// <param name="newValue">Nuevo Valor</param>
		/// <returns>Resultado del Proceso</returns>
		public int PolicyAuditRegister(string tableName, int businessUnitCode, string registrationTableCode, string gloss, string userAudit, string terminalAudit, Object currentValue, Object newValue)
		{
			int result = 0;
			try
			{
				Dictionary<string, object> currentValues = new Dictionary<string, object>();

				if (currentValue != null)
				{
					Type typeActual = currentValue.GetType();
					var currentProperties = typeActual.GetProperties();

					foreach (var itemcurrentProperties in currentProperties)
					{
						var currentFieldName = itemcurrentProperties.Name;

						PropertyInfo currentInfo = typeActual.GetProperty(currentFieldName);
						var valorCampoActual = currentInfo.GetValue(currentValue, null);

						int currentValidation = Utility.validateColumns(currentFieldName);
						if (currentValidation == 0)
						{
							currentValues.Add(currentFieldName, valorCampoActual);
						}
					}
				}

				Dictionary<string, object> newValues = new Dictionary<string, object>();
				Type newType = newValue.GetType();
				var newProperties = newType.GetProperties();

				foreach (var itemNewProperties in newProperties)
				{
					var newFieldName = itemNewProperties.Name;

					PropertyInfo newInfo = newType.GetProperty(newFieldName);
					var valueFieldName = newInfo.GetValue(newValue, null);

					int newValidation = Utility.validateColumns(newFieldName);
					if (newValidation == 0)
					{
						newValues.Add(newFieldName, valueFieldName);
					}
				}

				List<PolicyAuditEN> listPolicyAuditEn = new List<PolicyAuditEN>();
				foreach (var itemNewField in newValues)
				{
					PolicyAuditEN policyAuditEn = new PolicyAuditEN();
					if (currentValue != null)
					{
						if (currentValues.Count > 0 && currentValues.Any(item => item.Key == itemNewField.Key && (Convert.ToString(item.Value) != Convert.ToString(itemNewField.Value))))
						{
							policyAuditEn.NombreColumna = itemNewField.Key;
							policyAuditEn.ValorAnterior = Convert.ToString(currentValues[itemNewField.Key]);
							policyAuditEn.ValorNuevo = (itemNewField.Value != null) ? itemNewField.Value.ToString() : null;

							policyAuditEn.NombreTabla = tableName;
							policyAuditEn.CodigoUnidadNegocio = businessUnitCode;
							policyAuditEn.CodigoRegistroTabla = registrationTableCode;
							policyAuditEn.Glosa = gloss;
							policyAuditEn.UsuarioAuditoria = userAudit;
							policyAuditEn.TerminalAuditoria = terminalAudit;

							listPolicyAuditEn.Add(policyAuditEn);
						}
					}
					else
					{
						if (itemNewField.Value != null && Convert.ToString(itemNewField.Value).Trim() != "")
						{
							policyAuditEn = new PolicyAuditEN();
							policyAuditEn.NombreTabla = tableName;
							policyAuditEn.NombreColumna = itemNewField.Key;
							policyAuditEn.CodigoUnidadNegocio = businessUnitCode;
							policyAuditEn.CodigoRegistroTabla = registrationTableCode;
							policyAuditEn.ValorAnterior = "";
							policyAuditEn.ValorNuevo = Convert.ToString(itemNewField.Value);
							policyAuditEn.Glosa = "";
							policyAuditEn.UsuarioAuditoria = userAudit;
							policyAuditEn.TerminalAuditoria = terminalAudit;

							listPolicyAuditEn.Add(policyAuditEn);
						}
					}
				}

				foreach (var itemModified in listPolicyAuditEn)
				{
					using (policyAudit = new PolicyAuditEN(new RepositoryStoredProcedure<PolicyAuditEN>(new DataBaseAuditContext())))
					{
						result = policyAudit.PolicyAuditRegister(itemModified);
					}
				}
			}
			catch (Exception)
			{
				result = -1;
			}
			return result;
		}

		/// <summary>
		/// Permite listar los nombres de las tabla de Auditoría de Fletes
		/// </summary>
		/// <param name="registrationStatus">Estado de Registro</param>
		/// <returns>Lista de Tabla de Auditoría de Fletes</returns>
		public List<PolicyAuditTableEL> PolicyAuditTableSearch(string registrationStatus)
		{
			List<PolicyAuditTableEL> listFreightAuditTableEl = new List<PolicyAuditTableEL>();
			using (policyAuditTable = new PolicyAuditTableEN(new RepositoryStoredProcedure<PolicyAuditTableEN>(new DataBaseAuditContext())))
			{
				var listPolicyAuditTable = policyAuditTable.PolicyAuditTableSearch(registrationStatus);
				foreach (var item in listPolicyAuditTable)
				{
					PolicyAuditTableEL policyAuditTableEl = new PolicyAuditTableEL();
					policyAuditTableEl.CodeTableAudit = item.CodigoAuditoriaTabla;
					policyAuditTableEl.TableName = item.NombreTabla;
					listFreightAuditTableEl.Add(policyAuditTableEl);
				}
			}
			return listFreightAuditTableEl;
		}

		/// <summary>
		/// Permite listar los nombres de Columnas de las tablas de Auditoría de Fletes
		/// </summary>
		/// <param name="tableCode">Código de Tabla</param>
		/// <param name="registrationStatus">Estado de Registro</param>
		/// <returns>Lista de Columna de Tablas de Auditoría de Fletes</returns>
		public List<PolicyAuditColumnEL> PolicyAuditColumnSearch(int? tableCode, string registrationStatus)
		{
			List<PolicyAuditColumnEL> listPolicyAuditColumnEl = new List<PolicyAuditColumnEL>();
			using (policyAuditColumn = new PolicyAuditColumnEN(new RepositoryStoredProcedure<PolicyAuditColumnEN>(new DataBaseAuditContext())))
			{
				var listPolicyAuditColumn = policyAuditColumn.PolicyAuditColumnSearch(tableCode, registrationStatus);
				foreach (var item in listPolicyAuditColumn)
				{
					PolicyAuditColumnEL policyAuditColumnEl = new PolicyAuditColumnEL();
					policyAuditColumnEl.CodeColumnAudit = item.CodigoAuditoriaColumna;
					policyAuditColumnEl.ColumnName = item.NombreColumna;
					listPolicyAuditColumnEl.Add(policyAuditColumnEl);
				}
			}
			return listPolicyAuditColumnEl;
		}

		/// <summary>
		/// Obtiene la Fecha de la Unidad de Negocio
		/// </summary>
		/// <param name="businessUnitCode">Código de Unidad de Negocio</param>
		/// <param name="countryCode">Código de País</param>
		/// <param name="getOnlyDateIndicator">Obtener solo fecha</param>
		/// <returns>Obtine Fecha</returns>
		public DateTime GetDateTimeBusinessUnit(int? businessUnitCode)
		{
			return GetDateTimeBusinessUnit(businessUnitCode, null, true);
		}

		/// <summary>
		/// Obtiene la Fecha de la Unidad de Negocio
		/// </summary>
		/// <param name="businessUnitCode">Código de Unidad de Negocio</param>
		/// <param name="countryCode">Código de País</param>
		/// <param name="getOnlyDateIndicator">Obtener solo fecha</param>
		/// <returns>Obtine Fecha</returns>
		public DateTime GetDateTimeBusinessUnit(int? businessUnitCode, string countryCode, bool getOnlyDateIndicator)
		{
			var processResult = new DateTime();
			try
			{
				var resultCountryEn = new DateTimeBusinessUnitEN();

				using (dateTimeBusinessUnit = new DateTimeBusinessUnitEN(new RepositoryStoredProcedure<DateTimeBusinessUnitEN>(dbContext)))
				{
					resultCountryEn = dateTimeBusinessUnit.GetDateTimeBusinessUnit(businessUnitCode, countryCode);
				}
				if (getOnlyDateIndicator)
				{
					processResult = Convert.ToDateTime(resultCountryEn.FechaUnidadNegocio).Date;
				}
				else
				{
					processResult = Convert.ToDateTime(resultCountryEn.FechaUnidadNegocio);
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
			}
			return processResult;
		}

		/// <summary>
		/// Obtiene código de Pais, Provincia, Ciudad y Distrito
		/// </summary>
		/// <param name="ubicationCode">Código de Unidad de Zona</param>
		/// <returns>Obtiene Objeto FreightUbicationEL</returns>
		public FreightUbicationEL UbicationSearch(string ubicationCode)
		{
			FreightUbicationEL freightUbicationEL = null;
			try
			{
				FreightUbicationEN freightUbicationEn; ;

				using (freightUbication = new FreightUbicationEN(new RepositoryStoredProcedure<FreightUbicationEN>(dbContext)))
				{
					freightUbicationEn = freightUbication.UbicationSearch(ubicationCode);
				}
				if (freightUbicationEn != null)
				{
					freightUbicationEL = new FreightUbicationEL();
					freightUbicationEL.CodigoPais = freightUbicationEn.CodigoPais;
					freightUbicationEL.CodigoProvincia = freightUbicationEn.CodigoProvincia;
					freightUbicationEL.CodigoCiudad = freightUbicationEn.CodigoCiudad;
					freightUbicationEL.CodigoDistrito = freightUbicationEn.CodigoDistrito;
				}
			}
			catch (CustomException ex)
			{
				ex.ToString();
			}
			return freightUbicationEL;
		}

		/// <summary>
		///  Obtiene Lista Parametros configuracion
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public ConfiguracionKeyResponse ListParameterValueSearchGeneralConfiguracion(ParameterValueRequest filter)
		{
			ConfiguracionKeyResponse configuracionKeyResponse = new ConfiguracionKeyResponse();
			IEnumerable<ParametrosConfiguracion> resultKey = null;
			List<ParameterValueEN> resultParametervalueEn;
			using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
			{
				resultParametervalueEn = parameterValue.ParameterValueSearchKeyEndpoint(Convert.ToInt32(filter.BusinessUnitCode), filter.Code, filter.ComponentName);
			}
			var result = resultParametervalueEn.Select(x => new ParameterValueEL
			{
				BusinessUnitCode = x.CodigoUnidadNegocio,
				CodeParameter = x.CodigoParametro,
				CodeSection = x.CodigoSeccion,
				CodeValue = x.CodigoValor,
				Value = x.Valor,
				Code = x.Codigo
			}).ToList();

			resultKey = from param1 in result.Where(x => x.CodeSection == Enumerated.SeccionParametrosConfig.Codigo)
						join param2 in result.Where(z => z.CodeSection == Enumerated.SeccionParametrosConfig.Componentes) on param1.CodeValue equals param2.CodeValue
						join param3 in result.Where(y => y.CodeSection == Enumerated.SeccionParametrosConfig.Valor) on param1.CodeValue equals param3.CodeValue
						join param4 in result.Where(z => z.CodeSection == Enumerated.SeccionParametrosConfig.Descripcion) on param1.CodeValue equals param4.CodeValue
						select new ParametrosConfiguracion
						{
							CodigoParametro = param1.CodeParameter,
							Codigo = param1.Value,
							Componentes = param2.Value,
							Valor = param3.Value,
							Descripcion = param4.Value
						};
			if (resultKey != null && resultKey.Any())
			{
				configuracionKeyResponse = new ConfiguracionKeyResponse()
				{
					CookieNameJ6 = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.cookieNameJ6)?.Valor,
					SrvReportingUrl = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.reportingUrl)?.Valor,
					SrvReportingUser = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.reportingUser)?.Valor,
					SrvReportingPassword = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.reportingPassword)?.Valor,
					SrvReportingDomain = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.reportingDomain)?.Valor,
					SrvReportingWorkspace = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.reportingWorkspace)?.Valor,
					SrvReportingPathPolicy = resultKey.FirstOrDefault(x => x.Codigo == Enumerated.CodigoParametroConfig.reportingPathPolicy)?.Valor
				};
			}
			return configuracionKeyResponse;
		}

		/// <summary>
		/// Obtiene Lista Parametros Endpoint
		/// </summary>
		/// <param name="filter"></param>
		/// <returns>Obtiene Objeto FreightUbicationEL</returns>
		public ConfiguracionEndPointResponse ListParameterValueSearchGeneralEndPoint(ParameterValueRequest filter)
		{
			ConfiguracionEndPointResponse configuracionEndPointResponse = new ConfiguracionEndPointResponse();

			List<EndPointParameterConfig> resultEndpoint = null;
			List<ParameterValueEN> resultParametervalueEn;
			using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
			{
				resultParametervalueEn = parameterValue.ParameterValueSearchKeyEndpoint(Convert.ToInt32(filter.BusinessUnitCode), filter.Code, filter.ComponentName);
			}
			var result = resultParametervalueEn.Select(x => new ParameterValueEL
			{
				BusinessUnitCode = x.CodigoUnidadNegocio,
				CodeParameter = x.CodigoParametro,
				CodeSection = x.CodigoSeccion,
				CodeValue = x.CodigoValor,
				Value = x.Valor,
				Code = x.Codigo
			}).ToList();

			if (result != null && result.Any())
			{
				resultEndpoint = (from param1 in result.Where(x => x.CodeSection == Enumerated.SeccionEndPointConfig.Codigo)
								  join param2 in result.Where(z => z.CodeSection == Enumerated.SeccionEndPointConfig.Componentes) on param1.CodeValue equals param2.CodeValue
								  join param3 in result.Where(z => z.CodeSection == Enumerated.SeccionEndPointConfig.Descripcion) on param1.CodeValue equals param3.CodeValue
								  select new EndPointParameterConfig
								  {
									  CodigoValor = param1.CodeValue,
									  Codigo = param1.Value,
									  Componentes = param2.Value,
									  Descripcion = param3.Value
								  }).ToList();

				var listUrl = result.Where(x => x.CodeSection >= 4).ToList();
				foreach (var item in resultEndpoint)
				{
					var nodo = 0;
					foreach (var itemUrl in listUrl)
					{
						if (item.CodigoValor == itemUrl.CodeValue)
						{
							nodo += 1;
							item.RutasUrlService.Add(new UrlServiceNodo() { IdNodo = nodo, UrlService = itemUrl.Value });
						}
					}
				}
			}

			if (resultEndpoint != null && resultEndpoint.Any())
			{
				configuracionEndPointResponse.endpointSrvMSFSecurity = EndPointService.GenerarParametrosConfig(resultEndpoint, Enumerated.EndPointConfig.srvMSFSecurity, Enumerated.NodoCluster);
				configuracionEndPointResponse.endpointSrvMSFTokenSecurity = EndPointService.GenerarParametrosConfig(resultEndpoint, Enumerated.EndPointConfig.srvMSFTokenSecurity, Enumerated.NodoCluster);
			}
			return configuracionEndPointResponse;
		}

		/// <summary>
		/// Obtener Version Componente
		/// </summary>
		/// <param name="NombreSistema"></param>
		/// <param name="NombreComponente"></param>
		/// <returns></returns>
		public UpdateVersionComponenteResponse ObtenerVersionComponente(string NombreSistema, string NombreComponente)
		{
			UpdateVersionComponenteResponse updateVersionComponenteResponse = new UpdateVersionComponenteResponse();
			updateVersionComponenteResponse.updateVersionComponente = new List<UpdateVersionComponenteEL>();
			using (updateVersionComponente = new UpdateVersionComponenteEN(new RepositoryStoredProcedure<UpdateVersionComponenteEN>()))
			{
				var ListVersion = updateVersionComponente.ObtenerVersionComponente(NombreSistema, NombreComponente);
				foreach (var item in ListVersion)
				{
					UpdateVersionComponenteEL updateVersionComponenteEL = new UpdateVersionComponenteEL();
					updateVersionComponenteEL.LineaNegocio = item.LineaNegocio;
					updateVersionComponenteEL.NombreSistema = item.NombreSistema;
					updateVersionComponenteEL.NombreVersion = item.NombreVersion;
					updateVersionComponenteEL.CodigoComponente = item.CodigoComponente;
					updateVersionComponenteEL.NombreComponente = item.NombreComponente;
					updateVersionComponenteEL.NombreTags = item.NombreTags;
					updateVersionComponenteResponse.updateVersionComponente.Add(updateVersionComponenteEL);
				}
				return updateVersionComponenteResponse;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public List<ParameterValueEL> ListarParametroValorLog4Net(ParameterValueRequest filter)
		{
			List<ParameterValueEL> ParametroValorResponse = new List<ParameterValueEL>();
			List<ParameterValueEN> ListarParametroValor;
			using (parameterValue = new ParameterValueEN(new RepositoryStoredProcedure<ParameterValueEN>(dbContext)))
			{
				ListarParametroValor = parameterValue.ListarParametroValorLog4Net(
					filter.BusinessUnitCode, filter.CountryCode, filter.Code, filter.CodeValue.Value);
			}
			if (ListarParametroValor != null)
			{
				foreach (var item in ListarParametroValor)
				{
					ParametroValorResponse.Add(new ParameterValueEL()
					{
						Correlativo = item.Correlativo,
						CodigoParametro = item.CodigoParametro,
						NombreParametro = item.NombreParametro,
						sCodigoSeccion = item.sCodigoSeccion,
						NombreParametroSeccion = item.NombreParametroSeccion,
						sCodigoValor = item.sCodigoValor,
						Valor = item.Valor
					});
				}
			}
			return ParametroValorResponse;
		}
	}
}