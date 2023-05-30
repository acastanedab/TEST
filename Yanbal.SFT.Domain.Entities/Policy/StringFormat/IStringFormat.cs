using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.StringFormat
{
    /// <summary>
    /// Interfaz que Define la Entidad de Formato Cadena
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IStringFormat : IDisposable
    {
        /// <summary>
        /// StringFormatSearch
        /// </summary>
        List<StringFormatEN> StringFormatSearch(int? stringFormatCode, string format, string formatType, bool? longFormat, string registrationstatus);
    }
}
