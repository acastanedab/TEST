using Yanbal.SFT.Presentation.Web.Source.Models.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yanbal.SFT.Presentation.Web.Source.Session;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.Domain.Entities.Logic.Common;
using Yanbal.SFT.FreightManagement.Common.Format;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using System.Globalization;
using System.Resources;
using System.Collections;
using Yanbal.SFT.Presentation.Web.Source.Resources.Shared;
using Yanbal.SFT.Presentation.Web.Source.Common;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Common
{
    /// <summary>
    /// Clase Base del Contexto de la Aplicación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140717 <br />
    /// Modificación:
    /// </remarks>
    public static class BaseContext
    {

        /// <summary>
        /// Permite obtener permisos por control Button
        /// </summary>
        /// <param name="id">Código de Control</param>
        /// <param name="resource">Recurso</param>
        /// <param name="button">Botón</param>
        public static void GetAccessControl(string id, string resource, Models.Base.ButtonControl button)
        {
            ControlPermissions permisos = GetPermission(id, resource);
            button.Enabled = permisos.Enabled;
            button.Visible = permisos.Visible;
            
        }
        
        /// <summary>
        /// Permite obtener permisos por control Link
        /// </summary>
        /// <param name="id">Código de Control</param>
        /// <param name="resource">Recurso</param>
        /// <param name="button">Botón de Tipo Link</param>
        public static void GetAccessControl(string id, string resource, Models.Base.LinkControl button)
        {
            ControlPermissions permisos = GetPermission(id, resource);
            button.Enabled = permisos.Enabled;
            button.Visible = permisos.Visible;
            

        }
        
        /// <summary>
        /// Permite obtener permisos por control ImageControl
        /// </summary>
        /// <param name="id">Código de Control</param>
        /// <param name="resource">Recurso</param>
        /// <param name="button">Botón de Tipo Imagen</param>
        public static void GetAccessControl(string id, string resource, Models.Base.ImageControl button)
        {
            ControlPermissions permisos = GetPermission(id, resource);
            button.Enabled = permisos.Enabled;
            button.Visible = permisos.Visible;
            
        }

        /// <summary>
        /// Permite obtener permisos de políticas por Código de Opción y Recursos
        /// </summary>
        /// <param name="optionCode">Código de Opción</param>
        /// <param name="resource">Recurso</param>
        /// <returns>Permisos de habilitación y visibilidad de controles</returns>
        public static ControlPermissions GetPermission(string optionCode, string resource)
        {
            var yanbalSession = Yanbal.SFT.Presentation.Web.Source.Session.SessionContext.GetYanbalSession();
                        
            string areaName = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString();
            string controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
            

            string url = areaName + "/" + controllerName;

            var actionsSecurity = yanbalSession.Permissions.MyMenu.Where(x => x.ModuleUrlAddress.Contains(url) && x.IdentificationOptionCode.Equals(optionCode)).ToList();

            var actionEnabled = actionsSecurity.Where(x => x.IdentificationActionCode == Enumerated.IdentificationCodeAction.Enabled).FirstOrDefault();
            var actionVisible = actionsSecurity.Where(x => x.IdentificationActionCode == Enumerated.IdentificationCodeAction.Visible).FirstOrDefault();

            var enabled = actionEnabled != null && actionEnabled.RegistrationStatus.Equals(Enumerated.RegistrationStatus.Active);
            var visible = actionVisible != null && actionVisible.RegistrationStatus.Equals(Enumerated.RegistrationStatus.Active);

            return new ControlPermissions() { Enabled = enabled, Visible = visible };
        }

        /// <summary>
        /// Permite obtener el módulo actual del sistema
        /// </summary>
        /// <returns>Resultado de tipo Menú</returns>
        public static MenuItem GetCurrentModule()
        {
            return GetCurrentModule(null);
        }
        
        /// <summary>
        /// Permite obtener el módulo actual del sistema
        /// </summary>
        /// <param name="padre">Módulo Padre</param>
        /// <returns>Resultado de tipo Menú</returns>
        public static MenuItem GetCurrentModule(string padre)
        {
            var yanbalSession = Yanbal.SFT.Presentation.Web.Source.Session.SessionContext.GetYanbalSession();

            object area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"];
            string areaName = area != null ? area.ToString() : "";
            string controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
            

            string url = areaName + "/" + controllerName;

            var modulo = yanbalSession.Permissions.MyMenu.Where(x => x.ModuleUrlAddress.Equals(url) && (x.ResultId == padre || padre == null)).FirstOrDefault();
            modulo = modulo ?? yanbalSession.Menu.MyMenu.Where(x => x.ResultId == padre).FirstOrDefault();
            MenuItem resultado = null;
            if (modulo != null)
            {
                resultado = new MenuItem()
                {
                    MenuId = modulo.ResultId,
                    ParentMenuId = modulo.ParentResultId,
                    MenuIdentificationCode = modulo.IdentificationModuleCode
                };
                if (!string.IsNullOrEmpty(modulo.ParentResultId))
                {
                    var padreModulo = GetCurrentModule(modulo.ParentResultId);
                    if (padreModulo != null)
                    {
                        if (string.IsNullOrEmpty(padreModulo.ParentMenuId))
                        {
                            resultado.MenuId = modulo.IdentificationModuleCode;
                            resultado.ParentMenuId = padreModulo.MenuIdentificationCode;
                        }
                        else
                        {
                            resultado = padreModulo;
                        }
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Permite validar el acceso a una vista del sistema
        /// </summary>
        /// <returns>Resultado de tipo verdadero o falso</returns>
        public static bool ValidateAccessUrl()
        {
            var pyfSession = Yanbal.SFT.Presentation.Web.Source.Session.SessionContext.GetYanbalSession();

            object area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"];
            string areaName = area != null ? area.ToString() : "";
            string controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
            

            string url = areaName + "/" + controllerName;

            var modulo = pyfSession.Permissions.MyMenu.Where(x => x.ModuleUrlAddress.Contains(url)).FirstOrDefault();
            modulo = modulo ?? pyfSession.Permissions.MyMenu.Where(x => x.SystemPath.Contains(url)).FirstOrDefault();

            bool resultado = (modulo != null || areaName.ToUpper(CultureInfo.InvariantCulture) == Enumerated.ContextCommonAccess.General.ToUpper(CultureInfo.InvariantCulture));

            return resultado;
        }

        /// <summary>
        /// Adaptador de lista de opciones a lista de combos
        /// </summary>
        /// <param name="yanbalSession">Variable de sesión usuario</param>
        /// <returns>Lista con opciones</returns>
        public static List<SelectType> GetListRegistrationStatus(YanbalSession yanbalSession)
        {
            List<SelectType> listSelect = new List<SelectType>();
            IPolicyDomain applicationPolicy = new PolicyDomain();

            var listResult = applicationPolicy.ParameterValueSearch(new ParameterValueRequest()
            {
                BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode,
                Code = Enumerated.Parameter.RegistrationStatus.ToString(),
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            }).Result;

            foreach (var item in listResult.Select(itemResult => itemResult.RecordValueString))
            {
                listSelect.Add(new SelectType() { Id = item["1"], Name = item["2"] });
            }
            return listSelect;
        }

        /// <summary>
        /// Permite adaptar la variable de sesión usuario en una entidad lógica
        /// </summary>
        /// <param name="yanbalSession">Variable de sesión usuario</param>
        /// <returns>Entidad lógica basica de datos</returns>
        public static EnvironmentEL EnvironmentAdapter(YanbalSession yanbalSession)
        {
            var environment = new EnvironmentEL();
            environment.User = yanbalSession.User.Login;
            environment.Terminal = yanbalSession.User.Ip;
            environment.BusinessUnitCode = yanbalSession.BusinessUnit.BusinessUnitCode;
            environment.IntegerFormat = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatIntegerNumber;
            environment.DecimalFormat = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionFormatDecimalNumber;

            environment.ShortDateFormat = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortDateFormat;
            environment.LongDateFormat = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongDateFormat;
            environment.ShortTimeFormat = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionShortTimeFormat;
            environment.LongTimeFormat = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DescriptionLongTimeFormat;

            environment.InformationDecimalFormat = new NumberFormat();
            environment.InformationDecimalFormat.NumberDecimalSeparator = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DecimalSeparator;
            environment.InformationDecimalFormat.NumberGroupSeparator = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.DecimalThousandsSeparator;

            environment.InformationIntegerFormat = new NumberFormat();
            environment.InformationIntegerFormat.NumberGroupSeparator = yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture.IntegerThousandsSeparator;
            return environment;
        }

        /// <summary>
        /// Permite Actualizar la Unidad de Negocio que se usa en Sesión
        /// </summary>
        /// <param name="yanbalSession">Sesión del Sistema</param>
        /// <param name="countrCode">Código del País</param>
        public static void UpdateBusinessUnitSession(YanbalSession yanbalSession, string countrCode)
        {
            IPolicyDomain policyDomain = new PolicyDomain();
            yanbalSession.BusinessUnit = policyDomain.BusinessUnitSearch(new BusinessUnitRequest() { CountryCode = countrCode, GetBusinessUnitConfigurationIndicator = true, RegistrationStatus = Enumerated.RegistrationStatus.Active }).Result.FirstOrDefault();
            if (yanbalSession.BusinessUnit.BusinessUnitConfiguration == null)
            {
                yanbalSession.BusinessUnit.BusinessUnitConfiguration = new BusinessUnitConfigurationEL();
                yanbalSession.BusinessUnit.BusinessUnitConfiguration.Culture = new CultureEL();
            }
            yanbalSession.ListRegistrationStatus = BaseContext.GetListRegistrationStatus(yanbalSession);
            SessionContext.SetYanbalSession(yanbalSession);
        }

        /// <summary>
        /// Permite obtener el valor del recurso asignado al menú.
        /// </summary>
        /// <param name="menu">identificador menu</param>
        /// <returns>valor del recurso</returns>
        public static string GetValueResourceMenu(string menu)
        {
            string valor = null;

            ResourceSet resourceSet = MenuResource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            foreach (DictionaryEntry entry in resourceSet)
            {
                if ((string)entry.Key == menu)
                {
                    valor = (string)entry.Value;
                    break;
                }
            }

            return valor;
        }
    }
}