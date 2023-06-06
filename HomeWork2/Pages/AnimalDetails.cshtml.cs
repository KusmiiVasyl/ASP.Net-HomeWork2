using HomeWork2.Models;
using HomeWork2.Services;
using HomeWork2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HomeWork2.Pages
{
    public class AnimalDetailsModel : PageModel
    {
        private readonly IAnimalService _animalService;
        public Animal GetAnimal { get; set; }

        public AnimalDetailsModel(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public void OnGet()
        {
            int animalId = int.Parse(Request.Query["animalId"].ToString());
            GetAnimal = _animalService.Get(animalId);
        }
    }
}
