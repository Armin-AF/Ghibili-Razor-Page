using System.Net.Http.Headers;
using System.Text.Json;
using Ghibili.MVC.Models;

namespace Ghibili.MVC.Services;

public class CharacterAPIClient :ICharacterAPIClient
{
    private IConfiguration _configuration;

    public CharacterAPIClient(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<CharacterResponse> GetCharacter(int id)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var url = $"{_configuration["ApiBaseUrl"]}/people/{id}";
        var characterTask = client.GetStreamAsync(url);
        // var jsonTask = client.GetStringAsync(url);
        // Console.WriteLine(await jsonTask);

        return await JsonSerializer.DeserializeAsync<CharacterResponse>(await characterTask);
    }
}
