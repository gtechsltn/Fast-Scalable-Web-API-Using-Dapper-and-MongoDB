using FastScalableApi.Models;

namespace FastScalableApi.Services
{
    public class UserService
    {
        private readonly SqlRepository _sqlRepository;
        private readonly MongoRepository _mongoRepository;

        public UserService(SqlRepository sqlRepository, MongoRepository mongoRepository)
        {
            _sqlRepository = sqlRepository;
            _mongoRepository = mongoRepository;
        }

        public async Task<IEnumerable<SqlUser>> GetSqlUsersAsync() => await _sqlRepository.GetUsersAsync();

        public async Task<IEnumerable<MongoDocument>> GetMongoDocumentsAsync() => await _mongoRepository.GetDocumentsAsync();

        public async Task AddSqlUserAsync(SqlUser user) => await _sqlRepository.AddUserAsync(user);

        public async Task AddMongoDocumentAsync(MongoDocument document) => await _mongoRepository.AddDocumentAsync(document);
    }
}
