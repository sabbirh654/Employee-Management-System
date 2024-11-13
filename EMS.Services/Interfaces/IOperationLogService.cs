using EMS.Repository.Models;

namespace EMS.Services.Interfaces;

public interface IOperationLogService
{
    Task LogOperationAsync(OperationLog log);
    Task<IEnumerable<OperationLog>> GetAllLogsAsync();
    Task<OperationLog> GetLogByIdAsync(string id);
}
