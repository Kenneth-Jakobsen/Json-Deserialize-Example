using System.Text.Json.Serialization;

namespace Rema;

public class ApiResponse
{
    [JsonPropertyName("data")]
    public List<Store> Data { get; set; }
}