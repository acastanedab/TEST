using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad de Lógica que representa la Fórmula
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140911 <br />
    /// Modificación: 
    /// </remarks>
    public class FormulaEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FormulaEL()
        {
        }

        /// <summary>
        /// Código de Fórmula
        /// </summary>
        public int FormulaCode { get; set; }
        
        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int ParameterCode { get; set; }

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }        

        /// <summary>
        /// Descripción del Parámetro
        /// </summary>
        public string ParameterDescription { get; set; }

        /// <summary>
        /// Valor de Parámetro
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Descripción del Valor de Parámetro
        /// </summary>
        public string ValueDescription { get; set; }

        /// <summary>
        /// Operación
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Factor
        /// </summary>
        public decimal Factor { get; set; }

        /// <summary>
        /// Factor con el formato correspondiente a la Unidad de Negocio
        /// </summary>
        public string FactorString { get; set; }

        /// <summary>
        /// Tipo de Factor
        /// </summary>
        public string FactorType { get; set; }

        /// <summary>
        /// valor de tipo de envio
        /// </summary>
        public string ValueSendType { get; set; }

        /// <summary>
        /// valor de tipo de envio
        /// </summary>
        public string DescriptionSendType { get; set; }

        /// <summary>
        /// Orden de Ejecución de la Formula
        /// </summary>
        public byte? Order { get; set; }        
    }
}
