namespace Yanbal.SFT.Presentation.Web.Source.Models.Account
{
    /// <summary>
    /// Modelo que representa el login
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140715 <br />
    /// Modificación: 
    /// </remarks>
    public class LogOnModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LogOnModel()
        {
        }

        /// <summary>
        /// Usuario
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Clave
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Validación de usuario
        /// </summary>
        public int ValidationUser { get; set; }
        /// <summary>
        /// Token que devuelve google reCAPTCHA.
        /// </summary>
        public string token { get; set; }
        /// <summary>
		/// Idioma Inicial
		/// </summary>
		public string IdiomaInicial { get; set; }
    }

    /// <summary>
    /// Clase de login de acceso
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140715 <br />
    /// Modificación: 
    /// </remarks>
    public class LoginAccesResponseAplication
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LoginAccesResponseAplication()
        {
        }

        /// <summary>
        /// Código de error
        /// </summary>
        public string CodeError { get; set; }
        /// <summary>
        /// Descripción de error
        /// </summary>
        public string DescriptionError { get; set; }
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Código unidad de  negocio
        /// </summary>
        public string CodigoUnidadNegocio { get; set; }
    }
}