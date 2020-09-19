using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper
{
    public class DapperRepository
    {
        private IConfiguration Configuration { get; }

        private IDbConnection Connection => new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

        public DapperRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected async Task ExecuteAsync(string storedProcedureName, object parameters = null)
        {
            using var connection = Connection;

            await connection.ExecuteAsync(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string storedProcedureName, object parameters = null)
        {
            using var connection = Connection;

            return await connection.QueryAsync<T>(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string storedProcedureName, object parameters)
        {
            using var connection = Connection;

            return await connection.QueryFirstOrDefaultAsync<T>(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
