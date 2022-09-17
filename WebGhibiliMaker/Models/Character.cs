using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebGhibiliMaker.Models;

public class Character
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
    
    [JsonPropertyName("age")]
    public string Age { get; set; }
    
    [JsonPropertyName("eye_color")]
    public string EyeColor { get; set; }
    
    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; }
}