using System.Web;
using System;
using Yanbal.SFT.Presentation.Web.Source.Common;

namespace Yanbal.SFT.Presentation.Web.Source.Session
{
    /// <summary>
    /// Contexto que maneja las Sesiones
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140828 <br />
    /// Modificación:
    /// </remarks>
    public sealed class SessionContext
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        protected SessionContext()
        {
        }

        /// <summary>
        /// Permite obtener Sesión actual
        /// </summary>
        /// <param name="sessionId">Código de la Sesión</param>
        /// <returns>Indicador de Sesión</returns>
        public static Object Get(string sessionId)
        {
            var result = HttpContext.Current.Session[sessionId];

            return result;
        }

        /// <summary>
        /// Permite agregar un atributo a la Sesión
        /// </summary>
        /// <param name="sessionId">Código de Sesión</param>
        /// <param name="value">Valor</param>
        public static void Add(string sessionId, object value)
        {
            if (HttpContext.Current != null)
            {
                Remove(sessionId);
                HttpContext.Current.Session.Add(sessionId, value);
            }
        }

        /// <summary>
        /// Permite eliminar un atributo de la Sesión
        /// </summary>
        /// <param name="sessionId">Código de Sesión</param>
        public static void Remove(string sessionId)
        {
            HttpContext.Current.Session.Remove(sessionId);
        }

        /// <summary>
        /// Permite borrar todos los atributos de la Sesión
        /// </summary>
        public static void Clear()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        /// <summary>
        /// Permite obtener la Sesión
        /// </summary>
        /// <returns>Objeto mantenido en Sesión</returns>
        public static YanbalSession GetYanbalSession()
        {
            YanbalSession session = (YanbalSession)Get(SystemConfiguration.PyfSession);
            return session;

        }

        /// <summary>
        /// Permite establecer la Sesión
        /// </summary>
        /// <param name="yanbalSession">Objeto mantenido en Sesión</param>
        public static void SetYanbalSession(YanbalSession yanbalSession)
        {
            Add(SystemConfiguration.PyfSession, yanbalSession);
        }
    }
}
