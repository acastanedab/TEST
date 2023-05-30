using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Language
{
    /// <summary>
    /// Interfaz que Define la Entidad de Idioma
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140815 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface ILanguage : IDisposable
    {
        /// <summary>
        /// LanguageSearch
        /// </summary>
        List<LanguageEN> LanguageSearch(string languageCode, string name, string registrationStatus);
    }
}
