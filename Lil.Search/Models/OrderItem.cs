using System.Text.Json.Serialization;

namespace Lil.Search.Models
{
    public class OrderItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }
        [JsonPropertyName("productId")]
        public string ProductId { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("product")]
        public Product Product { get; set; }
    }
}