using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Logging
{
    /// <summary>
    /// Singletin Configuración Log4Net
    /// </summary>
    public class SingletonConfigurator
    {
        private SingletonConfigurator()
        {
        }
        private static SingletonConfigurator instanceXML = null;

        /// <summary>
        /// Inicializar Configuración
        /// </summary>
        /// <returns></returns>
        public static SingletonConfigurator InicializarConfiguracion()
        {
            if (instanceXML == null)
            {
                log4net.Config.XmlConfigurator.Configure();
                instanceXML = new SingletonConfigurator();
            }
            return instanceXML;
        }
    }
}
