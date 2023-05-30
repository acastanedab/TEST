using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Base;

namespace Domain.Entities.Freight.TaxProfile
{
    public class TaxProfileEN : ITaxProfile
    {

        private readonly IRepositoryStoredProcedure<TaxProfileEN> taxRepositoryRepositorySp;

        #region Properties
        public int CodigoPerfilTributario { get; set; }
        public int CodigoUnidadNegocio { get; set; }
        public string CodigoDirectora { get; set; }
        public string NombreDirectora { get; set; }
        public string TipoPersona { get; set; }
        public int Autonomia { get; set; }
        public DateTime FechaDeclaracion { get; set; }
        public string Afectaciones { get; set; }
        public string Observacion { get; set; }
        public string EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string TerminalCreacion { get; set; }
        public string UsuarioModifiacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string TerminalModificacion { get; set; }
        public string Exoneracion { get; set; }
        #endregion

        #region Constructor
        public TaxProfileEN()
        { }

        public TaxProfileEN(IRepositoryStoredProcedure<TaxProfileEN> taxRepositoryRepositorySp)
        {
            this.taxRepositoryRepositorySp = taxRepositoryRepositorySp;
        }
        #endregion         

        #region  Operation

        public List<TaxProfileEN> TaxProfileSearch(int? businessUnitCode, string directorCode, string directorName, string status, string affected)
        {
            return List < TaxProfileEN > TaxProfileSearch( businessUnitCode, directorCode, directorName,  status,  affected,  1, -1);
        }

        public List<TaxProfileEN> TaxProfileSearch(int? businessUnitCode, string directorCode, string directorName, string status, string affected, int pageNo, int pageSize )
        {
            List<TaxProfileEN> listaTaxProfile = taxRepositoryRepositorySp.ExecWithStoreProcedure("MNT.USP_PERFIL_TRIBUTARIO_SEL",
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = (object)businessUnitCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_DIRECTORA", SqlDbType.NVarChar) { Value = (object)directorCode ?? DBNull.Value },
                                                            new SqlParameter("NOMBRE_DIRECTORA", SqlDbType.NVarChar) { Value = (object)directorName ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.NVarChar) { Value = (object)status ?? DBNull.Value },
                                                            new SqlParameter("AFECTACIONES", SqlDbType.NVarChar) { Value = (object)affected ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = pageNo },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = pageSize }
                                                        ).ToList();
            return listaTaxProfile;
        }



         
        public int TaxProfileRegister(TaxProfileEN taxProfile)
        {
            return taxRepositoryRepositorySp.ExecWithStoreProcedureSave("MNT.USP_PARAMETRO_INS",
                                                    new SqlParameter("CODIGO_PERFIL_TRIBUTARIO", SqlDbType.Int) { Value = taxProfile.CodigoPerfilTributario },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = taxProfile.CodigoUnidadNegocio },
                                                    new SqlParameter("CODIGO_DIRECTORA", SqlDbType.NVarChar) { Value = taxProfile.CodigoDirectora },
                                                    new SqlParameter("NOMBRE_DIRECTORA", SqlDbType.NVarChar) { Value = taxProfile.NombreDirectora },
                                                    new SqlParameter("TIPO_PERSONA", SqlDbType.NVarChar) { Value = taxProfile.TipoPersona },
                                                    new SqlParameter("AUTONOMIA", SqlDbType.Int) { Value = taxProfile.Autonomia },
                                                    new SqlParameter("FECHA_DECLARACION", SqlDbType.DateTime) { Value = taxProfile.FechaDeclaracion },
                                                    new SqlParameter("EXONERACION", SqlDbType.NVarChar) { Value = taxProfile.Exoneracion },
                                                    new SqlParameter("AFECTACIONES", SqlDbType.NVarChar) { Value = taxProfile.Afectaciones },
                                                    new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = taxProfile.Observacion },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.NVarChar) { Value = taxProfile.EstadoRegistro },
                                                    new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar) { Value = taxProfile.UsuarioCreacion },
                                                    new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar) { Value = taxProfile.TerminalCreacion });
        }
         
        public int TaxProfileUpdate(TaxProfileEN taxProfile)
        {
            return taxRepositoryRepositorySp.ExecWithStoreProcedureSave("MNT.UPS_PERFIL_TRIBUTARIO_UPD",
                                                    new SqlParameter("CODIGO_PERFIL_TRIBUTARIO", SqlDbType.Int) { Value = taxProfile.CodigoPerfilTributario },
                                                    new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = taxProfile.CodigoUnidadNegocio },
                                                    new SqlParameter("CODIGO_DIRECTORA", SqlDbType.NVarChar) { Value = taxProfile.CodigoDirectora },
                                                    new SqlParameter("NOMBRE_DIRECTORA", SqlDbType.NVarChar) { Value = taxProfile.NombreDirectora },
                                                    new SqlParameter("TIPO_PERSONA", SqlDbType.NVarChar) { Value = taxProfile.TipoPersona },
                                                    new SqlParameter("AUTONOMIA", SqlDbType.Int) { Value = taxProfile.Autonomia },
                                                    new SqlParameter("FECHA_DECLARACION", SqlDbType.DateTime) { Value = taxProfile.FechaDeclaracion },
                                                    new SqlParameter("EXONERACION", SqlDbType.NVarChar) { Value = taxProfile.Exoneracion },
                                                    new SqlParameter("AFECTACIONES", SqlDbType.NVarChar) { Value = taxProfile.Afectaciones },
                                                    new SqlParameter("OBSERVACION", SqlDbType.NVarChar) { Value = taxProfile.Observacion },
                                                    new SqlParameter("ESTADO_REGISTRO", SqlDbType.NVarChar) { Value = taxProfile.EstadoRegistro },
                                                    new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar) { Value = taxProfile.UsuarioModifiacion },
                                                    new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar) { Value = taxProfile.TerminalModificacion });
        }

        public void Dispose()
        {
             
        }

        #endregion



    }
}
