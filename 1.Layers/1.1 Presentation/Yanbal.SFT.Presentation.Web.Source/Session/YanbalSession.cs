using System;
using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Session
{
	/// <summary>
	/// Objeto que representa lo almacenado en Sesión
	/// </summary>
	[Serializable]
	public class YanbalSession
	{
		/// <summary>
		/// Constructor por Defecto de implementación de la clase
		/// </summary>
		public YanbalSession()
		{
		}

		/// <summary>
		/// Seguridad de la Sesión
		/// </summary>
		public SecuritySession SecuritySession { get; set; }

		/// <summary>
		/// Usuario que Accedió al Sistema
		/// </summary>
		public User User { get; set; }

		/// <summary>
		/// Unidad de Negocio del Sistema
		/// </summary>
		public BusinessUnitEL BusinessUnit { get; set; }

		/// <summary>
		/// Lista de Paices
		/// </summary>
		public List<CountryEL> ListCountry { get; set; }

		/// <summary>
		/// Lista de Estados de Registro
		/// </summary>
		public List<SelectType> ListRegistrationStatus { get; set; }
		/// <summary>
		/// Login Name
		/// </summary>
		public string LoginName { get; set; }
		/// <summary>
		/// Menú
		/// </summary>
		public MenuRequest Menu { get; set; }

		/// <summary>
		/// Permisos de Accesos al Sistema
		/// </summary>
		public MenuRequest Permissions { get; set; }

		/// <summary>
		/// Filtros de Búsqueda de Parámetros
		/// </summary>
		public ParameterRequest FilterParameterRequest { get; set; }

		/// <summary>
		/// Unidad de Negocio a Registrar
		/// </summary>
		public BusinessUnitRequest FilterBusinessUnitRequest { get; set; }

		/// <summary>
		/// IsValidCaptcha
		/// </summary>
		public bool IsValidCaptcha { get; set; }
		/// <summary>
		/// ControllerName
		/// </summary>
		public string ControllerName { get; set; }
		/// <summary>
		/// VersionCaptcha
		/// </summary>
		public string VersionCaptcha { get; set; }

		/// <summary>
		/// token
		/// </summary>
		public string token { get; set; }
		/// <summary>
		/// Código de unidad de negocio
		/// </summary>
		public int CodigoUnidadNegocio { get; set; }
		/// <summary>
		/// Idioma Inicial
		/// </summary>
		public string IdiomaInicial { get; set; }
		/// <summary>
		/// Cultura Inicio
		/// </summary>
		public string CulturaInicio { get; set; }
		/// <summary>
		/// Nombre Cookie J6
		/// </summary>
		public string CookieNameJ6 { get; set; }
		/// <summary>
		/// Reporting Url
		/// </summary>
		public string ReportingUrl { get; set; }
		/// <summary>
		/// Reporting User
		/// </summary>
		public string ReportingUser { get; set; }
		/// <summary>
		/// Reporting Password
		/// </summary>
		public string ReportingPassword { get; set; }
		/// <summary>
		/// Reporting Domain
		/// </summary>
		public string ReportingDomain { get; set; }
		/// <summary>
		/// Reporting Workspace Path Security
		/// </summary>
		public string ReportingWorkspacePathPolicy { get; set; }
		/// <summary>
		/// ISRAService Name
		/// </summary>
		public string endpointSrvMSFSecurityName { get; set; }
		/// <summary>
		/// ISRAService Url
		/// </summary>
		public string endpointSrvMSFSecurityUrl { get; set; }
		/// <summary>
		/// TokenSecurity Name
		/// </summary>
		public string endpointSrvMSFTokenSecurityName { get; set; }
		/// <summary>
		/// TokenSecurity Url
		/// </summary>
		public string endpointSrvMSFTokenSecurityUrl { get; set; }
		/// <summary>
		/// token
		/// </summary>
		public string IdTransaccionLog { get; set; }
	}
}