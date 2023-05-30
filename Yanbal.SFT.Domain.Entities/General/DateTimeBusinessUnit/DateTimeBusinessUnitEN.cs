using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.General
{
    /// <summary>
    /// Entidad de Negocio que representa la Fecha de la Unidad de Negocio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140610 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class DateTimeBusinessUnitEN : IDateTimeBusinessUnit
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<DateTimeBusinessUnitEN> repositoryProcedure;
        //Fin Sonar
        #region Constructors

        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public DateTimeBusinessUnitEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="repositoryProcedure">Repositorio basado en store procedure</param>
        public DateTimeBusinessUnitEN(IRepositoryStoredProcedure<DateTimeBusinessUnitEN> repositoryProcedure)
        {
            this.repositoryProcedure = repositoryProcedure;
        }

        #endregion
        #region Properties
        public DateTime? FechaUnidadNegocio { get; set; }
        #endregion
        #region Operations
        /// <summary>
        /// Permite Obtener la Fecha de Unidad de Negocio
        /// </summary>
        /// <param name="businessUnitCode">Código de Unidad de Negocio</param>
        /// <param name="countryCode">Código de País</param>
        /// <returns>Fecha de la Unidad de Negocio</returns>
        public DateTimeBusinessUnitEN GetDateTimeBusinessUnit(int? businessUnitCode, string countryCode)
        {
            return repositoryProcedure.ExecWithStoreProcedure("GRL.USP_OBTENER_FECHA_UNIDAD_NEGOCIO",
                                                                new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                                new SqlParameter("CODIGO_PAIS", SqlDbType.Char) { Value = (object)countryCode ?? DBNull.Value }
                                                            ).FirstOrDefault();
        }

        /// <summary>
        /// Destruye y libera el objeto
        /// </summary>
        public void Dispose()
        {
        }

        #endregion
    }
}