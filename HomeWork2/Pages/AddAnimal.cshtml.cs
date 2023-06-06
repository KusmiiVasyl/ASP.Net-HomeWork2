using HomeWork2.Models;
using HomeWork2.Services;
using HomeWork2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWork2.Pages
{
    public class AddAnimalModel : PageModel
    {
        private readonly IAnimalService _animalService;

        [BindProperty]
        public Animal InputAnimal { get; set; }

        public bool IsUpdate { get; set; }

        public AddAnimalModel(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public void OnGet()
        {
            if (int.TryParse(Request.Query["animalId"], out int animalId))
            {
                InputAnimal = _animalService.GetAll().SingleOrDefault(a => a.Id == animalId);
                IsUpdate = true;
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(InputAnimal.Name)) return Page();
            if (string.IsNullOrEmpty(InputAnimal.Sound)) return Page();

            _animalService.Add(InputAnimal);

            return RedirectToPage("/Animals");
        }
    }
}
