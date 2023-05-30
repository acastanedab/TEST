using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Audit.Policy
{
    /// <summary>
    /// Entidad de Negocio que representa a Auditoría de Columnas de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class PolicyAuditColumnEN : IPolicyAuditColumn
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<PolicyAuditColumnEN> policyAuditColumnrepositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PolicyAuditColumnEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="policyAuditColumnrepositoryProcedure">epositorio basado en store procedure</param>
        public PolicyAuditColumnEN(IRepositoryStoredProcedure<PolicyAuditColumnEN> policyAuditColumnrepositoryProcedure)
        {
            this.policyAuditColumnrepositoryProcedure = policyAuditColumnrepositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Política Auditoría
        /// </summary>
        public int CodigoAuditoriaTabla{get;set;}
        /// <summary>
        /// Código de Política Auditoría Columna
        /// </summary>
        public int CodigoAuditoriaColumna { get; set; }
        /// <summary>
        /// Nombre de Columna
        /// </summary>
        public string NombreColumna { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Descripción de Estado deRegistro
        /// </summary>
        public string DescripcionEstadoRegistro { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite Listar Política Auditoría Columna
        /// </summary>
        /// <param name="tableCode">Código de Tabla</param>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <returns>Lista de Política Auditoría Columna</returns>
        public List<PolicyAuditColumnEN> PolicyAuditColumnSearch(int? tableCode, string registrationStatus)
        {
            List<PolicyAuditColumnEN> listPolicyAuditColumn = policyAuditColumnrepositoryProcedure.ExecWithStoreProcedure("MNT.USP_AUDITORIA_COLUMNA_SEL",
                                                new SqlParameter("CODIGO_AUDITORIA_TABLA", SqlDbType.Int) { Value = (object)tableCode ?? DBNull.Value },
                                                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value }).ToList();
            return listPolicyAuditColumn;
        }

        /// <summary>
        /// Destruye y libera el objeto.
        /// </summary>
        public void Dispose()
        {
            if (this.policyAuditColumnrepositoryProcedure != null)
            {
                this.policyAuditColumnrepositoryProcedure.Dispose();
            }
        }
        #endregion
    }
}
