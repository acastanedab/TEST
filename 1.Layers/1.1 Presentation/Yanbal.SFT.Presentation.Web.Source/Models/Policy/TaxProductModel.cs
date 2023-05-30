using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Presentation.Web.Source.Models.Base;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Policy
{
    /// <summary>
    /// Modelo de Vista Impuesto por Tipo de Producto
    /// </summary>
    public class TaxProductModel : BaseModel
    {
        /// <summary>
        /// Constructor por defecto de implementación del modelo
        /// </summary>
        public TaxProductModel()
        {
            this.ListRegistrationStatus = new List<SelectType>();
            this.ListTaxType = new List<SelectType>();
            this.ListOrigin = new List<SelectType>();
            this.ListException = new List<SelectType>();
        }
        /// <summary>
        /// Botón de limpiar
        /// </summary>
        public ButtonControl Clean { get; set; }
        /// <summary>
        /// Botón de Buscar 
        /// </summary>
        public ButtonControl Search { get; set; }
        /// <summary>
        /// Botón Crear
        /// </summary>
        public ButtonControl Create { get; set; }
        /// <summary>
        /// Botón Crear
        /// </summary>
        public ImageControl Edit { get; set; }
        /// <summary>
        /// Botón Guardar
        /// </summary>
        public ButtonControl Save { get; set; }
        /// <summary>
        /// Botón Cancelar
        /// </summary>
        public ButtonControl Cancel { get; set; }
        /// <summary>
        /// Lista de Estado de Registro
        /// </summary>
        public List<SelectType> ListRegistrationStatus { get; set; }
        /// <summary>
        /// Lista de tipo de impuesto
        /// </summary>
        public List<SelectType> ListTaxType { get; set; }
        /// <summary>
        /// Lista de origenes
        /// </summary>
        public List<SelectType> ListOrigin { get; set; }
                /// <summary>
        /// Lista de excepciones
        /// </summary>
        public List<SelectType> ListException { get; set; }
    }
}
