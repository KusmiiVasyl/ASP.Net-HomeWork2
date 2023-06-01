using HomeWork2.Models;

namespace HomeWork2.Services
{
    public class AnimalService
    {
        private static List<Animal> _animals = new List<Animal>()
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

        public static List<Animal> GetAnimals() => _animals;

        public static void Add(Animal animal)
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
    }
}
