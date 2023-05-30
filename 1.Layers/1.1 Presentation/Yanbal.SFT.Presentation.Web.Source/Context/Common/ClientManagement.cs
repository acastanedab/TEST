using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Context.Common
{
    /// <summary>
    /// Clase estatica que administra la informacion del Host Cliente
    /// </summary> 
    /// <remarks>
    /// Creación: 	GMD 20140920 <br />
    /// Modificación: 	 <br />
    /// </remarks>
    public static class ClientManagement
    {
        /// <summary>
        /// Permite obtener el numero ip del cliente que realiza la peticion
        /// </summary>
        /// <returns>Numero Ip</returns>
        public static string GetIpNumber()
        {
            string visitorsIpAddr = string.Empty;

            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                visitorsIpAddr = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (System.Web.HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                visitorsIpAddr = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return visitorsIpAddr;
        }
    }
}
