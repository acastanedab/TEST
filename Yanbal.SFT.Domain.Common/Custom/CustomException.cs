using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common;

namespace Yanbal.SFT.FreightManagement.Common.Custom
{
    /// <summary>
    /// Clase para el control de excepciones
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140810 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class CustomException : Exception
    {
        /// <summary>
        /// Código de Error
        /// </summary>
        public string CodeError { get; set; }

        /// <summary>
        /// Descripción de Error
        /// </summary>
        public string DescriptionError { get; set; }

        /// <summary>
        /// Constructor de la Clase basada en el Código de Error, Mensaje y Excepción
        /// </summary>
        /// <param name="codeError">Código de Error</param>
        /// <param name="message">Mensaje Relacionado al Error</param>
        /// <param name="innerException">Exepción</param>
        public CustomException(string codeError, string message, Exception innerException)
            : base(message, innerException)
        {
            this.CodeError = codeError;
            this.DescriptionError = message;
        }

        /// <summary>
        /// Constructor de la Clase basada en el Código de Error y Mensaje
        /// </summary>
        /// <param name="codeError">Código de Error</param>
        /// <param name="message">Mensaje Relacionado al Error</param>
        public CustomException(string codeError, string message)
            : base(message)
        {
            this.CodeError = codeError;
            this.DescriptionError = message;
        }

        /// <summary>
        /// Constructor de la Clase basada en el Mensaje
        /// </summary>
        /// <param name="message">Mensaje Relacionado al Error</param>
        public CustomException(string message)
            : base(message)
        {
            this.CodeError = Enumerated.ErrorCodeBase.UnExpectedError;
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public CustomException()
        {
            this.CodeError = Enumerated.ErrorCodeBase.UnExpectedError;
            this.DescriptionError = Enumerated.ErrorDescriptionBase.UnExpectedError;
        }
    }
}
