using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.City
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Ciudad
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ICity : IDisposable
    {
        /// <summary>
        /// CitySearch
        /// </summary>
        List<CityEN> CitySearch(string provinceCode, string cityCode);
    }
}
