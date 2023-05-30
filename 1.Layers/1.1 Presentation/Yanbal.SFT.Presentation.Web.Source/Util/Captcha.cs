using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common;

namespace Yanbal.SFT.Presentation.Web.Source.Util
{
    /// <summary>
    /// Clase para obtener los valores de la Api reCaptcha de Google
    /// </summary>
    public class Captcha
    {
        /// <summary>
        /// Indica si esta solicitud era un token reCAPTCHA válido.
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// Marca de tiempo de la carga de desafío (formato ISO aaaa-MM-dd'T'HH: mm: ssZZ)
        /// </summary>
        public string challenge_ts { get; set; }

        /// <summary>
        /// El nombre de host del sitio donde se resolvió el reCAPTCHA
        /// </summary>
        public string hostname { get; set; }

        /// <summary>
        /// El puntaje obtenido para la solicitud (0.0 - 1.0)
        /// </summary>
        public decimal score { get; set; }

        /// <summary>
        /// Nombre de la acción para esta solicitud (importante para verificar)
        /// </summary>
        public string action { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string error_codes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string controllerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string clavePublica { get; set; }

    }


    /// <summary>
    /// Clase para procesar la respuesta json de la Api reCaptcha de Google
    /// </summary>
    public static class CaptchaResponse
    {
        /// <summary>
        /// Obtiene los valores obtenidos de la Api reCaptcha de Google
        /// </summary>
        /// <param name="token"></param>
        /// <param name="version"></param>
        /// <param name="codigoUnidadNegocio"></param>
        /// <returns></returns>
        public static Captcha GetCaptcha(string token, string version, int codigoUnidadNegocio)
        {
            Captcha captcha = null;
            string secretKey = string.Empty;
            string apiUrl = string.Empty;
            string requestUri = string.Empty;
            HttpWebRequest request = null;

            switch (version)
            {
                case Enumerated.PropiedadesCaptcha.SegundaVersion:
                    secretKey = KeysGooglePolicy.ObtenerClavePrivada(version, codigoUnidadNegocio);
                    apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
                    requestUri = string.Format(apiUrl, secretKey, token);
                    request = (HttpWebRequest)WebRequest.Create(requestUri);

                    using (WebResponse response = request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        captcha = JsonConvert.DeserializeObject<Captcha>(json);
                    }
                    break;
                case Enumerated.PropiedadesCaptcha.TerceraVersion:
                    secretKey = KeysGooglePolicy.ObtenerClavePrivada(version, codigoUnidadNegocio);
                    apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";

                    requestUri = string.Format(apiUrl, secretKey, token);
                    request = (HttpWebRequest)WebRequest.Create(requestUri);

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        captcha = JsonConvert.DeserializeObject<Captcha>(json);
                    }
                    break;
            }

            return captcha;
        }
    }
}
