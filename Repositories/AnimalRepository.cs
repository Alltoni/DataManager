using DataManager.Infrastructure;
using DataManager.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataManager.Repositories;

public class AnimalRepository : IAnimalRepository
{
    public AnimalRepository(DataManagerContext context)
    {
        _context = context;
    }

    private readonly DataManagerContext _context;

    public ICollection<Animal> GetAnimals() => _context.Animals.ToList();
    public Animal AddAnimal(Animal animal)
    {
        var animalList = GetAnimals();

        _context.Animals.Add(animal);
        _context.SaveChanges();

        return animal;
    }
    public Animal GetAnimalById(int id)
    {
        var animals = GetAnimals;

        return animals.First(a => a.Id == id);
    }

    public Animal UpdateAnimal(Animal animal)
    {
        var existingAnimal = GetAnimalById(animal.Id);

        if (existingAnimal == null)
            throw new ArgumentException(message: $"Animal with this id \"{animal.Id}\" already exists.");

        existingAnimal.Name = animal.Name;
      

        _context.Update(existingAnimal);
        _context.SaveChanges();

        return existingAnimal;
    }

    public void DeleteAnimalById(int id)
    {
        var animal = GetAnimalById(id);

        if (animal == null)
            throw new ArgumentNullException(paramName: "id", message: $"There's no animal with id: \"{id}\".");

        _context.Remove(animal);
        _context.SaveChanges();
    }






}
