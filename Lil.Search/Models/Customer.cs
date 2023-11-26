using System.Text.Json.Serialization;

namespace Lil.Search.Models
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}