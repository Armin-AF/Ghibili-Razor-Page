using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGhibiliMaker.Models;
using WebGhibiliMaker.Services;

namespace WebGhibiliMaker.Pages;

public class CharacterModel : PageModel
{
    public List<Character> Characters = new();
    
    [BindProperty]
    public Character NewCharacter { get; set; } = new();

    public void OnGet()
    {
        Characters = CharacterService.GetAll();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        CharacterService.Add(NewCharacter);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id)
    {
        CharacterService.Delete(id);
        return RedirectToAction("Get");
    }
}