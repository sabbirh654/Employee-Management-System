using EMS.Repository.Factory;
using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EMS.Repository.Implementations;

public class OperationLogRepository : IOperationLogRepository
{
    private readonly IDatabaseFactory _databaseFactory;
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IMongoCollection<OperationLog> _operationLogs;

    public OperationLogRepository(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
        _mongoDatabase = _databaseFactory.CreateMongoDatabase();
        _operationLogs = _mongoDatabase.GetCollection<OperationLog>("OperationLogs");
    }

    public async Task AddLogAsync(OperationLog log)
    {
        await _operationLogs.InsertOneAsync(log);
    }

    public async Task<IEnumerable<OperationLog>> GetAllLogsAsync()
    {
        return await _operationLogs.Find(log => true).ToListAsync();
    }

    public async Task<OperationLog> GetLogByIdAsync(string id)
    {
        return await _operationLogs.Find(log => log.Id == new ObjectId(id)).FirstOrDefaultAsync();
    }
}
