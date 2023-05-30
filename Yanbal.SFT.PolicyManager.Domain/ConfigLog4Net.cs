using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common;
using Yanbal.SFT.FreightManagement.Common.Models;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;

namespace Yanbal.SFT.PolicyManager.Domain
{
    public static class ConfigLog4Net
    {
        /// <summary>
        /// Metodo que obtiene la configuración de log por el identificador del componente.
        /// </summary>
        /// <param name="parameterValueRequest"></param>
        /// <returns></returns>
        public static Log4NetConfig GetConfigByComponent(ParameterValueRequest parameterValueRequest)
        {
            IPolicyDomain policyDomain = new PolicyDomain();
            var parametroValores = policyDomain.ListarParametroValorLog4Net(new ParameterValueRequest()
            {
                BusinessUnitCode = parameterValueRequest.BusinessUnitCode,
                CountryCode = string.IsNullOrWhiteSpace(parameterValueRequest.CountryCode) ? Enumerated.UnidadNegocio.NombreUnidadNegocio : parameterValueRequest.CountryCode,
                Code = Enumerated.CodeParameter.Log4NetConfig,
                CodeValue = parameterValueRequest.Component
            });

            Log4NetConfig log4NetConfig = null;
            if (parametroValores != null && parametroValores.Any())
            {
                log4NetConfig = new Log4NetConfig();
                var ListIndicadoresLog4Net = parametroValores.Where(x => x.Correlativo < 6).ToList();
                foreach (var item in ListIndicadoresLog4Net)
                {
                    if (item.Correlativo == 1)
                    {
                        log4NetConfig.Componente = item.Valor;
                    }
                    else if (item.Correlativo == 2)
                    {
                        log4NetConfig.InternalDebug = Convert.ToBoolean(item.Valor);
                    }
                    else if (item.Correlativo == 3)
                    {
                        log4NetConfig.Info = Convert.ToBoolean(item.Valor);
                    }
                    else if (item.Correlativo == 4)
                    {
                        log4NetConfig.Error = Convert.ToBoolean(item.Valor);
                    }
                    else if (item.Correlativo == 5)
                    {
                        log4NetConfig.Debug = Convert.ToBoolean(item.Valor);
                    }
                }

                var ListRutasLog = parametroValores.Where(x => x.Correlativo > 5).ToList();
                var nodo = 0;
                foreach (var item in ListRutasLog)
                {
                    nodo += 1;
                    log4NetConfig.RutasArchivoLog.Add(new RutaNodo() { IdNodo = nodo, RutaArchivoLog = item.Valor });
                }
            }
            return log4NetConfig;
        }
    }
}
