using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yanbal.SFT.Domain.Entities.Base;

namespace Domain.Entities.Freight.Policy.TaxProduct
{
    /// <summary>
    /// Entidad de Negocio que representa Impuesto por tipo de producto
    /// </summary>
    /// <remarks>
    /// Creación: GMD(PBG) 20140827 <br />
    /// Modificación: 
    /// </remarks>
    public class TaxProductEN : ITaxProduct 
    {
        private readonly IRepositoryStoredProcedure<TaxProductEN> TaxProductRepositorySP;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public TaxProductEN() 
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TaxProductRepositorySP"></param>
        public TaxProductEN(IRepositoryStoredProcedure<TaxProductEN> TaxProductRepositorySP)
        {
            this.TaxProductRepositorySP = TaxProductRepositorySP;        
        }
        #endregion

        #region Properties

        /// <summary>
        /// Código de Impuesto Producto
        /// </summary>
        public int CodigoImpuestoProducto { get; set; }
        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int CodigoUnidadNegocio { get; set; }
        /// <summary>
        /// Código 
        /// </summary>
        public string CodigoImpuesto { get; set; }
        /// <summary>
        /// Código de Producto
        /// </summary>
        public string CodigoProducto { get; set; }
        /// <summary>
        /// Origen
        /// </summary>
        public string Origen { get; set; }
        /// <summary>
        /// Nombre de Impuesto
        /// </summary>
        public string NombreImpuesto { get; set; }
        /// <summary>
        /// Valor de Impuesto
        /// </summary>
        public decimal? ValorImpuesto { get; set; }
        /// <summary>
        /// Valor de Referencial
        /// </summary>
        public decimal ValorReferencial { get; set; }
        /// <summary>
        /// Excepcion
        /// </summary>
        public bool? Excepcion { get; set; }
        /// <summary>
        /// Observacion
        /// </summary>
        public string Observacion { get; set; }
        /// <summary>
        /// Usuario de Creacion
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// Terminal de Creacion
        /// </summary>
        public string TerminalCreacion { get; set; }
        /// <summary>
        /// Usuario de Modificacion
        /// </summary>
        public string UsuarioModificacion { get; set; }
        /// <summary>
        /// Fecha de Modificacion
        /// </summary>
        public DateTime? FechaModificacion { get; set; }
        /// <summary>
        /// Terminal de Modificacion
        /// </summary>
        public string TerminalModificacion { get; set; }
        /// <summary>
        /// Descripcion Origen
        /// </summary>
        public string DescripcionOrigen { get; set; }
        /// <summary>
        /// Descripcion de estado
        /// </summary>
        public string DescripcionEstado { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        #endregion

        #region Operation

        /// <summary>
        ///  Permite realizar la busqueda de la vista Impuesto por tipo de Producto
        /// </summary>
        /// <param name="codeTaxProduct"></param>
        /// <param name="businessUnitCode"></param>
        /// <param name="code">Código</param>
        /// <param name="codeProduct">Código de Producto</param>
        /// <param name="origin">Origen</param>
        /// <param name="exception">Excepción</param>
        /// <param name="status">Estado de Registro</param>
        /// <returns>Lista con la busqueda realizada</returns>
        public List<TaxProductEN> TaxProductSearch(int? codeTaxProduct, int businessUnitCode, string taxCode, string codeProduct, string origin, bool? exception, string status)
        {
            return List < TaxProductEN > TaxProductSearch(codeTaxProduct, businessUnitCode, taxCode, codeProduct, origin, exception, status, 1, -1);
        }

        /// <summary>
        ///  Permite realizar la busqueda de la vista Impuesto por tipo de Producto
        /// </summary>
        /// <param name="codeTaxProduct"></param>
        /// <param name="businessUnitCode"></param>
        /// <param name="code">Código</param>
        /// <param name="codeProduct">Código de Producto</param>
        /// <param name="origin">Origen</param>
        /// <param name="exception">Excepción</param>
        /// <param name="status">Estado de Registro</param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns>Lista con la busqueda realizada</returns>
        public List<TaxProductEN> TaxProductSearch(int? codeTaxProduct, int businessUnitCode, string taxCode, string codeProduct, string origin, bool? exception, string status, int pageNo , int pageSize )
        {
            List<TaxProductEN> returnList = TaxProductRepositorySP.ExecWithStoreProcedure("MNT.USP_IMPUESTO_PRODUCTO_SEL",
                                                            new SqlParameter("CODIGO_IMPUESTO_PRODUCTO", SqlDbType.Int) { Value = (object)codeTaxProduct ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_UNIDAD_NEGOCIO", SqlDbType.Int) { Value = businessUnitCode },
                                                            new SqlParameter("CODIGO_IMPUESTO", SqlDbType.NVarChar) { Value = (object)taxCode ?? DBNull.Value },
                                                            new SqlParameter("CODIGO_PRODUCTO", SqlDbType.Char) { Value = (object)codeProduct ?? DBNull.Value },
                                                            new SqlParameter("ORIGEN", SqlDbType.Char) { Value = (object)origin ?? DBNull.Value },
                                                            new SqlParameter("EXCEPCION", SqlDbType.Bit) { Value = (object)exception ?? DBNull.Value },
                                                            new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char) { Value = (object)status ?? DBNull.Value },
                                                            new SqlParameter("PageNo", SqlDbType.Int) { Value = (object)pageNo ?? DBNull.Value },
                                                            new SqlParameter("PageSize", SqlDbType.Int) { Value = (object)pageSize ?? DBNull.Value }
                                                            ).ToList();
            return returnList;
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
