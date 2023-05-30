using HomeWork2.Models;
using HomeWork2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeWork2.Pages
{
    public class AnimalDetailsModel : PageModel
    {
        public Animal GetAnimal { get; set; }
        public void OnGet()
        {
            int animalId = int.Parse(Request.Query["animalId"].ToString());
            GetAnimal = AnimalService.GetAnimals().Single(a => a.Id == animalId);
        }
    }
}
