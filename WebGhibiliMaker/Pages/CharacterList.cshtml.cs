using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGhibiliMaker.Models;
using WebGhibiliMaker.Services;

namespace WebGhibiliMaker.Pages;

public class CharacterListModel : PageModel
{
    private readonly ICharacterApiClient _characterApiService;

    public CharacterListModel(ICharacterApiClient characterAPIService) => _characterApiService = characterAPIService;

    [BindProperty]
    public IList<Character>? CharacterList { get; set; }

    [BindProperty]
    public string ErrorMessage { get; set; }
    public async Task<IActionResult> OnGet(){
        CharacterList = await _characterApiService.GetCharactersFromSwapi();
        return Page();
    }
}