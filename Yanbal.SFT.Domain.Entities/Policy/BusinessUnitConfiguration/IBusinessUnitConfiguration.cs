using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.BusinessUnitConfiguration
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Configuración de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IBusinessUnitConfiguration : IDisposable
    {
        /// <summary>
        /// BusinessUnitConfigurationSearch
        /// </summary>
        List<BusinessUnitConfigurationEN> BusinessUnitConfigurationSearch(int? businessUnitCode, int? businessUnitCodeConfiguration, int? businessUnitCodeContext, string cultureCode, string registrationStatus, int? pageNo, int? pageSize);
        /// <summary>
        /// BusinessUnitConfigurationRegister
        /// </summary>
        int BusinessUnitConfigurationRegister(BusinessUnitConfigurationEN businessUnitConfiguration);
        /// <summary>
        /// BusinessUnitConfigurationUpdate
        /// </summary>
        int BusinessUnitConfigurationUpdate(BusinessUnitConfigurationEN businessUnitConfiguration);
        /// <summary>
        /// GetLogoBusinessUnitConfiguration
        /// </summary>
        List<BusinessUnitConfigurationEN> GetLogoBusinessUnitConfiguration(int businessUnitCodeConfiguration);
    }
}
