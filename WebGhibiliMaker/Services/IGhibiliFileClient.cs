using WebGhibiliMaker.Models;

namespace WebGhibiliMaker.Services;

public interface IGhibiliFileClient
{
    Task<string> GetImageForHero(string heroId);
    
    Task<Person> ReadPersonFromFile(int id);
    
    Task<Person> WritePersonToFile(int id);
}