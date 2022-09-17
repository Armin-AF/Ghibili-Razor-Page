using System.Text.Json.Serialization;

namespace WebGhibiliMaker.Models;

public class Film
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; }
    
    [JsonPropertyName("original_title_romanised")]
    public string OriginalTitleRomanised { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("director")]
    public string Director { get; set; }
    
    [JsonPropertyName("producer")]
    public string Producer { get; set; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    
    [JsonPropertyName("running_time")]
    public string RunningTime { get; set; }
    
    [JsonPropertyName("rt_score")]
    public string RtScore { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
}