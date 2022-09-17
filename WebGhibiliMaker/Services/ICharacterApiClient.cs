using WebGhibiliMaker.Models;

namespace WebGhibiliMaker.Services;

public interface ICharacterApiClient
{
    Task<Character?> GetCharacterFromSwapi(string id);
    
    Task<IList<Character>> GetCharactersFromSwapi();
}