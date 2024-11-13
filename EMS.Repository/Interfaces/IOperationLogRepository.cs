using EMS.Repository.Models;

namespace EMS.Repository.Interfaces;

public interface IOperationLogRepository
{
    Task AddLogAsync(OperationLog log);
    Task<IEnumerable<OperationLog>> GetAllLogsAsync();
    Task<OperationLog> GetLogByIdAsync(string id);
}
