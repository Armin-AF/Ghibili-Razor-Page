using System.Text.Json.Serialization;

namespace WebGhibiliMaker.Models;

public class Species
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("classification")]
    public string Classification { get; set; }
}