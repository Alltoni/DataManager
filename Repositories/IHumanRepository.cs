using DataManager.Models;

namespace DataManager.Repositories;

public interface IHumanRepository
{
    ICollection<Human> GetHumans();
    Human GetHumanById(int id);
    Human AddHuman(Human human);
    Human UpdateHuman(Human human);
    void DeleteHumanById(int id);
}
