using System.Text.Json.Serialization;

namespace Lil.Search.Models
{
    public class Order
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }
        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }
        [JsonPropertyName("total")]
        public double Total { get; set; }
        [JsonPropertyName("items")]
        public List<OrderItem> Items { get; set; }
    }
}