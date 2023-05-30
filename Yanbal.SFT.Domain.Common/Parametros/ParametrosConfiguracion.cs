using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.Parametros
{
    /// <summary>
    /// ParametrosConfiguracion
    /// </summary>
    public class ParametrosConfiguracion
    {
        /// <summary>
        /// Codigo Parametro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Codigo
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Componentes
        /// </summary>
        public string Componentes { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}
