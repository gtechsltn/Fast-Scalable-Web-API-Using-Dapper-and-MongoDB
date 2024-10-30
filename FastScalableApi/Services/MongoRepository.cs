using FastScalableApi.Data;
using FastScalableApi.Models;
using MongoDB.Driver;

namespace FastScalableApi.Services
{
    public class MongoRepository
    {
        private readonly IMongoCollection<MongoDocument> _collection;

        private readonly MongoDbContext _mongoDbContext;
        public MongoRepository(MongoDbContext mongoDbContext)
        {       
            _mongoDbContext = mongoDbContext;
            _collection = _mongoDbContext.GetCollection<MongoDocument>("products");
        }

        public async Task<IEnumerable<MongoDocument>> GetDocumentsAsync()
        {
            return await _collection.Find(Builders<MongoDocument>.Filter.Empty).ToListAsync();
        }

        public async Task AddDocumentAsync(MongoDocument document)
        {
            await _collection.InsertOneAsync(document);
        }
    }
}
