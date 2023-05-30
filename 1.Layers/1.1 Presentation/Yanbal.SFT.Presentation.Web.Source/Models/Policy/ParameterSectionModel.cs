using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa el párametro de sección
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140721 <br />
    /// Modificación:
    /// </remarks>
    public class ParameterSectionModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterSectionModel()
        {
        }

        /// <summary>
        /// Código de Párametro
        /// </summary>
        public int CodeParameter { get; set; }

        /// <summary>
        /// Código de Párametro Manual
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Código de sección
        /// </summary>
        public int CodeSection { get; set; }
        /// <summary>
        /// Nombre de Sección
        /// </summary>
        public string NameSection { get; set; }
        /// <summary>
        /// Nombre de párametro
        /// </summary>
        public string NameParameter { get; set; }
        /// <summary>
        /// Tipo de párametro
        /// </summary>
        public string ParamterType { get; set; }
        /// <summary>
        /// Descripción de tipo de párametro
        /// </summary>
        public string DescriptionParamterType { get; set; }    
        /// <summary>
        /// Tipo de sección
        /// </summary>
        public string SectionType { get; set; }
        /// <summary>
        /// Idicador de solo lectura
        /// </summary>
        public bool ReadOnlyIndicator { get; set; }
        /// <summary>
        /// Idicador de Requerido
        /// </summary>
        public bool RequiredIndicator { get; set; }
        /// <summary>
        /// Indicador de creación
        /// </summary>
        public bool CreationIndicator { get; set; }
        /// <summary>
        /// Estado de registro
        /// </summary>
        public string RegistrationStatus { get; set; }
        /// <summary>
        /// Descripción de estado de registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }
        
        /// <summary>
        /// Lista de tipo de sección
        /// </summary>
        public List<SelectType> ListSectionType { get; set; }
        /// <summary>
        /// Botón de busqueda
        /// </summary>
        public ButtonControl Search { get; set; }
        /// <summary>
        /// Botón  crear
        /// </summary>
        public ButtonControl Create { get; set; }
        /// <summary>
        /// Botón cancelar
        /// </summary>
        public ButtonControl Cancel { get; set; }
        /// <summary>
        /// Botón guardar
        /// </summary>
        public ButtonControl Save { get; set; }
        /// <summary>
        /// Boton Visualizar
        /// </summary>
        public ButtonControl Visualize { get; set; }
        /// <summary>
        ///  Boton Imagen Editar
        /// </summary>
        public ImageControl Edit { get; set; }
    }
}