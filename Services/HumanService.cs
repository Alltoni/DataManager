namespace DataManager.Services
{
    // TODO: utwórz konstruktor, wstrzyknij do niego IHumanRepository, utworz pole (field) dla ktorego przypiszesz to. Jak coś yptaj
    public class HumanService : IHumanService
    {
        // TODO: utwórz ciało humana lub przypisz z jakas logika ktora uwazasz za słuszna (walidacje itp itd) potem przekaz to ciało do metody uzywajac wstrzyknietego interfejsu _repository.CreateHuman(ciałoHumana)
        public Human CreateHuman(Human human)
        {
            throw new NotImplementedException();
        }

        // TODO: pobierz rekord z repozytorium o konkretnym id po czym go usuń
        public void DeleteHumanById(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: pobierz konkretny rekord o takim ID
        public Human GetHumanById(int id)
        {
            throw new NotImplementedException();
        }

        // TODO: pobierz wszystkich ludzi skurwysynów
        public ICollection<Human> GetHumans()
        {
            throw new NotImplementedException();
        }

        // TODO: zaktualizuj czlwoeiczka
        public Human UpdateHuman(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
