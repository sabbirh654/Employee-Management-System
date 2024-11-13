using EMS.Repository.Interfaces;
using EMS.Repository.Models;
using EMS.Services.Interfaces;

namespace EMS.Services.Implementations;

public class OperationLogService : IOperationLogService
{
    private readonly IOperationLogRepository _repository;

    public OperationLogService(IOperationLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OperationLog>> GetAllLogsAsync()
    {
        return await _repository.GetAllLogsAsync();
    }

    public async Task<OperationLog> GetLogByIdAsync(string id)
    {
        return await _repository.GetLogByIdAsync(id);
    }

    public async Task LogOperationAsync(OperationLog log)
    {
        await _repository.AddLogAsync(log);
    }
}
