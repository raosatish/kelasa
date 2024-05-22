using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public abstract class EntityBase {
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }

    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }


}