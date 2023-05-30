using System.Collections.Generic;

namespace Yanbal.SFT.FreightManager.Domain.Wrappers
{
    /// <summary>
    /// Request que representa a los Parámetros que Calcularan el Flete
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FreightRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FreightRequest()
        {
        }

        /// <summary>
        /// Monto
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Monto en tipo String
        /// </summary>
        public string AmountString { get; set; }

        /// <summary>
        /// Pais
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Zona
        /// </summary>
        public string Zone { get; set; }

        /// <summary>
        /// Tipo de Pedido
        /// </summary>
        public string TypeOrder { get; set; }

        /// <summary>
        /// Año de Campaña
        /// </summary>
        public string YearCampaign { get; set; }

        /// <summary>
        /// Número de Campaña
        /// </summary>
        public string NumberCampaign { get; set; }

        /// <summary>
        /// Número de Semana
        /// </summary>
        public string NumberWeek { get; set; }

        /// <summary>
        /// Tipo de Envio
        /// </summary>
        public string SendType { get; set; }

        /// <summary>
        /// Campo SendTypeDescripcion
        /// </summary>
        public string SendTypeDescripcion { get; set; }

        /// <summary>
        /// Parámetros Libres
        /// </summary>
        public List<CollectorParameterRequest> CollectorParameter { get; set; }

        /// <summary>
        /// Indica si es un request para el servicio de ordenes o no.
        /// </summary>
        public bool IsForService { get; set; }
    }
}
