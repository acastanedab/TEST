using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.General
{
    /// <summary>
    /// Interface que representa la Fecha de la Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140710 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IDateTimeBusinessUnit : IDisposable
    {
        /// <summary>
        /// GetDateTimeBusinessUnit
        /// </summary>
        DateTimeBusinessUnitEN GetDateTimeBusinessUnit(int? businessUnitCode, string countryCode);
    }
}