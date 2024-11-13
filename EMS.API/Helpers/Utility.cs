using EMS.Repository.Models;

namespace EMS.API.Helpers;

public static class Utility
{
    public static OperationLog CreateLogData(string operationType, string entityName, string entityId, DateTime timestamp)
    {
        return new OperationLog
        {
            OperationType = operationType,
            EntityName = entityName,
            EntityId = entityId,
            TimeStamp = timestamp
        };
    }
}
