using WebGhibiliMaker.Models;

namespace WebGhibiliMaker.Services;

public interface ICharacterApiClient
{
    Task<Character?> GetCharacterFromSwapi(string id);
    
    Task<IList<Character>?> GetCharactersFromSwapi();
    
    Task<Film?> GetFilmFromSwapi(string id);
    
    Task<IList<Film>?> GetFilmsFromSwapi();
    
    Task<Species?> GetSpeciesFromSwapi(string id);
}