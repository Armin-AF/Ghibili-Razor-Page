using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGhibiliMaker.Models;
using WebGhibiliMaker.Services;
using System.Linq;

namespace WebGhibiliMaker.Pages;

public class FilmsModel : PageModel
{
    private readonly ICharacterApiClient _characterApiService;
    public string NameSort { get; set; }

    
        public FilmsModel(ICharacterApiClient characterAPIService) => _characterApiService = characterAPIService;
    
        [BindProperty]
        public IList<Film>? FilmList { get; set; }
    
        [BindProperty]
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGet(){
            FilmList = await _characterApiService.GetFilmsFromSwapi();
            return Page();
        }

        /*public async Task OnGetAsync(string sortOrder){
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            IQueryable<Film> films = _characterApiService.GetFilmsFromSwapi().Result.AsQueryable();
            switch (sortOrder){
                case "name_desc":
                    films = films.OrderByDescending(f => f.Title);
                    break;
                default:
                    films = films.OrderBy(f => f.Title);
                    break;
            }
        }*/
}