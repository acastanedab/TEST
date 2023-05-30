using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa el párametro
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140717 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterModel()
        {
        }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodeParamater { get; set; }

        /// <summary>
        /// Código de Parámetro Manual
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Solo lectura
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// Añadir valor permitido
        /// </summary>
        public bool AllowAddValue { get; set; }
        /// <summary>
        /// Añadir valor modificado
        /// </summary>
        public bool AllowModifyValue { get; set; }
        /// <summary>
        /// Indicador si es un Parámetro de Sistema
        /// </summary>
        public bool SystemIndicator { get; set; }
        /// <summary>
        /// Nombre de parametro
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// Descripción de parametro
        /// </summary>
        public string ParameterDescription { get; set; }
        /// <summary>
        /// Descripción de tipo párametro
        /// </summary>
        public string DescriptionParameterType { get; set; }
        /// <summary>
        /// Descripción de código tipo párametro
        /// </summary>
        public string CodeParameterType { get; set; }
        /// <summary>
        /// Estado de registro
        /// </summary>
        public string RegistrationStatus { get; set; }
        /// <summary>
        /// Lista Tipo Párametro
        /// </summary>
        public List<SelectType> ListParameterType { get; set; }
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
        /// Botón visualizar
        /// </summary>
        public ButtonControl Visualize { get; set; }
        /// <summary>
        /// Control de imagen Editar
        /// </summary>
        public ImageControl Edit { get; set; }
        /// <summary>
        /// Control de imagen sección
        /// </summary>
        public ImageControl GoSection { get; set; }
        /// <summary>
        /// Lista párametro sección
        /// </summary>
        public IEnumerable<object> ListParameterSection { get; set; }
    }
}