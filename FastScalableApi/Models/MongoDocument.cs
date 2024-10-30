using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace FastScalableApi.Models
{
    public class MongoDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
