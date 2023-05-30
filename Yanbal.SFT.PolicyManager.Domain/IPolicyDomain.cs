using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.FreightManagement.Common.Parametros;

namespace Yanbal.SFT.PolicyManager.Domain
{
	/// <summary>
	/// Interfaz que Define Application Policy
	/// </summary>
	public interface IPolicyDomain
	{
		/// <summary>
		/// ExecuteDynamicQuery
		/// </summary>
		List<Dictionary<string, object>> ExecuteDynamicQuery(string query);
		/// <summary>
		/// CountrySearch
		/// </summary>
		ProcessResult<List<CountryEL>> CountrySearch(CountryRequest filter);
		/// <summary>
		/// LanguageSearch
		/// </summary>
		ProcessResult<List<LanguageEL>> LanguageSearch(LanguageRequest filter);
		/// <summary>
		/// StringFormatSearch
		/// </summary>
		ProcessResult<List<StringFormatEL>> StringFormatSearch(StringFormatRequest filter);
		/// <summary>
		/// BusinessUnitSearch
		/// </summary>
		ProcessResult<List<BusinessUnitEL>> BusinessUnitSearch(BusinessUnitRequest filter);
		/// <summary>
		/// BusinessUnitRegister
		/// </summary>
		ProcessResult<string> BusinessUnitRegister(BusinessUnitRequest filter);
		/// <summary>
		/// BusinessUnitUpdate
		/// </summary>
		ProcessResult<string> BusinessUnitUpdate(BusinessUnitRequest filter);
		/// <summary>
		/// CultureSearch
		/// </summary>
		ProcessResult<List<CultureEL>> CultureSearch(CultureRequest filter);
		/// <summary>
		/// CultureRegister
		/// </summary>
		ProcessResult<string> CultureRegister(CultureRequest filter);
		/// <summary>
		/// CultureUpdate
		/// </summary>
		ProcessResult<string> CultureUpdate(CultureRequest filter);
		/// <summary>
		/// TimeZoneSearch
		/// </summary>
		ProcessResult<List<TimeZoneEL>> TimeZoneSearch(TimeZoneRequest filter);
		/// <summary>
		/// BusinessUnitConfigurationSearch
		/// </summary>
		ProcessResult<List<BusinessUnitConfigurationEL>> BusinessUnitConfigurationSearch(BusinessUnitConfigurationRequest filter);
		/// <summary>
		/// GetLogoBusinessUnitConfiguration
		/// </summary>
		List<BusinessUnitConfigurationEL> GetLogoBusinessUnitConfiguration(BusinessUnitConfigurationRequest filter);
		/// <summary>
		/// BusinessUnitConfigurationRegister
		/// </summary>
		ProcessResult<string> BusinessUnitConfigurationRegister(BusinessUnitConfigurationRequest filter);
		/// <summary>
		/// BusinessUnitConfigurationUpdate
		/// </summary>
		ProcessResult<string> BusinessUnitConfigurationUpdate(BusinessUnitConfigurationRequest filter);
		/// <summary>
		/// ParameterSearch
		/// </summary>
		ProcessResult<List<ParameterEL>> ParameterSearch(ParameterRequest filter);
		/// <summary>
		/// ParameterValueSearch
		/// </summary>
		ProcessResult<List<ParameterValueEL>> ParameterValueSearch(ParameterValueRequest filter);
		/// <summary>
		/// ParameterRegister
		/// </summary>
		ProcessResult<string> ParameterRegister(ParameterRequest filter);
		/// <summary>
		/// ParameterValueRegister
		/// </summary>
		ProcessResult<string> ParameterValueRegister(ParameterValueRequest filter);
		/// <summary>
		/// ParameterUpdate
		/// </summary>
		ProcessResult<string> ParameterUpdate(ParameterRequest filter);
		/// <summary>
		/// ParameterValueUpdate
		/// </summary>
		ProcessResult<string> ParameterValueUpdate(ParameterValueRequest filter);
		/// <summary>
		/// ParameterSectionSearch
		/// </summary>
		ProcessResult<List<ParameterSectionEL>> ParameterSectionSearch(ParameterSectionRequest filter);
		/// <summary>
		/// ParameterSectionRegister
		/// </summary>
		ProcessResult<string> ParameterSectionRegister(ParameterSectionRequest filter);
		/// <summary>
		/// ParameterSectionUpdate
		/// </summary>
		ProcessResult<string> ParameterSectionUpdate(ParameterSectionRequest filter);
		/// <summary>
		/// ProvinceSearch
		/// </summary>
		ProcessResult<List<ProvinceEL>> ProvinceSearch(ProvinceRequest filter);
		/// <summary>
		/// CitySearch
		/// </summary>
		ProcessResult<List<CityEL>> CitySearch(CityRequest filter);
		/// <summary>
		/// DistrictSearch
		/// </summary>
		ProcessResult<List<DistrictEL>> DistrictSearch(DistrictRequest filter);
		/// <summary>
		/// UbigeoZoneTypeSearch
		/// </summary>
		ProcessResult<List<UbigeoZoneTypeEL>> UbigeoZoneTypeSearch(UbigeoZoneTypeRequest filter);
		/// <summary>
		/// UbigeoZoneTypeRegister
		/// </summary>
		ProcessResult<string> UbigeoZoneTypeRegister(UbigeoZoneTypeRequest filter);
		/// <summary>
		/// UbigeoZoneTypeUpdate
		/// </summary>
		ProcessResult<string> UbigeoZoneTypeUpdate(UbigeoZoneTypeRequest filter);
		/// <summary>
		/// CombinationOrderSearch
		/// </summary>
		ProcessResult<List<CombinationOrderEL>> CombinationOrderSearch(CombinationOrderRequest filter);
		/// <summary>
		/// CombinationOrderRegister
		/// </summary>
		ProcessResult<string> CombinationOrderRegister(CombinationOrderRequest filter);
		/// <summary>
		/// CombinationOrderUpdate
		/// </summary>
		ProcessResult<string> CombinationOrderUpdate(CombinationOrderRequest filter);
		/// <summary>
		/// CombinationSearch
		/// </summary>
		ProcessResult<List<CombinationEL>> CombinationSearch(CombinationRequest filter);
		/// <summary>
		/// CombinationRegister
		/// </summary>
		ProcessResult<string> CombinationRegister(CombinationRequest filter);
		/// <summary>
		/// CombinationUpdate
		/// </summary>
		ProcessResult<string> CombinationUpdate(CombinationRequest filter);
		/// <summary>
		/// ParameterCombinationSearch
		/// </summary>
		ProcessResult<List<ParameterCombinationEL>> ParameterCombinationSearch(ParameterCombinationRequest filter);
		/// <summary>
		/// ParameterCombinationUpdate
		/// </summary>
		ProcessResult<string> ParameterCombinationUpdate(CombinationRequest filter);
		/// <summary>
		/// FormulaSearch
		/// </summary>
		ProcessResult<List<FormulaEL>> FormulaSearch(FormulaRequest filter);
		/// <summary>
		/// FormulaRegister
		/// </summary>
		ProcessResult<string> FormulaRegister(FormulaRequest filter);
		/// <summary>
		/// FormulaUpdate
		/// </summary>
		ProcessResult<string> FormulaUpdate(FormulaRequest filter);
		/// <summary>
		/// FormulaOrderRegister
		/// </summary>
		ProcessResult<string> FormulaOrderRegister(FormulaRequest filter);
		/// <summary>
		/// FormulaOrderUpdate
		/// </summary>
		ProcessResult<string> FormulaOrderUpdate(FormulaRequest filter);
		/// <summary>
		/// PolicyAuditTableSearch
		/// </summary>
		List<PolicyAuditTableEL> PolicyAuditTableSearch(string registrationStatus);
		/// <summary>
		/// PolicyAuditColumnSearch
		/// </summary>
		List<PolicyAuditColumnEL> PolicyAuditColumnSearch(int? tableCode, string registrationStatus);
		/// <summary>
		/// GetDateTimeBusinessUnit
		/// </summary>
		DateTime GetDateTimeBusinessUnit(int? businessUnitCode);
		/// <summary>
		/// GetDateTimeBusinessUnit
		/// </summary>
		DateTime GetDateTimeBusinessUnit(int? businessUnitCode, string countryCode, bool getOnlyDateIndicator);
		/// <summary>
		/// UbicationSearch
		/// </summary>
		FreightUbicationEL UbicationSearch(string ubicationCode);

		/// <summary>
		/// ListParameterValueSearchGeneralConfiguracion
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		ConfiguracionKeyResponse ListParameterValueSearchGeneralConfiguracion(ParameterValueRequest filter);

		/// <summary>
		/// ListParameterValueSearchGeneralEndPoint
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		ConfiguracionEndPointResponse ListParameterValueSearchGeneralEndPoint(ParameterValueRequest filter);
		/// <summary>
		/// Obtener Version Componente
		/// </summary>
		/// <param name="NombreSistema"></param>
		/// <param name="NombreComponente"></param>
		/// <returns></returns>
		UpdateVersionComponenteResponse ObtenerVersionComponente(string NombreSistema, string NombreComponente);

		/// <summary>
		/// ListarParametroValorLog4Net
		/// </summary>
		List<ParameterValueEL> ListarParametroValorLog4Net(ParameterValueRequest filter);
	}
}
