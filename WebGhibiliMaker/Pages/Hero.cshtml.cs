using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGhibiliMaker.Models;
using WebGhibiliMaker.Services;

namespace WebGhibiliMaker.Pages;

public class HeroModel : PageModel
{
    private readonly ICharacterApiClient _characterAPIService;

    public HeroModel(ICharacterApiClient characterApiService) => _characterAPIService = characterApiService;

    [BindProperty]
    public Character? Character { get; set; }

    [BindProperty]
    public string ErrorMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        Character = null;
        try
        {
            Character = await _characterAPIService.GetCharacterFromSwapi(id);
        }
        catch (System.Exception ex)
        {
            ErrorMessage = $"Could not show hero ({ex.Message})";
        }
        return Page();
    }
}