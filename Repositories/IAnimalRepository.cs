
using DataManager.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DataManager.Repositories
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAnimals();

        Animal AddAnimal(Animal animal);

        Animal UpdateAnimal(Animal animal);

        Animal GetAnimalById(int id);

        void DeleteAnimalById(int id);
    }
}
