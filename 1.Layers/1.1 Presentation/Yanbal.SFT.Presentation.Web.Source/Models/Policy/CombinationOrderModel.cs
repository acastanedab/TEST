using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa el Orden de Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140910 <br />
    /// Modificación:
    /// </remarks>
    public class CombinationOrderModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationOrderModel()
        {
        }

        /// <summary>
        /// Código de Orden de Combinación
        /// </summary>
        public int OrderCodeCombination { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodeParameter { get; set; }

        /// <summary>
        /// Descripción del Parámetro
        /// </summary>
        public string DescriptionParameter { get; set; }

        /// <summary>
        /// Orden del Parámetro
        /// </summary>
        public byte Order { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Lista de Parámetros
        /// </summary>
        public List<SelectType> ListParameter { get; set; }

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
