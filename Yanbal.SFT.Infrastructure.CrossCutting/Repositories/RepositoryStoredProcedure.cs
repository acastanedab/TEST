using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yanbal.SFT.Domain.Entities.Base;
using Yanbal.SFT.Domain.Entities.General;
using Yanbal.SFT.Infrastructure.CrossCutting.Integracion;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Repositories
{
    /// <summary>
    /// Clase repositorio generico basado en store procedure
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140615 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class RepositoryStoredProcedure<TEntity> : IRepositoryStoredProcedure<TEntity> where TEntity : class
    {
        #region Properties
        //Inicio Sonar 15/08/2016
        private readonly DbContext dBContext = null;
        //Fin Sonar
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor que permite inicializar el context
        /// </summary>
        /// <param name="context">Contexto de la Conexión</param>
        public RepositoryStoredProcedure(IDbContext context)
        {
            dBContext = (DbContext)context;

        }

        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public RepositoryStoredProcedure()
        {
            try
            {
                dBContext = new DataBaseContext();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Operations
        /// <summary>
        /// Permite obtener el listado de entidades via store procedure
        /// </summary>
        /// <param name="query">Nombre de store procedure</param>
        /// <param name="parameters">Parametros de entrada del store procedure</param>
        /// <returns>Lista de entidades</returns>
        public IEnumerable<TEntity> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            dBContext.Database.CommandTimeout = 1200;
            return dBContext.Database.SqlQuery<TEntity>(query, parameters);
        }

        /// <summary>
        /// Permite obtener el listado de entidades segun el tipado via store procedure
        /// </summary>
        /// <param name="query">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>Lista de entidades</returns>
        public IEnumerable<T> ExecWithStoreProcedure<T>(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            dBContext.Database.CommandTimeout = 1200;
            return dBContext.Database.SqlQuery<T>(query, parameters);
        }

        /// <summary>
        /// Permite ejecutar un store procedure que devuelve una valor unico entero
        /// </summary>
        /// <param name="query">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>Numero generado</returns>
        public int ExecWithStoreProcedureScalar(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            dBContext.Database.CommandTimeout = 1200;
            return dBContext.Database.SqlQuery<int>(query, parameters).FirstOrDefault();
        }

        /// <summary>
        /// Permite ejecutar un store procedure que devuelve una valor unico tipado
        /// </summary>
        /// <param name="query">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>valor tipado</returns>
        public T ExecWithStoreProcedureScalarType<T>(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            dBContext.Database.CommandTimeout = 1200;
            return dBContext.Database.SqlQuery<T>(query, parameters).FirstOrDefault();
        }

        /// <summary>
        /// Permite ejecutar un store procedure de actualizacion
        /// </summary>
        /// <param name="query">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>Numero de registros afectados</returns>
        public int ExecWithStoreProcedureSave(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            dBContext.Database.CommandTimeout = 1200;
            return dBContext.Database.ExecuteSqlCommand(query, parameters);
        }

        /// <summary>
        /// Permite ejecutar un store procedure de actualizacion via SQL Command
        /// </summary>
        /// <param name="procedureName">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>Numero de registros afectados</returns>
        public int ExecWithStoreProcedureNonQuery(string procedureName, params object[] parameters)
        {
            int result = 0;
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = (SqlConnection)dBContext.Database.Connection;
                SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = sqlConnection.ConnectionTimeout;
                if (parameters.Any())
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlConnection.Open();
                result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Permite generar la sentencia a ejecutar
        /// </summary>
        /// <param name="query">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>Sentencia a ejecutar</returns>
        private string GenerateQueryString(string query, params object[] parameters)
        {
            StringBuilder queri = new StringBuilder();
            if (!query.Contains("@"))
            {
                queri.Append(query);
                for (var i = 0; i < parameters.Length; i++)
                {
                    if (i == 0)
                    {   
                        queri.Append(" @");
                        queri.Append(((System.Data.SqlClient.SqlParameter)(parameters[i])).ParameterName);
                    }
                    else
                    {
                        queri.Append(", @");
                        queri.Append(((System.Data.SqlClient.SqlParameter)(parameters[i])).ParameterName);
                    }
                }
            }
            return queri.ToString();
        }
        
        /// <summary>
        /// Permite ejecutar la consulta dinamica y guardarlo en Dictionary
        /// </summary>
        /// <param name="reader">Objeto que contine una secuencia del Origen de Datos</param>
        /// <returns></returns>
        private static List<Dictionary<string, object>> ReadQueryDictionary(System.Data.Common.DbDataReader reader)
        {
            var resultadoEjecucion = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> registro = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    registro.Add(reader.GetName(i), reader.GetValue(i));
                }
                resultadoEjecucion.Add(registro);
            }
            return resultadoEjecucion;
        }

        /// <summary>
        /// Permite ejecutar sentencias y colocarlos en Dictionary
        /// </summary>
        /// <param name="query">sentencia</param>
        /// <returns>Lista de Dictionary</returns>
        public virtual List<Dictionary<string, object>> ExecQueryEntidadDictionary(string query)
        {
            List<Dictionary<string, object>> result = null;
            try
            {
                SqlConnection sqlConnection = (SqlConnection)dBContext.Database.Connection;
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    dBContext.Database.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        result = ReadQueryDictionary(reader).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dBContext.Database.Connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Permite generar registro dinamicos
        /// </summary>
        /// <param name="query">sentencia</param>
        /// <returns>Numero de registros afectados</returns>
        public int ExecQueryRegistroDinamico(string query)
        {
            int result = 0;
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = (SqlConnection)dBContext.Database.Connection;
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.CommandTimeout = sqlConnection.ConnectionTimeout;

                    sqlConnection.Open();
                    result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Permite generar sentencias para entidades dinámicas
        /// </summary>
        /// <param name="query">sentencia</param>
        /// <returns>Lista de Entidades Dinámicas</returns>
        public virtual List<List<DynamicEntityEN>> ExecQueryDynamicEntity(string query)
        {
            List<List<DynamicEntityEN>> result = null;
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = (SqlConnection)dBContext.Database.Connection;
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    dBContext.Database.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        result = ReadQueryDynamicEntity(reader).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Permite ejecutar la consulta dinamica y guardarlo en una Entidad Dinamica
        /// </summary>
        /// <param name="reader">Objeto que contine una secuencia del Origen de Datos</param>
        /// <returns>Lista de Entidades Dinamicas</returns>
        private static List<List<DynamicEntityEN>> ReadQueryDynamicEntity(System.Data.Common.DbDataReader reader)
        {
            List<List<DynamicEntityEN>> resultadoEjecucion = new List<List<DynamicEntityEN>>();
            while (reader.Read())
            {
                List<DynamicEntityEN> registro = new List<DynamicEntityEN>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    DynamicEntityEN campo = new DynamicEntityEN();
                    campo.DataName = reader.GetName(i);
                    campo.DataType = reader.GetDataTypeName(i);
                    campo.DataValue = reader.GetValue(i);
                    registro.Add(campo);
                }
                resultadoEjecucion.Add(registro);
            }
            return resultadoEjecucion;
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
