using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.District
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IDistrict : IDisposable
    {
        /// <summary>
        /// DistrictSearch
        /// </summary>
        List<DistrictEN> DistrictSearch(string cityCode, string districtCode);
    }
}
