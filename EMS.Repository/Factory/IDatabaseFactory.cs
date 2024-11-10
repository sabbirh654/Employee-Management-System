using MongoDB.Driver;
using System.Data;

namespace EMS.Repository.Factory;

public interface IDatabaseFactory
{
    IDbConnection CreateSqlServerConnection();
    IDbConnection CreatePostgresSqlConnection();
    IMongoDatabase CreateMongoDatabase();
}
