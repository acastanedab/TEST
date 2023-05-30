using System;
using System.Collections.Generic;

namespace Yanbal.SFT.Domain.Entities.Policy.ParameterValue
{
	/// <summary>
	/// Interfaz que Define la Entidad de Negocio de Parámetro Valor
	/// </summary>
	public interface IParameterValue : IDisposable
	{
		/// <summary>
		/// ParameterValueSearch
		/// </summary>
		List<ParameterValueEN> ParameterValueSearch(int businessUnitCode, int? parameterCode, string code, int? sectionCode, int? valueCode, string value, string status);
		/// <summary>
		/// ParameterValueRegister
		/// </summary>
		int ParameterValueRegister(ParameterValueEN register);
		/// <summary>
		/// ParameterValueUpdate
		/// </summary>
		int ParameterValueUpdate(ParameterValueEN register);
		/// <summary>
		/// ListarParametroValorLog4Net
		/// </summary>
		List<ParameterValueEN> ListarParametroValorLog4Net(int? CodigoUnidadNegocio, string CodigoPais, string Codigo, int CodigoValor);
		/// <summary>
		/// Obtener Configuración de Key - EndPoint
		/// </summary>
		/// <param name="businessUnitCode"></param>
		/// <param name="code"></param>
		/// <param name="componentName"></param>
		/// <returns></returns>
		List<ParameterValueEN> ParameterValueSearchKeyEndpoint(int businessUnitCode, string code, string componentName);
	}
}
