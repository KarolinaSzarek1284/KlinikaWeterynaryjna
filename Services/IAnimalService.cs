using KlinikaWeterynaryjna.Entities;
using KlinikaWeterynaryjna.Models;

namespace KlinikaWeterynaryjna.Services
{
    public interface IAnimalService
    {
        int Create(Animal animal);
        IEnumerable<Animal> GetAnimals(AnimalsQuery query);
        void Delete(int id);
        void Update(int id, Animal animal);
    }
}
