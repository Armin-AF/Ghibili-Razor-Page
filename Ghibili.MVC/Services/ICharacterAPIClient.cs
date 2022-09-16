using Ghibili.MVC.Models;

namespace Ghibili.MVC.Services;

public interface ICharacterAPIClient
{
    Task<CharacterResponse> GetCharacter(int id);
}