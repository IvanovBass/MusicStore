using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MusicStoreAPI.Models;

namespace MusicStoreAPI.Services
{
    public class MusicServices : IMusicServices
    {
        private readonly IMongoCollection<Album> _albumCollection;

        public MusicServices(
            IOptions<AlbumStoreDataBaseSettings> albumDataBaseSettings)
        {
            var mongoClient = new MongoClient(
               albumDataBaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                albumDataBaseSettings.Value.DatabaseName);

            _albumCollection = mongoDatabase.GetCollection<Album>(
                albumDataBaseSettings.Value.AlbumCollectionName);
        }

        public async Task<List<Album>> GetAsync() =>
            await _albumCollection.Find( _=> true).ToListAsync();

        public async Task<Album?> GetAsync(string id) =>
            await _albumCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Album newAlbum) =>
            await _albumCollection.InsertOneAsync(newAlbum);

        public async Task UpdateAsync(string id, Album updatedAlbum) =>
            await _albumCollection.ReplaceOneAsync(x => x.Id == id, updatedAlbum);

        public async Task RemoveAsync(string id) =>
            await _albumCollection.DeleteOneAsync(x => x.Id == id);
    }
    public interface IMusicServices
    {
        public Task<List<Album>> GetAsync();

        public Task<Album?> GetAsync(string id);

        public Task CreateAsync(Album newAlbum);

        public Task UpdateAsync(string id, Album updatedAlbum);

        public Task RemoveAsync(string id);
    }
}

