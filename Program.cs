using DataManager.Infrastructure;
using DataManager.Repositories;
using DataManager.Services;

namespace DataManager;

public class Program
{
    static void Main(string[] args)
    {
        using var dataContext = new DataManagerContext();
        bool isAppRunning = true;

        while (isAppRunning)
        {
            IHumanRepository humanRepository = new HumanRepository(dataContext);
            IHumanService humanService = new HumanService(humanRepository);
            IAnimalRepository animalRepository = new AnimalRepository(dataContext);
            IAnimalService animalService = new AnimalService(animalRepository);
            


            MenuService menuService = new MenuService(humanService);

            menuService.StartMenu();
        }
    }
}
