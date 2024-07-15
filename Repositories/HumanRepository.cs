using DataManager.Models;


namespace DataManager.Repositories
{
    // DONE: zrób odzielna klase gdzie zaMOCK'ujesz dane (zrobisz sztuczne dane np jakas liste z Humanami)
    public class HumanRepository : IHumanRepository
    {
        private readonly List<Human> _humans = new List<Human>();

        // DONE: pobierz wszystkich humanów ( cala liste )
        public ICollection<Human> GetHumans()
        {
            return _humans;

        }

        // DONE: dodaj humana do listy
        public Human AddHuman(Human human)
        {
            _humans.Add(human);
            return human;
        }

        // DONE: usun humana z listy
        public void DeleteHumanById(int id)
        {
            var human = GetHumanById(id);
            if (human != null)
            {
                _humans.Remove(human);
            }
        }

        // DONE: pobierz humana z listy po id
        public Human GetHumanById(int id)
        {
            return _humans.FirstOrDefault(h => h.Id == id);
        }

        // DONE: zaktualizuj rekord gdzie id == twojemu wrzuconemu
        // 
        public Human UpdateHuman(Human human)
        {
            var existingHuman = GetHumanById(human.Id);

            if (existingHuman == null)
            {
                throw new Exception(message: $"Human with this id already exists.");
            }


            if (existingHuman != null)
            {
                existingHuman.Name = human.Name;
                existingHuman.Surname = human.Surname;
                existingHuman.Description = human.Description;
            }
            return existingHuman;
        }


    }
}


