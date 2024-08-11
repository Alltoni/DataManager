using DataManager.Models;
using DataManager.Repositories.AnimalRepositories;


namespace DataManager.Services.AnimalServices
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
            => _repository = repository;

        public async Task<Animal?> GetAnimalByName(string name)
        {
            return await _repository.GetAnimalByName(name);
        }

        public async Task<Taxonomy?> GetAnimalTaxonomy(string name)
        {
            var animal = await _repository.GetAnimalByName(name);
            return animal?.Taxonomy;
        }

        public async Task<Characteristics?> GetAnimalCharacteristics(string name)
        {
            var animal = await _repository.GetAnimalByName(name);
            return animal?.Characteristics;
        }
    }
}
