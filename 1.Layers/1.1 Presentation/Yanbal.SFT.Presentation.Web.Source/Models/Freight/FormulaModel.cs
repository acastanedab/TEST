using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Freight
{
    /// <summary>
    /// Modelo que representa la Fórmula
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140911 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class FormulaModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FormulaModel()
        {
        }

        /// <summary>
        /// Código de Fórmula
        /// </summary>
        public int FormulaCode { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int ParameterCode { get; set; }

        /// <summary>
        /// Descripción de Parámetro
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
        public string FactorString { get; set; }

        /// <summary>
        /// Tipo de Factor
        /// </summary> 
        public string FactorType { get; set; }

        /// <summary>
        /// Tipo de Factor
        /// </summary> 
        public string ValueSendType { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Botón Buscar
        /// </summary>
        public ButtonControl Search { get; set; }

        /// <summary>
        /// Botón Crear
        /// </summary>
        public ButtonControl Create { get; set; }

        /// <summary>
        /// Botón Cancelar
        /// </summary>
        public ButtonControl Cancel { get; set; }

        /// <summary>
        /// Botón Guardar
        /// </summary>
        public ButtonControl Save { get; set; }

        /// <summary>
        /// Botón Visualizar
        /// </summary>
        public ButtonControl Visualize { get; set; }

        /// <summary>
        /// Control de imagen Editar
        /// </summary>
        public ImageControl Edit { get; set; }

        /// <summary>
        /// Lista de Parámetros
        /// </summary>
        public List<SelectType> ListParameter { get; set; }

        /// <summary>
        /// Lista de Valores de Parámetros
        /// </summary>
        public List<SelectType> ListParameterValue { get; set; }

        /// <summary>
        /// Lista de Parámetros
        /// </summary>
        public List<SelectType> ListSendType { get; set; }
    }
}
