using Dapper;
using Microsoft.Data.SqlClient;

namespace Rd.Veiculos.Api.Infraestructure.SqlServer.Repositories
{
    public class BaseRepository
    {
        private readonly string ConnectionString;

        protected BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(CommandDefinition commandDefinition)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryFirstOrDefaultAsync<T>(commandDefinition);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<T> QuerySingleOrDefaultAsync<T>(string isTimeQuery, DynamicParameters @params)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(isTimeQuery, @params);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<T> QuerySingleOrDefaultAsync<T>(string query, DynamicParameters parameters, CancellationToken ctx)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(new CommandDefinition(query, parameters, cancellationToken: ctx));
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<T> QuerySingleOrDefaultAsync<T>(CommandDefinition command)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(command);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(query);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, DynamicParameters parameters)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(query, parameters);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition commandDefinition)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(commandDefinition);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<int> ExecuteAsync(string query, DynamicParameters parameters)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.ExecuteAsync(query, parameters);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }

        protected async Task<int> ExecuteAsync(CommandDefinition command)
        {
            using SqlConnection sqlConnection = CreateSqlConnection();

            try
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.ExecuteAsync(command);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }
        }
    }
}