
namespace Yanbal.SFT.FreightManager.Domain.Wrappers
{
    /// <summary>
    /// Entidad de Lógica que representa al Flete
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140822 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class CollectorParameterRequest
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CollectorParameterRequest()
        {
        }

        /// <summary>
        /// Id de Collector
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Valor de Collector
        /// </summary>
        public string Value { get; set; }
    }
}
