using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa la Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140917 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class BusinessUnitModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BusinessUnitModel()
        {
        }

        /// <summary>
        /// Código de Fórmula
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// Descripción de Parámetro
        /// </summary> 
        public string CountryCode { get; set; }

        /// <summary>
        /// Descripción de País
        /// </summary> 
        public string CountryDescription { get; set; }

        /// <summary>
        /// Razón Social
        /// </summary> 
        public string BusinessUnitName { get; set; }

        /// <summary>
        /// Dirección de la Compañía
        /// </summary> 
        public string BusinessAddress { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Descripción de Estado de Registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }

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
        /// Control de Imagen Editar
        /// </summary>
        public ImageControl Edit { get; set; }

        /// <summary>
        /// Lista de Países
        /// </summary>
        public List<SelectType> ListCountry { get; set; }

        /// <summary>
        /// Lista de Culturas
        /// </summary>
        public List<SelectType> ListCulture { get; set; }

        /// <summary>
        /// Control de Imagen Configuración
        /// </summary>
        public ImageControl GoConfiguration { get; set; }
    }
}
