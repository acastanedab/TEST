using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Country
{
    /// <summary>
    /// Interfaz que Define la Entidad de País
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ICountry : IDisposable
    {
        /// <summary>
        /// CountrySearch
        /// </summary>
        List<CountryEN> CountrySearch(string countryCode, string countryZoneCode);
    }
}
