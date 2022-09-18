using WebGhibiliMaker.Models;

namespace WebGhibiliMaker.Services;

public static class CharacterService
{
    static List<Person> Characters{ get; }
    
    static int nextId = 2;

    static CharacterService(){
        Characters = new List<Person>
        {
            new Person(){Id = 1, Name = "Kattioso", Description = "A cat wondering around", Image = "https://cdn.myanimelist.net/s/common/uploaded_files/1449565334-2c3628a2d2a5ee41572f3a32713461c7.gif"},
        };
    }
    
    public static List<Person> GetAll(){
        return Characters;
    }

    public static Person? Get(int id){
        return Characters.FirstOrDefault(p => p.Id == id);
    }

    public static void Add(Person character)
    {
        character.Id = nextId++;
        Characters.Add(character);
    }

    public static void Delete(int id)
    {
        var character = Get(id);
        if (character is null)
            return;

        Characters.Remove(character);
    }

    
}