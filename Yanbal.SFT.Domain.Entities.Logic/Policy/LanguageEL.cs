using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad Lógica que representa el Idioma
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140731 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class LanguageEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LanguageEL()
        {
        }

        /// <summary>
        /// Codigo de Idioma
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
    }
}
