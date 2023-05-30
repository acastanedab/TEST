using System;
namespace Yanbal.SFT.Presentation.Web.Source.Session
{
    /// <summary>
    /// Clase que representa a Usuario
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140715 <br />
    /// Modificación: 
    /// </remarks>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Login de Usuario
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Nombre del Ordenador
        /// </summary>
        public string Host
        {
            get { return System.Net.Dns.GetHostName(); }
        }

        /// <summary>
        /// Dirección IP del Ordenador
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Indicador de Usuario Corportivo
        /// </summary>
        public bool CorporateIndicator { get; set; }
    }
}
