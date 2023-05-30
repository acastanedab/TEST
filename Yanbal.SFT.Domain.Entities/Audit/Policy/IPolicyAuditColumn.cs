using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Audit.Policy
{
    /// <summary>
    /// Entidad de Negocio que representa la Auditoría de Columnas de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public interface IPolicyAuditColumn : IDisposable
    {
        /// <summary>
        /// PolicyAuditColumnSearch
        /// </summary>
        List<PolicyAuditColumnEN> PolicyAuditColumnSearch(int? tableCode, string registrationStatus);
    }
}
