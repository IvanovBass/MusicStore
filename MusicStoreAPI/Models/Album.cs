using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MusicStoreAPI.Models
{
    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nom")]
        [JsonPropertyName("Nom")]
        public string Nom { get; set; } = null!;

        [BsonElement("Artiste")]
        [JsonPropertyName("Artiste")]
        public string Artiste { get; set; } = null!;

        [BsonElement("Annee")]
        [JsonPropertyName("Annee")]
        public int Annee { get; set; }
    }
}
