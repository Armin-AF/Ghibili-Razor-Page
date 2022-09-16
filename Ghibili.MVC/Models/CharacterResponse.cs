using System.Text.Json.Serialization;

namespace Ghibili.MVC.Models;

public class CharacterResponse
{
    [JsonPropertyName("character")]
    public Character Character { get; set; }
}