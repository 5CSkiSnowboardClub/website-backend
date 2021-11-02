using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Npgsql;
using api.Common.Data;

namespace api.Dao
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ILogger<DatabaseService> _logger;
        private readonly string _connectionString;

        public DatabaseService(
            ILogger<DatabaseService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = $"Host={configuration["Database:Host"]};"
                + $"Username={configuration["Database:Username"]};"
                + $"Password={configuration["Database:Password"]};"
                + $"Database={configuration["Database:Db"]}";
        }

        public async Task<IEnumerable<MemberType>> SelectMemberTypes()
        {
            List<MemberType> members = new();

            await using NpgsqlConnection conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();

            // grab some data
            await using (var cmd = new NpgsqlCommand("SELECT * FROM member_type", conn))
            {
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    int testInt = reader.GetInt32(0);
                    string testString = reader.GetString(1);

                    members.Add(new MemberType
                    {
                        Id = reader.GetInt32(0),
                        Type = reader.GetString(1)
                    });
                }
            }

            return members;
        }
    }
}
