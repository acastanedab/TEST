using System.Collections.Generic;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Freight
{
    /// <summary>
    /// Modelo que representa al Simulador del Servicio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140830 <br />
    /// Modificación:
    /// </remarks>
    public class SimulatorModel : BaseModel
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SimulatorModel()
        {

        }

        /// <summary>
        /// Monto del Flete en String
        /// </summary>
        public string AmountFreightString { get; set; }

        /// <summary>
        /// Codigo de Error
        /// </summary> 
        public string CodeError { get; set; }

        /// <summary>
        /// Descripción de Error
        /// </summary> 
        public string DescriptionError { get; set; }

        /// <summary>
        /// Descripción de la Combinación
        /// </summary> 
        public string CombinationDescription { get; set; }

        /// <summary>
        /// Código del Pais
        /// </summary> 
        public string CodeCountry { get; set; }

        /// <summary>
        /// Código del Pais del Nivel Geografico
        /// </summary> 
        public string CodeCountryGeo { get; set; }

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
        /// Lista de Tipos de Ordenes
        /// </summary> 
        public List<SelectType> ListTypeOrder { get; set; }

        /// <summary>
        /// Lista de Tipos de Envio
        /// </summary> 
        public List<SelectType> ListSendType { get; set; }

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
        /// Botón Simular
        /// </summary>
        public ButtonControl Simulator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<OrderResponseType> OrderResponseList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class OrderResponseType
    {
        /// <summary>
        /// 
        /// </summary>
        public string valueFreight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sendType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SendTypeDescripcion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string combinationDescription { get; set; }
    }
}
