using DataManager.Models;
using DataManager.Repositories;


namespace DataManager.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
            => (_repository) = (repository);

        public Animal AddAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            if (string.IsNullOrWhiteSpace(animal.Name))
                throw new ArgumentException(message: $"Name cannot be empty");

            return _repository.AddAnimal(animal);
        }

        public void ClearAnimals()
        {
            throw new NotImplementedException();
        }

        public void DeleteAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Animal> GetAnimals()
        {
            throw new NotImplementedException();
        }

        public Animal UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
