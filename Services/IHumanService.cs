using DataManager.Models;

namespace DataManager.Services
{
    public interface IHumanService
    {
        ICollection<Human> GetHumans();
        Human GetHumanById(int id);
        Human CreateHuman(Human human);
        Human UpdateHuman(Human human);
        void DeleteHumanById(int id);
    }
}
