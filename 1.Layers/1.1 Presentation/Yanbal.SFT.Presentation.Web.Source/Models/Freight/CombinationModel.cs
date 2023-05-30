using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Freight
{
    /// <summary>
    /// Modelo que representa la Combinación
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140905 <br />
    /// Modificación:
    /// </remarks>
    public class CombinationModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public CombinationModel()
        {
        }

        /// <summary>
        /// Código de Combinación
        /// </summary>
        public int CodeCombination { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Importe de Flete
        /// </summary> 
        public string AmountFreightString { get; set; }

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
        /// Botón Ir a Vista Combinación de Parámetros
        /// </summary>
        public ButtonControl Next { get; set; }

        /// <summary>
        /// Botón Añadir
        /// </summary>
        public ButtonControl Add { get; set; }

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
        /// Control de imagen Eliminar
        /// </summary>
        public ImageControl Delete { get; set; }

        /// <summary>
        /// Control de imagen Ir a Parámetros de Combinación
        /// </summary>
        public ImageControl Parameter { get; set; }

        /// <summary>
        /// Lista de Parámetros
        /// </summary>
        public List<CombinationOrderEL> ListParameter { get; set; }

        /// <summary>
        /// Lista de Valores de Parámetros
        /// </summary>
        public List<SelectType> ListParameterValue { get; set; }

        /// <summary>
        /// Lista de Códigos de Parámetros
        /// </summary>
        public List<int> ListCodeParameter { get; set; }

        /// <summary>
        /// Lista de Códigos de Valores de Parámetros
        /// </summary>
        public List<SelectType> ListCodeParameterValue { get; set; }

        /// <summary>
        /// Lista de Códigos de Valores de Parámetros
        /// </summary>
        public List<ParameterCombinationEL> ListParameterCombination { get; set; }
    }
}
