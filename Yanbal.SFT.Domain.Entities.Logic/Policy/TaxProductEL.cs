using Domain.Entities.Logic.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Impuesto por tipo de Producto
    /// </summary>
    /// <remarks>
    /// Creación: GMD(PBG) 20140827 <br />
    /// Modificación: 
    /// </remarks>
    public class TaxProductEL : BaseEL
    {
        /// <summary>
        /// Código de Impuesto por Producto
        /// </summary>
        public int CodeTaxProduct { get; set; }
        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }
        /// <summary>
        /// Código 
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// Código de Producto
        /// </summary>
        public string CodeProduct { get; set; }
        /// <summary>
        /// Origen
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// Excepción
        /// </summary>
        public bool? Exception { get; set; }
        /// <summary>
        /// Descripción de Origen
        /// </summary>
        public string OriginDescription { get; set; }
        /// <summary>
        /// Nombre de Impuesto
        /// </summary>
        public string TaxName { get; set; }
        /// <summary>
        /// Valor de impuesto
        /// </summary>
        public decimal? TaxValue { get; set; }
        /// <summary>
        /// Valor de referencia
        /// </summary>
        public decimal ReferenceValue { get; set; }
        /// <summary>
        /// Descripción de Impuesto
        /// </summary>
        public string DescriptionTax { get; set; }
       
    }
}
