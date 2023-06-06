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
            _animalRepository.Add(animal);
        }
    }
}
