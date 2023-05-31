using HomeWork2.Models;
using HomeWork2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWork2.Pages
{
    public class AddAnimalModel : PageModel
    {
        [BindProperty]
        public Animal InputAnimal { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(InputAnimal.Name)) return Page();
            if (string.IsNullOrEmpty(InputAnimal.Sound)) return Page();
            AnimalService.AddAnimal(InputAnimal.Name, InputAnimal.Sound);
            return RedirectToPage("/Animals");
        }
    }
}
