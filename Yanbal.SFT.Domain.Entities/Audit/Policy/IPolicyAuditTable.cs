using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.Formula
{
    /// <summary>
    /// Entidad de Negocio que representa la Auditoría de Tablas de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public interface IPolicyAuditTable : IDisposable
    {
        /// <summary>
        /// PolicyAuditTableSearch
        /// </summary>
        List<PolicyAuditTableEN> PolicyAuditTableSearch(string registrationStatus);
    }
}
