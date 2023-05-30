using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.Paging
{
    /// <summary>
    /// Clase que contiene las propiedades basicas de la Paginación de Base de Datos
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140815 <br />
    /// Modificación:       <br />
    /// </remarks>
    [Serializable]
    public class PagingBase
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PagingBase()
        {
        }

        /// <summary>
        /// Cantidad Total de Registro
        /// </summary>
        public int? RowsTotal { get; set; }

        /// <summary>
        /// Número de Registro
        /// </summary>
        public long? RowNumber { get; set; }

        /// <summary>
        /// Identificador de Registro
        /// </summary>
        public int? RowId { get; set; }
    }
}
