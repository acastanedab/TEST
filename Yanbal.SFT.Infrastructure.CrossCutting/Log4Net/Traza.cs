using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Log4Net
{
    /// <summary>
    /// Traza para los campos mapeados para el log del servicio web
    /// </summary>
    public class Traza
    {
        /// <summary>
        /// Trama request
        /// </summary>
        public string TramaRequest { get; set; }
        /// <summary>
        /// trama response
        /// </summary>
        public string TramaResponse { get; set; }
        /// <summary>
        /// codigo de Pais
        /// </summary>
        public string CodigoPais { get; set; }
        /// <summary>
        /// Componente del servicio web
        /// </summary>
        public string Componente { get; set; }
        /// <summary>
        /// Transaccion del servicio enviado de soap
        /// </summary>
        public string IdTransaccion { get; set; }
        /// <summary>
        /// Cliente enviado del servicio web
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// Metodo del servicio web
        /// </summary>
        public string Metodo { get; set; }
        /// <summary>
        /// Clase del servicio web
        /// </summary>
        public string Clase { get; set; }
        /// <summary>
        /// Código Consultora Beneficiaria
        /// </summary>
        public string codigo_interno { get; set; }
        /// <summary>
        /// Código Identificador
        /// </summary>
        public string codigo_general { get; set; }
        /// <summary>
        /// Código Identificador Nodo
        /// </summary>
        public string NodoCluster { get; set; }
    }
}
