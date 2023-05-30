using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.PolicyManager.Domain;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.Presentation.Web.Source.Common;

namespace Yanbal.SFT.Presentation.Web.Source.Util
{
    /// <summary>
    /// KeysGooglePolicy
    /// </summary>
    public static class KeysGooglePolicy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ObtenerClavePublica(string versionCapcha, int codigoUnidadNegocio)
        {
            var policyDomain = new PolicyDomain();
            var parametroValRequest = new ParameterValueRequest()
            {
                BusinessUnitCode = codigoUnidadNegocio,
                Code = Enumerated.Parameter.ClavesReCaptcha,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            };
            string valor = string.Empty;
            var parametroValores = policyDomain.ParameterValueSearch(parametroValRequest).Result;
            if (parametroValores.Any())
            {
                var valores = parametroValores.Find(x => x.RecordValueString["1"] == versionCapcha);
                valor = valores.RecordValueString[Enumerated.KeysCaptcha.KeyClavePublica];
            }

            return valor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionCapcha"></param>
        /// <param name="codigoUnidadNegocio"></param>
        /// <returns></returns>
        public static string ObtenerClavePrivada(string versionCapcha, int codigoUnidadNegocio)
        {
            var policyDomain = new PolicyDomain();
            var parametroValRequest = new ParameterValueRequest()
            {
                BusinessUnitCode = codigoUnidadNegocio,
                Code = Enumerated.Parameter.ClavesReCaptcha,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            };
            string valor = string.Empty;
            var parametroValores = policyDomain.ParameterValueSearch(parametroValRequest).Result;
            if (parametroValores.Any())
            {
                var valores = parametroValores.Find(x => x.RecordValueString["1"] == versionCapcha);
                valor = valores.RecordValueString[Enumerated.KeysCaptcha.KeyClavePrivada];
            }

            return valor;
        }
        /// <summary>
        /// Permite saber si esta activadO el CAPTCHA. 
        /// </summary>
        /// <returns>Devuelve True si la version del Captcha esta activado.</returns>
        public static bool VersionCaptchaEsActivo(string versionCapcha)
        {
            var policyDomain = new PolicyDomain();
            BusinessUnitEL unidadNegocio = policyDomain.BusinessUnitSearch(new BusinessUnitRequest()
            {
                CountryCode = SystemConfiguration.BusinessUnity,
                RegistrationStatus = Enumerated.RegistrationStatus.Active,
                GetBusinessUnitConfigurationIndicator = true
            }).Result.FirstOrDefault();

            var parametroValRequest = new ParameterValueRequest()
            {
                BusinessUnitCode = unidadNegocio.BusinessUnitCode,
                Code = Enumerated.Parameter.ClavesReCaptcha,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            };
            bool activo = false;
            var parametroValores = policyDomain.ParameterValueSearch(parametroValRequest).Result;
            if (parametroValores.Any())
            {
                var valores = parametroValores.Find(x => x.RecordValueString["1"] == versionCapcha);
                activo = valores != null;
            }
            return activo;
        }

        /// <summary>
        /// Permite saber si esta activadO el CAPTCHA. 
        /// </summary>
        /// <param name="versionCapcha"></param>
        /// <param name="codigoUnidadNegocio"></param>
        /// <returns>Devuelve True si la version del Captcha esta activado.</returns>
        public static bool VersionCaptchaEsActivo(string versionCapcha, int codigoUnidadNegocio)
        {
            var policyDomain = new PolicyDomain();
            var parametroValRequest = new ParameterValueRequest()
            {
                BusinessUnitCode = codigoUnidadNegocio,
                Code = Enumerated.Parameter.ClavesReCaptcha,
                RegistrationStatus = Enumerated.RegistrationStatus.Active
            };
            bool activo = false;
            var parametroValores = policyDomain.ParameterValueSearch(parametroValRequest).Result;
            if (parametroValores.Any())
            {
                var valores = parametroValores.Find(x => x.RecordValueString["1"] == versionCapcha);
                activo = valores != null;
            }
            return activo;
        }
    }
}
