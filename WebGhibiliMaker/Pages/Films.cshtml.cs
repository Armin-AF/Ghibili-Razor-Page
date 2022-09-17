using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGhibiliMaker.Models;
using WebGhibiliMaker.Services;

namespace WebGhibiliMaker.Pages;

public class FilmsModel : PageModel
{
    private readonly ICharacterApiClient _characterApiService;
    
        public FilmsModel(ICharacterApiClient characterAPIService) => _characterApiService = characterAPIService;
    
        [BindProperty]
        public IList<Film>? FilmList { get; set; }
    
        [BindProperty]
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGet(){
            FilmList = await _characterApiService.GetFilmsFromSwapi();
            return Page();
        }
}