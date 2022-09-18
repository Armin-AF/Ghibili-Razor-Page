using WebGhibiliMaker.Models;

namespace WebGhibiliMaker.Services;

public static class CharacterService
{
    static List<Character> Characters{ get; }
    
    static int nextId = 3;

    static CharacterService(){
        Characters = new List<Character>
        {
            new Character(){SecondaryId = 1,Name = "Totoro", Gender = "Unknown", Age = "2000", EyeColor = "Black", HairColor = "Black"},
            new Character(){SecondaryId = 1,Name = "Ashitaka",Gender = "Male", Age = "25", EyeColor = "Brown", HairColor = "Brown"}
        };
    }
    
    public static List<Character> GetAll(){
        return Characters;
    }

    public static Character? Get(int id){
        return Characters.FirstOrDefault(p => p.SecondaryId == id);
    }

    public static void Add(Character character)
    {
        character.SecondaryId = nextId++;
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