using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Culture
{
    /// <summary>
    /// Interfaz que Define la Entidad de Cultura
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ICulture : IDisposable
    {
        /// <summary>
        /// CultureSearch
        /// </summary>
        List<CultureEN> CultureSearch(  int? businessUnitCode,
                                        string culturaCode,
                                        string languageCode,
                                        string countryCode,
                                        int? codeShortDateFormat,
                                        int? codeLongDateFormat,
                                        int? codeShortTimeFormat,
                                        int? codeLongTimeFormat,
                                        int? codeFormatIntegerNumber,
                                        int? codeFormatDecimalNumber,
                                        short? upperLimitYear,
                                        string registrationStatus,
                                        int? pageNo,
                                        int? pageSize);
        /// <summary>
        /// CultureRegister
        /// </summary>
        int CultureRegister(CultureEN culture);
        /// <summary>
        /// CultureUpdate
        /// </summary>
        int CultureUpdate(CultureEN culture);
    }
}
