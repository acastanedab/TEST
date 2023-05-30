using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Base;

namespace Yanbal.SFT.Domain.Entities.Audit.Policy
{
    /// <summary>
    /// Entidad de Negocio que representa a Auditoría de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class PolicyAuditEN : IPolicyAudit
    {   //Inicio Sonar 15/08/2016
        private readonly IRepositoryStoredProcedure<PolicyAuditEN> policyAuditrepositoryProcedure;
        //Fin Sonar
        #region Constructors
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PolicyAuditEN()
        {
        }

        /// <summary>
        /// Constructor que permite inicializar la clase repositorio basado en store procedure
        /// </summary>
        /// <param name="policyAuditrepositoryProcedure">Repositorio basado en store procedure</param>
        public PolicyAuditEN(IRepositoryStoredProcedure<PolicyAuditEN> policyAuditrepositoryProcedure)
        {
            this.policyAuditrepositoryProcedure = policyAuditrepositoryProcedure;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Nombre de Tabla
        /// </summary>
        public string NombreTabla { get; set; }

        /// <summary>
        /// Nombre de Columna
        /// </summary>
        public string NombreColumna { get; set; }
        
        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int    CodigoUnidadNegocio { get; set; }

        /// <summary>
        /// Descripción de Unidad de Negocio
        /// </summary>
        public string DescripcionUnidadNegocio { get; set; }

        /// <summary>
        /// Código del Registro Creado o Modificado
        /// </summary>
        public string CodigoRegistroTabla { get; set; }
        
        /// <summary>
        /// Valor Anterior
        /// </summary>
        public string ValorAnterior { get; set; }

        /// <summary>
        /// Valor Nuevo
        /// </summary>
        public string ValorNuevo { get; set; }

        /// <summary>
        /// Glosa
        /// </summary>
        public string Glosa { get; set; }

        /// <summary>
        /// Usuario de Auditoria
        /// </summary>
        public string UsuarioAuditoria { get; set; }

        /// <summary>
        /// Terminal de Auditoria
        /// </summary>
        public string TerminalAuditoria { get; set; }
        #endregion

        #region Operations
        /// <summary>
        /// Permite el Registro de Auditoría de Políticas
        /// </summary>
        /// <param name="register">Auditoría de Políticasa</param>
        /// <returns>Indicador de Conformidad</returns>
        public int PolicyAuditRegister(PolicyAuditEN register)
        {
            int result = policyAuditrepositoryProcedure.ExecWithStoreProcedureSave("MNT.AUDITORIA_DETALLE_INS",
                                                                         new SqlParameter("NOMBRE_TABLA", SqlDbType.NVarChar) { Value = register.NombreTabla },
                                                                         new SqlParameter("NOMBRE_COLUMNA", SqlDbType.NVarChar) { Value = register.NombreColumna },
                                                                         new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)register.CodigoUnidadNegocio ?? DBNull.Value },
                                                                         new SqlParameter("DESCRIPCION_UNIDAD_NEGOCIO", SqlDbType.NVarChar) { Value = (object)register.DescripcionUnidadNegocio ?? DBNull.Value },
                                                                         new SqlParameter("CODIGO_REGISTRO_TABLA", SqlDbType.VarChar) { Value = (object)register.CodigoRegistroTabla ?? DBNull.Value },
                                                                         new SqlParameter("VALOR_ANTERIOR", SqlDbType.NVarChar) { Value = register.ValorAnterior },
                                                                         new SqlParameter("VALOR_NUEVO", SqlDbType.NVarChar) { Value = (object)register.ValorNuevo ?? DBNull.Value },
                                                                         new SqlParameter("GLOSA", SqlDbType.NVarChar) { Value = (object)register.Glosa ?? DBNull.Value },
                                                                         new SqlParameter("USUARIO_AUDITORIA", SqlDbType.NVarChar) { Value = register.UsuarioAuditoria },
                                                                         new SqlParameter("TERMINAL_AUDITORIA", SqlDbType.NVarChar) { Value = register.TerminalAuditoria });


            return result;
        }

        /// <summary>
        /// Destruye y libera el objeto.
        /// </summary>
        public void Dispose()
        {
            if (this.policyAuditrepositoryProcedure != null)
            {
                this.policyAuditrepositoryProcedure.Dispose();
            }
        }
        #endregion
    }
}
