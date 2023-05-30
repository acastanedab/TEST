using System;
using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad Lógica que representa la Zona ubicacion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170928 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class FreightUbicationEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public FreightUbicationEL()
        {
        }

        /// <summary>
        /// Código de País
        /// </summary>
        public string CodigoPais { get; set; }
        /// <summary>
        /// Código de Provincia
        /// </summary>
        public string CodigoProvincia { get; set; }
        /// <summary>
        /// Código de Ciudad
        /// </summary>
        public string CodigoCiudad { get; set; }
        /// <summary>
        /// Código de Distrito
        /// </summary>
        public string CodigoDistrito { get; set; }
    }
}
