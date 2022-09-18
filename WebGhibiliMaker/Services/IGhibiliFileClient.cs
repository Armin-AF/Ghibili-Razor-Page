namespace WebGhibiliMaker.Services;

public interface IGhibiliFileClient
{
    Task<string> GetImageForHero(string heroId);
}