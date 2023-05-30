using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Freight
{
    /// <summary>
    /// Modelo que representa el Orden de Formulas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación:
    /// </remarks>
    public class FormulaOrderModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FormulaOrderModel()
        {
        }

        /// <summary>
        /// Código de Fórmula
        /// </summary>
        public int FormulaCode { get; set; }

        /// <summary>
        /// Orden de la Formula
        /// </summary>
        public byte? Order { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Descripción de Formula
        /// </summary>
        public string FormulaDescription { get; set; }        

        /// <summary>
        /// Lista de Formula
        /// </summary>
        public List<SelectType> ListFormula { get; set; }

        /// <summary>
        /// Botón Añadir
        /// </summary>
        public ButtonControl Add { get; set; }

        /// <summary>
        /// Botón Cancelar
        /// </summary>
        public ButtonControl Cancel { get; set; }

        /// <summary>
        /// Botón Guardar
        /// </summary>
        public ButtonControl Save { get; set; }

        /// <summary>
        /// Control de imagen Editar
        /// </summary>
        public ImageControl Edit { get; set; }
    }
}
