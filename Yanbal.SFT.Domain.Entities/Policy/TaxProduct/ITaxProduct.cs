using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Freight.Policy.TaxProduct
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Impuesto por tipo de producto
    /// </summary>
    /// <remarks>
    /// Creación: GMD(PBG) 20140827 <br />
    /// Modificación: 
    /// </remarks>
    public interface ITaxProduct : IDisposable
    {
        List<TaxProductEN> TaxProductSearch(int? codeTaxProduct, int businessUnitCode, string taxCode, string codeProduct, string origin, bool? exception, string status);
        List<TaxProductEN> TaxProductSearch(int? codeTaxProduct, int businessUnitCode, string taxCode, string codeProduct, string origin, bool? exception, string status, int pageNo, int pageSize);
    }
}
