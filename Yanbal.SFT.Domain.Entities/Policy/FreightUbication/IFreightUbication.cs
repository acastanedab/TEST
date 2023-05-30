using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Yanbal.SFT.Domain.Entities.Policy.FreightUbication
{
    /// <summary>
    /// Interfaz que Define la Entidad de Zona ubicacion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170928 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IFreightUbication : IDisposable
    {
        /// <summary>
        /// UbicationSearch
        /// </summary>
        FreightUbicationEN UbicationSearch(string ubicationCode);
    }
}
