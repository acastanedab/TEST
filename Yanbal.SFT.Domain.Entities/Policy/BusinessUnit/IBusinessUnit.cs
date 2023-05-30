using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.BusinessUnit
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IBusinessUnit : IDisposable
    {
        /// <summary>
        /// BusinessUnitSearch
        /// </summary>
        List<BusinessUnitEN> BusinessUnitSearch(int? businessUnitCode, int? businessUnitCodeContext, string name, string businessUnitName, string countryCode, string registrationStatus, int? pageNo, int? pageSize);
        /// <summary>
        /// BusinessUnitRegister
        /// </summary>
        int BusinessUnitRegister(BusinessUnitEN businessUnit);
        /// <summary>
        /// BusinessUnitUpdate
        /// </summary>
        int BusinessUnitUpdate(BusinessUnitEN businessUnit);
    }
}
