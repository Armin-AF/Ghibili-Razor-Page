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
        
        return await JsonSerializer.DeserializeAsync<Character>(await GetHttpStreamTask(url));
    }
    
    public async Task<IList<Character>?> GetCharactersFromSwapi(){
        
        var url = $"https://ghibliapi.herokuapp.com/people";
        
        return await JsonSerializer.DeserializeAsync<IList<Character>>(await GetHttpStreamTask(url));
    }
}