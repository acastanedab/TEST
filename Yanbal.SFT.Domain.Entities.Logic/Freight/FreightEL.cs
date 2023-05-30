
namespace Yanbal.SFT.Domain.Entities.Logic.Freight
{
    /// <summary>
    /// Entidad de Lógica que representa al Flete
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140822 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FreightEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FreightEL()
        {
        }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int CombinationCode { get; set; }

        /// <summary>
        /// Monto del Flete 
        /// </summary>
        public decimal AmountFreight { get; set; }
    }
}
