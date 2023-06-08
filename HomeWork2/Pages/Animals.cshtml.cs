using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeWork2.Models;
using HomeWork2.Interfaces;


namespace HomeWork2.Pages
{
    public class AnimalsModel : PageModel
    {
        private IAnimalRepository _animalRepository;
        public List<Animal> GetAnimals { get => _animalRepository.GetAll(); }

        public AnimalsModel(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IActionResult OnGetDelete(int id)
        {
            Animal animal = GetAnimals.SingleOrDefault(a => a.Id == id);
            if(animal != null)
            {
                _animalRepository.Delete(animal.Id);
            }
            return RedirectToPage("/Animals");
        }
    }
}
