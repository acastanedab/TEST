using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.TimeZone
{
    /// <summary>
    /// Interfaz que Define la Entidad de Zona Horaria
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140922 <br />
    /// Modificación:           <br />
    /// </remarks>
    public interface ITimeZone : IDisposable
    {
        /// <summary>
        /// TimeZoneSearch
        /// </summary>
        List<TimeZoneEN> TimeZoneSearch(int? timeZoneCode, 
                                        short? hourUtc, 
                                        short? minuteUtc, 
                                        string description, 
                                        string registrationStatus,
                                        int? pageNo,
                                        int? pageSize);
    }
}
