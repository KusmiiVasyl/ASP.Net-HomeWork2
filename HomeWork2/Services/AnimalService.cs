using HomeWork2.Models;
using HomeWork2.Interfaces;

namespace HomeWork2.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public List<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public Animal Get(int id) { return _animalRepository.Get(id); }

        public void Add(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Name)|| string.IsNullOrEmpty(animal.Sound)) return;
            _animalRepository.Add(animal);
        }

        public void Delete(int id)
        {
            Animal animalToDelete= _animalRepository.Get(id);
            if (animalToDelete == null)
            {
                return;
            }

            _animalRepository.Delete(animalToDelete);
        }

 /*       public List<Animal> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return new List<Animal>();
            }

            return _animalRepository.Search(searchTerm);
        }*/

    }
}
