using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EMS.Repository.Models;

public class OperationLog
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string OperationType { get; set; } = null!;
    public string EntityName { get; set; } = null!;
    public string EntityId { get; set; } = null!;
    public DateTime TimeStamp { get; set; }
}
