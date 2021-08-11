using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Server.DataAccess
{

    /// <summary>
    /// Administra la conexion con el ORM Dapper.
    /// </summary>
    public abstract class ConexionBase
    {
        /// <summary>
        /// Llave de conexion a la base de datos, recuperado desde el appsettings.
        /// </summary>
        internal abstract string LlaveDeConexion
        {
            get;
        }


        /// <summary>
        /// Crea la conexion a la base de datos.
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(LlaveDeConexion);
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y recupera informacion segun se requiera
        /// </summary>
        /// <typeparam name="T">Tipo de dato de respuesta</typeparam>
        /// <param name="procedimiento">Esquema y nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros recibidos por el procedimiento almacenado</param>
        /// <returns></returns>
        public async Task<List<T>> ObtenerListaDeEntidadDesdeProcedimientoAlmacenado<T>(string procedimiento, DynamicParameters parametros = null)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(procedimiento, parametros, null, null, CommandType.StoredProcedure);
                return result.ToList<T>();
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y recupera informacion segun se requiera
        /// </summary>
        /// <typeparam name="T">Tipo de dato de respuesta</typeparam>
        /// <param name="procedimiento">Esquema y nombre del procedimiento almacenado</param>
        /// <param name="parametros">Parametros recibidos por el procedimiento almacenado</param>
        /// <returns></returns>
        public async Task<T> ObtenerEntidadDesdeProcedimientoAlmacenado<T>(string procedimiento, DynamicParameters parametros = null)
        {
            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(procedimiento, parametros, null, null, CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
        protected async Task<T> QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (IDbConnection connection = Connection)
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        protected async Task<List<T>> QueryProcedure<T>(string sql, object parameters = null)
        {
            using (IDbConnection connection = Connection)
            {
                return (await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        protected async Task<List<T>> Query<T>(string sql, object parameters = null)
        {
            using (IDbConnection connection = Connection)
            {
                return (await connection.QueryAsync<T>(sql, parameters)).ToList();
            }
        }

        protected async Task<List<T>> Query<T>(string sql)
        {
            using (IDbConnection connection = Connection)
            {
                return (await connection.QueryAsync<T>(sql)).ToList();
            }
        }

    }

}
