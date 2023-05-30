using Yanbal.SFT.FreightManagement.Common.Response;
using Yanbal.SFT.Domain.Entities.Logic.Freight;
using Yanbal.SFT.PolicyManager.Domain.Wrappers;
using Yanbal.SFT.FreightManager.Domain.Wrappers;

namespace Yanbal.SFT.FreightManager.Domain
{
    /// <summary>
    /// Interfaz de Define la Entidad de Negocio de Fletes
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IFreightDomain
    {
        /// <summary>
        /// CalculateFreight
        /// </summary>
        ProcessResult<FreightEL> CalculateFreight(FreightRequest request);
    }
}
