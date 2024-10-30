using Dapper;
using FastScalableApi.Data;
using FastScalableApi.Models;
using System.Data.SqlClient;

namespace FastScalableApi.Services
{
    public class SqlRepository
    {
        private readonly DapperContext _dapperContext;

        public SqlRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<SqlUser>> GetUsersAsync()
        {
            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryAsync<SqlUser>("SELECT * FROM Users");
        }

        public async Task AddUserAsync(SqlUser user)
        {
            using var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync("INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", user);
        }
    }
}
