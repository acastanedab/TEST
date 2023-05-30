using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.General
{
    /// <summary>
    /// Interface que representa la Entidad Dinámica
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IDynamicEntity : IDisposable
    {
        /// <summary>
        /// ExecuteDynamicQueryDictionary
        /// </summary>
        List<Dictionary<string, object>> ExecuteDynamicQueryDictionary(string query);
        /// <summary>
        /// ExecuteDynamicQueryDynamicEntity
        /// </summary>
        List<List<DynamicEntityEN>> ExecuteDynamicQueryDynamicEntity(string query);
        /// <summary>
        /// ExecuteDynamicQueryRegister
        /// </summary>
        int ExecuteDynamicQueryRegister(string query);
    }
}
