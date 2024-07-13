using DataManager.Models;
using DataManager.Repositories;
namespace DataManager.Services

{
    public class HumanService : IHumanService
    {
        private readonly IHumanRepository _repository;

        public HumanService(IHumanRepository repository)
        {
            _repository = repository;
        }

        public Human AddHuman(Human human)
        {
            if (human == null)
            {
                throw new ArgumentNullException(nameof(human));
            }

            if (string.IsNullOrWhiteSpace(human.Name) || string.IsNullOrWhiteSpace(human.Surname))
            {
                throw new ArgumentException("Name and Surname cannot be empty");
            }

            return _repository.AddHuman(human);

        }

        // DONE: pobierz rekord z repozytorium o konkretnym id po czym go usuń
        public void DeleteHumanById(int id)
        {
            _repository.DeleteHumanById(id);
        }

        // DONE: pobierz konkretny rekord o takim ID
        public Human GetHumanById(int id)
        {
            return _repository.GetHumanById(id);
        }

        // DONE: pobierz wszystkich ludzi skurwysynów
        public ICollection<Human> GetHumans()
        {
            return _repository.GetHumans();
        }

        // DONE: zaktualizuj czlwoeiczka
        public Human UpdateHuman(Human human)
        {
            return _repository.UpdateHuman(human);
        }

        public void ClearHumans()
        {
            var humans = _repository.GetHumans().ToList();
            foreach (var human in humans)
            {
                _repository.DeleteHumanById(human.Id);
            }
        }
    }
}