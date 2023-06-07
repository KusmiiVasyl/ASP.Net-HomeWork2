using HomeWork2.Models;
using HomeWork2.Interfaces;

namespace HomeWork2.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private List<Animal> _animals = new List<Animal>()
        {
            new Animal()
                {
                    Id = 1,
                    Name = "Dog",
                    Sound = "Woof-woof"
                },
                new Animal()
                {
                    Id = 2,
                    Name = "Cat",
                    Sound = "Miaw-miaw"
                },
                new Animal()
                {
                    Id = 3,
                    Name = "Cow",
                    Sound = "My-y-y-y"
                },
                new Animal()
                {
                    Id = 4,
                    Name = "Frog",
                    Sound = "Kwa-kwa"
                }
        };

        public List<Animal> GetAll() => _animals;

        public Animal Get(int id) => _animals.Single(a => a.Id == id);

        public void Add(Animal animal)
        {
            Animal existingAnimal = _animals.FirstOrDefault(a => a.Id == animal.Id);        
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Sound = animal.Sound;
            }
            else
            {
                _animals.Add(new Animal()
                {
                    Id = _animals.Count + 1,
                    Name = animal.Name,
                    Sound = animal.Sound
                });
            }
        }

        public void Delete(Animal animal)
        {
            Animal animalToDelete = _animals.FirstOrDefault(a => a.Id == animal.Id);
            if(animalToDelete != null)
            {
                _animals.Remove(animal);
            }
        }
    }
}
