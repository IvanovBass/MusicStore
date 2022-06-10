namespace MusicStoreAPI.Models
{
    public class AlbumStoreDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AlbumCollectionName { get; set; } = null!;
    }
}
