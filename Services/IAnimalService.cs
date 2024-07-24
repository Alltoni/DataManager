using DataManager.Models;


namespace DataManager.Services
{
    public interface IAnimalService
    {
        ICollection<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        Animal AddAnimal(Animal animal);
        Animal UpdateAnimal(Animal animal);
        void DeleteAnimalById(int id);

        public void ClearAnimals();
    }
}
