namespace DataManager.Repositories
{
    // TODO: jak zmienisz lokalizacje Human.cs do Modelu lub go usuniesz to pamietaj aby zaktualizowac tutaj referencje do nich (bedize brakowal USING namespace) (na Human kliknij, potem CTRL + . )
    public interface IHumanRepository
    {
        ICollection<Human> GetHumans();
        Human GetHumanById(int id);
        Human CreateHuman(Human human);
        Human UpdateHuman(Human human);
        void DeleteHumanById(int id);
    }
}
