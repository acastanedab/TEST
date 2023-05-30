using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa el párametro valor
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140717 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterValueModel :BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterValueModel()
        {
        }

        /// <summary>
        /// Código Párametro
        /// </summary>
        public int CodeParameter { get; set; }
        /// <summary>
        /// Nombre de Párametro
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// Código de sección 
        /// </summary>
        public int CodeSeccion { get; set; }
        /// <summary>
        /// Código  Valor
        /// </summary>
        public int CodeValue { get; set; }
        /// <summary>
        /// Párametro
        /// </summary>
        public ParameterEL Parameter { get; set; }
        /// <summary>
        /// Lista de párametro valor
        /// </summary>
        public List<ParameterValueEL> ListParameterValue { get; set; }
        /// <summary>
        ///  Lista de párametro sección 
        /// </summary>
        public List<ParameterSectionEL> ListParameterSection { get; set; }
        /// <summary>
        /// Código de tipo de párametro
        /// </summary>
        public string CodeParameterType { get; set; }
        /// <summary>
        ///  Estado de registro
        /// </summary>
        public string RegistrationStatus { get; set; }
        /// <summary>
        /// Observación
        /// </summary>
        public string Observation { get; set; }
        /// <summary>
        /// Lista de párametro
        /// </summary>
        public List<SelectType> ListParameter { get; set; }
        /// <summary>
        /// Botón de búsqueda
        /// </summary>
        public ButtonControl Search { get; set; }
        /// <summary>
        ///  Botón crear
        /// </summary>
        public ButtonControl Create { get; set; }
        /// <summary>
        /// Botón guardar
        /// </summary>
        public ButtonControl Cancel { get; set; }
        /// <summary>
        /// Botón Guardar
        /// </summary>
        public ButtonControl Save { get; set; }
        /// <summary>
        /// Botón editar
        /// </summary>
        public ImageControl Edit { get; set; }
    }
}