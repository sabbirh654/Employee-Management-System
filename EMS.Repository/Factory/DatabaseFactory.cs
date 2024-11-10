using EMS.Repository.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Npgsql;
using System.Data;

namespace EMS.Repository.Factory;

public class DatabaseFactory : IDatabaseFactory
{
    private readonly SqlServerSettings _sqlServerSettings;
    private readonly PostgreSqlSettings _postgresSettings;
    private readonly MongoDBSettings _mongoSettings;

    public DatabaseFactory(
        IOptions<SqlServerSettings> sqlServerOptions,
        IOptions<PostgreSqlSettings> postgreSqlOptions,
        IOptions<MongoDBSettings> mongoDbOptions)
    {
        _sqlServerSettings = sqlServerOptions.Value;
        _postgresSettings = postgreSqlOptions.Value;
        _mongoSettings = mongoDbOptions.Value;
    }

    public IMongoDatabase CreateMongoDatabase()
    {
        var mongoClient = new MongoClient(_mongoSettings.ConnectionString);
        return mongoClient.GetDatabase(_mongoSettings.DatabaseName);
    }

    public IDbConnection CreatePostgresSqlConnection()
    {
        return new NpgsqlConnection(_postgresSettings.ConnectionString);
    }

    public IDbConnection CreateSqlServerConnection()
    {
        return new SqlConnection(_sqlServerSettings.ConnectionString);
    }
}
