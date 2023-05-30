using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Province
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Provincia
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IProvince : IDisposable
    {
        /// <summary>
        /// ProvinceSearch
        /// </summary>
        List<ProvinceEN> ProvinceSearch(string codePais, string codeProvince);
    }
}
