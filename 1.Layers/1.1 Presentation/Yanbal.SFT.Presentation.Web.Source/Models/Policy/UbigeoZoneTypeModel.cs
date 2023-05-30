using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo que representa el Tipo de Zona de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140827 <br />
    /// Modificación:
    /// </remarks>
    public class UbigeoZoneTypeModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public UbigeoZoneTypeModel()
        {
        }

        /// <summary>
        /// Código de Tipo de Zona de Ubigeo
        /// </summary>
        public int CodeTypeZoneUbigeo { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Código de Zona
        /// </summary>
        public string CodeZone { get; set; }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodeCountry { get; set; }

        /// <summary>
        /// Nombre del País
        /// </summary>
        public string NameCountry { get; set; }

        /// <summary>
        /// Código de Nivel 1
        /// </summary>
        public string CodeLevel1 { get; set; }

        /// <summary>
        /// Código de Nivel 2
        /// </summary>
        public string CodeLevel2 { get; set; }
        
        /// <summary>
        /// Código de Nivel 3
        /// </summary>
        public string CodeLevel3 { get; set; }

        /// <summary>
        /// Código de Tipo de Zona
        /// </summary>
        public string CodeTypeZone { get; set; }

        /// <summary>
        /// Descripción de Tipo de Zona
        /// </summary>
        public string DescriptionTypeZone { get; set; }

        /// <summary>
        /// Etiqueta Nivel Geografico 1
        /// </summary>
        public string LabelGeoLevel1 { get; set; }

        /// <summary>
        /// Etiqueta Nivel Geografico 2
        /// </summary>
        public string LabelGeoLevel2 { get; set; }

        /// <summary>
        /// Etiqueta Nivel Geografico 3
        /// </summary>
        public string LabelGeoLevel3 { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Lista de Tipo de Zona
        /// </summary>
        public List<SelectType> ListTypeZone { get; set; }

        /// <summary>
        /// Lista de Niveles de Zona 1
        /// </summary>
        public List<SelectType> ListZoneLevel1 { get; set; }

        /// <summary>
        /// Lista de Niveles de Zona 2
        /// </summary>
        public List<SelectType> ListZoneLevel2 { get; set; }

        /// <summary>
        /// Lista de Niveles de Zona 3
        /// </summary>
        public List<SelectType> ListZoneLevel3 { get; set; }

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
    }
}
