using System.Text.Json.Serialization;

namespace Lil.Search.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}