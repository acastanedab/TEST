using System;
namespace Yanbal.SFT.Proxies.Application
{
    /// <summary>
    /// Manejador de tipo de Error
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140905 <br />
    /// Modificación: 
    /// </remarks>
    [Serializable]
    public class ErrorManagerType
    {
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        public ErrorManagerType() 
        {
            this.ErrorNumber = string.Empty;
            this.Description = string.Empty;
            this.Severity = 0;
        }

        /// <summary>
        /// Número de Error
        /// </summary>
        public string ErrorNumber { get; set; }

        /// <summary>
        /// Descripción del Error
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Severidad del Error
        /// </summary>
        public int Severity { get; set; }
    }
}
