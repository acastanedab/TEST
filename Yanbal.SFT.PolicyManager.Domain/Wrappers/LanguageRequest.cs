using System;

namespace Yanbal.SFT.PolicyManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa el Idioma
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class LanguageRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LanguageRequest()
        {
        }

        /// <summary>
        /// Codigo de País
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }
    }
}
