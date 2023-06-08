using HomeWork2.Models;

namespace HomeWork2.Interfaces
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal Get(int id);
        void Add(Animal animal);
        void Delete(int id);
    }
}
