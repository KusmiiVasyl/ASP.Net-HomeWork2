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

        public bool IsUpdate { get; set; }

        public void OnGet()
        {
            if (int.TryParse(Request.Query["animalId"], out int animalId))
            {
                InputAnimal = AnimalService.GetAnimals().SingleOrDefault(a => a.Id == animalId);
                IsUpdate = true;
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(InputAnimal.Name)) return Page();
            if (string.IsNullOrEmpty(InputAnimal.Sound)) return Page();
            
            AnimalService.Add(InputAnimal);

            return RedirectToPage("/Animals");
        }
    }
}
