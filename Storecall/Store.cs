using System.Text.Json.Serialization;

namespace Rema;

public class Store
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("group")]
    public string Group { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("Fax")]
    public string Fax { get; set; }
    public string Logo { get; set; }
    public string Website { get; set; }
}