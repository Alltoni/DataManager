namespace DataManager.Repositories
{
    // TODO: zrób odzielna klase gdzie zaMOCK'ujesz dane (zrobisz sztuczne dane np jakas liste z Humanami)
    public class HumanRepository : IHumanRepository
    {
        // TODO: dodaj humana do listy
        public Human CreateHuman(Human human)
        {
            throw new NotImplementedException();
        }


        // TODO: usun humana z listy
        public void DeleteHumanById(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: pobierz humana z listy po id
        public Human GetHumanById(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: pobierz wszystkich humanów ( cala liste )
        public ICollection<Human> GetHumans()
        {
            throw new NotImplementedException();
        }

        // TODO: zaktualizuj rekord gdzie id == twojemu wrzuconemu
        public Human UpdateHuman(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
