using DataManager.Models;

namespace DataManager.Services.HumanServices;

public interface IHumanService
{
    ICollection<Human> GetHumans();
    Human GetHumanById(int id);
    Human AddHuman(Human human);
    Human UpdateHuman(Human human);
    void DeleteHumanById(int id);

    public void ClearHumans();
}
