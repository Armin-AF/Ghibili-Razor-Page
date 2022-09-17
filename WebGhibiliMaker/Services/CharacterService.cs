using WebGhibiliMaker.Models;

namespace WebGhibiliMaker.Services;

public static class CharacterService
{
    static List<Character> Characters{ get; }
    
    static int nextId = 3;

    static CharacterService(){
        Characters = new List<Character>
        {
            new Character(){Name = "Totoro", Gender = "Unknown", Age = "2000", EyeColor = "Black", HairColor = "Black"},
            new Character(){Name = "Ashitaka",Gender = "Male", Age = "25", EyeColor = "Brown", HairColor = "Brown"}
        };
    }
    
    public static List<Character> GetAll(){
        return Characters;
    }

    public static Character? Get(){
        return Characters.FirstOrDefault();
    }

    public static void Add(Character character)
    {
        Characters.Add(character);
    }

    public static void Delete()
    {
        var character = Get();
        if (character is null)
            return;

        Characters.Remove(character);
    }

    
}