using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.FreightManagement.Common.Paging;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.TimeZone
{
    /// <summary>
    /// Entidad de Negocio que representa Zona Horaria
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140922 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class TimeZoneEN : PagingBase, ITimeZone
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<TimeZoneEN> timeZonerepositoryProcedure;
        //Fin Sonar
        #region Constructor
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public TimeZoneEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="timeZonerepositoryProcedure">Repositorio basado en store procedure</param>
        public TimeZoneEN(IRepositoryStoredProcedure<TimeZoneEN> timeZonerepositoryProcedure)
        {
            this.timeZonerepositoryProcedure = timeZonerepositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Zona Horaria
        /// </summary>
        public int CodigoZonaHoraria { get; set; }

        /// <summary>
        /// Hora UTC
        /// </summary>
        public short HoraUtc { get; set; }

        /// <summary>
        /// Minuto UTC
        /// </summary>
        public short MinutoUtc { get; set; }

        /// <summary>
        /// Descripción de Zona Horaria
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Descripcion Completa de Zona Horaria
        /// </summary>
        public string DescripcionCompleta { get; set; }

        /// <summary>
        /// Motivo de Modificación
        /// </summary>
        public string Observacion { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Descripcion de Estado de Registro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }

        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Terminal de Creación
        /// </summary>
        public string TerminalCreacion { get; set; }

        /// <summary>
        /// Usuario de Modificación
        /// </summary>
        public string UsuarioModificacion { get; set; }

        /// <summary>
        /// Fecha de Modificación
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Terminal de Modificación
        /// </summary>
        public string TerminalModificacion { get; set; }
        #endregion

        #region Operations

        /// <summary>
        /// Permite realizar la búsqueda de Zonas Horarias
        /// </summary>
        /// <param name="timeZoneCode">Código de zona</param>
        /// <param name="hourUtc">Hora</param>
        /// <param name="minuteUtc">Minuto</param>
        /// <param name="description">Descripción</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <param name="pageNo">Número de Pagina</param>
        /// <param name="pageSize">Tamaño de Pagina</param>
        /// <returns>Lista de zonas horarias</returns>
        public List<TimeZoneEN> TimeZoneSearch(int? timeZoneCode, short? hourUtc, short? minuteUtc, string description, string registrationStatus, int? pageNo, int? pageSize)
        {
            List<TimeZoneEN> lisTimeZone = timeZonerepositoryProcedure.ExecWithStoreProcedure("MNT.USP_ZONA_HORARIA_SEL").ToList();
            return lisTimeZone;
        }

        /// <summary>
        /// Destruye y libera el objeto.
        /// </summary>
        public void Dispose()
        {

        }
        #endregion
    }
}
