using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.Paging
{
    /// <summary>
    /// Clase que contiene los parametros para el filtro por Paginación de Base de Datos
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140815 <br />
    /// Modificación:       <br />
    /// </remarks>
    [Serializable]
    public class PagingFilter
    {
        /// <summary>
        /// Contructor de la Clase
        /// </summary>
        public PagingFilter()
            {
                this.PageNo = 1;
                this.PageSize = -1;
            }

        /// <summary>
        /// Número de Pagina
        /// </summary>
        public int? PageNo { get; set; }

        /// <summary>
        /// Tamaño de la Pagina
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Columna que determina el Orden
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Tipo de Orden
        /// </summary>
        public string SortOrder { get; set; }
    }
}
