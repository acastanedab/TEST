using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Policy.Formula
{
    /// <summary>
    /// Entidad de Negocio que representa a Auditoría de Tablas de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class PolicyAuditTableEN : IPolicyAuditTable
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<PolicyAuditTableEN> policyAuditTablerepositoryProcedure;
        //Fin Sonar 
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PolicyAuditTableEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="policyAuditTablerepositoryProcedure">Repositorio basado en store procedure</param>
        public PolicyAuditTableEN(IRepositoryStoredProcedure<PolicyAuditTableEN> policyAuditTablerepositoryProcedure)
        {
            this.policyAuditTablerepositoryProcedure = policyAuditTablerepositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Código de Auditoria Tabla
        /// </summary>
        public int      CodigoAuditoriaTabla{get;set;}
        
        /// <summary>
        /// Nombre de Tabla
        /// </summary>
        public string   NombreTabla { get; set; }

        /// <summary>
        /// Estado Registro
        /// </summary>
        public string   EstadoRegistro { get; set; }

        /// <summary>
        /// Descripción de Estado Registro
        /// </summary>
        public string   DescripcionEstadoRegistro { get; set; }

        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int      CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Descripción de Unidad de Negocio
        /// </summary>
        public string   DescripcionUnidadNegocio { get; set; }

        /// <summary>
        /// Usuario de Auditoria
        /// </summary>
        public string   UsuarioAuditoria { get; set; }

        /// <summary>
        /// Terminal de Auditoria
        /// </summary>
        public string   TerminalAuditoria { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite realizar la Búsqueda Auditoría de Tablas de Políticas
        /// </summary>
        /// <param name="registrationStatus">Estado de Registro</param>
        /// <returns>Lista de Auditoría de Tablas de Políticas</returns>
        public List<PolicyAuditTableEN> PolicyAuditTableSearch(string registrationStatus)
        {
            List<PolicyAuditTableEN> listPolicyAuditTable =  policyAuditTablerepositoryProcedure.ExecWithStoreProcedure("MNT.USP_AUDITORIA_TABLA_SEL",
                                     new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)registrationStatus ?? DBNull.Value }).ToList();
            return listPolicyAuditTable;
        }

        /// <summary>
        /// Destruye y libera el objeto
        /// </summary>
        public void Dispose()
        {
            if (this.policyAuditTablerepositoryProcedure != null)
            {
                this.policyAuditTablerepositoryProcedure.Dispose();
            }
        }
        #endregion
    }
}
