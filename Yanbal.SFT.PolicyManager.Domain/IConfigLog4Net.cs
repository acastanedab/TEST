using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Models;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;

namespace Yanbal.SFT.PolicyManager.Domain
{
    /// <summary>
    /// interface
    /// </summary>
    public interface IConfigLog4Net
    {
        /// <summary>
        /// Metodo que obtiene la configuración de log por el identificador del componente.
        /// </summary>
        /// <param name="parameterValueRequest"></param>
        /// <returns></returns>
        Log4NetConfig GetConfigByComponent(ParameterValueRequest parameterValueRequest);
    }
}
