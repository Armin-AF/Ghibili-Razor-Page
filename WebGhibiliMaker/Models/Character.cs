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
    
    [JsonPropertyName("films")]
    public string[] Films { get; set; }
    
    [JsonPropertyName("filmNames")]
    public string FilmName { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("species")]
    public string Species { get; set; }
   
    public string SpeciesName { get; set; }
    
    public string Image { get; set; }

    public string? FilmId => GetIdFromSwAPIUrl(Films[0]);
    public string? SpeciesId => GetIdFromSwAPIUrl(Species);
    public int SecondaryId{ get; set; }

    public string GetIdFromSwAPIUrl(string url)
    {
        var urlString = url.EndsWith('/') ? url.Remove(url.Length - 1, 1) : url;
        var idString = urlString.Remove(0, urlString.LastIndexOf('/') + 1);
        
        return idString;
    }
}