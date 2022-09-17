using System.Net.Http.Headers;
using System.Text.Json;
using WebGhibiliMaker.Models;


namespace WebGhibiliMaker.Services;

public class CharacterApiClient : ICharacterApiClient
{
    private IConfiguration _configuration;
    
    public CharacterApiClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    private static Task<Stream> GetHttpStreamTask(string url)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client.GetStreamAsync(url);
    }

    public async Task<Character?> GetCharacterFromSwapi(string id){
        
        var url = $"https://ghibliapi.herokuapp.com/people/{id}";
        
        var character = await JsonSerializer.DeserializeAsync<Character>(await GetHttpStreamTask(url));
        var film = await GetFilmFromSwapi(character!.FilmId);
        if (character != null){
            character.FilmName = film?.Title!;
        }
        var species = await GetSpeciesFromSwapi(character!.SpeciesId);
        if (character != null){
            character.SpeciesName = species?.Name!;
        }
        return character;
    }
    
    public async Task<IList<Character>?> GetCharactersFromSwapi(){
        
        var url = $"https://ghibliapi.herokuapp.com/people";

        return await JsonSerializer.DeserializeAsync<IList<Character>>(await GetHttpStreamTask(url));
    }

    public async Task<Film?> GetFilmFromSwapi(string id){
        var url = $"https://ghibliapi.herokuapp.com/films/{id}";
        
        return await JsonSerializer.DeserializeAsync<Film>(await GetHttpStreamTask(url)); 
    }

    public async Task<IList<Film>?> GetFilmsFromSwapi(){
        var url = $"https://ghibliapi.herokuapp.com/films";
        
        return await JsonSerializer.DeserializeAsync<IList<Film>>(await GetHttpStreamTask(url));
    }
    
    public async Task<Species?> GetSpeciesFromSwapi(string id){
        var url = $"https://ghibliapi.herokuapp.com/species/{id}";
        
        return await JsonSerializer.DeserializeAsync<Species>(await GetHttpStreamTask(url));
    }
}