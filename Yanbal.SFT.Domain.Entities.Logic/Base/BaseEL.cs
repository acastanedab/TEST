using System;
using Yanbal.SFT.FreightManagement.Common.Paging;

namespace Yanbal.SFT.Domain.Entities.Logic.Base
{
    /// <summary>
    /// Clase de entidad logíca base
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140715 <br />
    /// Modificacion: 
    /// </remarks>
    [Serializable]
    public class BaseEL : PagingBase
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BaseEL()
        {
        }

        /// <summary>
        /// Codigo de Unidad de Negocio
        /// </summary>
        public int BusinessUnitCode { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Descripción Estado de Registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }

        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UserCreation { get; set; }

        /// <summary>
        /// Terminal de Creación
        /// </summary>
        public string TerminalCreation { get; set; }

        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime? DateCreation { get; set; }

        /// <summary>
        /// Usuario de Modificación
        /// </summary>
        public string UserModification { get; set; }

        /// <summary>
        /// Terminal de Modificación
        /// </summary>
        public string TerminalModification { get; set; }

        /// <summary>
        /// Fecha de Modificación
        /// </summary>
        public DateTime? DateModification { get; set; }

        /// <summary>
        /// Correlativo
        /// </summary>
        public int Correlativo { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Nombre Parámetro
        /// </summary>
        public string NombreParametro { get; set; }
        /// <summary>
        /// Descripción Código Sección
        /// </summary>
        public string sCodigoSeccion { get; set; }
        /// <summary>
        /// Nombre Parámetro
        /// </summary>
        public string NombreParametroSeccion { get; set; }
        /// <summary>
        /// Descripción Código Valor
        /// </summary>
        public string sCodigoValor { get; set; }
    }
}
