using KlinikaWeterynaryjna.Entities;
using KlinikaWeterynaryjna.Models;
using Microsoft.EntityFrameworkCore;

namespace KlinikaWeterynaryjna.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly VeterinaryMedicineContext _context;

        public AnimalService(VeterinaryMedicineContext context)
        {
            _context = context;
        }

        public int Create(Animal animal)
        {
            var newAnimal = new Animal()
            {
                Species = animal.Species,
                Breed = animal.Breed,
                Name = animal.Name,
                DateOfBirth = animal.DateOfBirth,
                Color = animal.Color,
                Size = animal.Size,
                Weight = animal.Weight,
                FirstVisit = animal.FirstVisit,
                LastVisit = animal.LastVisit,
                OwnerName = animal.OwnerName,
                OwnerPhoneNumber = animal.OwnerPhoneNumber,
            };
            _context.Add(newAnimal);
            _context.SaveChanges();

            return newAnimal.Id;
        }

        public void Delete(int id)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == id);

            if (animal is null)
                throw new Exception("Animal not found");

            _context.Remove(animal);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> GetAnimals(AnimalsQuery query)
        {
            if (!_context.Animals.Any())
                throw new Exception("Animals not found");

            var animals = _context.Animals
                .Where(a => query.SearchPhrase == null || (a.Breed.ToLower().Contains(query.SearchPhrase.ToLower())))
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            return animals;
        }

        public void Update(int id, Animal animal)
        {
            var updateAnimal = _context.Animals.FirstOrDefault(a => a.Id == id);

            if (updateAnimal is null)
                throw new Exception("Animal not found");

            updateAnimal.Name = animal.Name;
            updateAnimal.Species = animal.Species;
            updateAnimal.Breed = animal.Breed;
            updateAnimal.FirstVisit = animal.FirstVisit;
            updateAnimal.LastVisit = animal.LastVisit;
            updateAnimal.Color = animal.Color;
            updateAnimal.DateOfBirth = animal.DateOfBirth;
            updateAnimal.Size = animal.Size;
            updateAnimal.Weight = animal.Weight;
            updateAnimal.OwnerName = animal.OwnerName;
            updateAnimal.OwnerPhoneNumber = animal.OwnerPhoneNumber;

            _context.SaveChanges();
        }
    }
}
