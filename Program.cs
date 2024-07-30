using DataManager.Infrastructure;
using DataManager.Menus;
using DataManager.Repositories.HumanRepositories;
using DataManager.Services.HumanServices;


namespace DataManager;

public class Program
{

    // TODO: Rozdzielic MenuService od Humana, aby był MenuService który kieruje do MenuHuman i MenuAnimal
    // TODO: uzupełnić klase AnimalMenuService
    // TODO:  uzupełnić klase IAnimalMenuService
    // TODO: uzupełnić klase AnimalRepository
    // TODO:  uzupełnić klase IAnimalRepository
    // TODO:  uzupełnić folder HumanRepositories


    static void Main(string[] args)
    {

        using var dataContext = new DataManagerContext();
        bool isAppRunning = true;

        while (isAppRunning)
        {
            IHumanRepository humanRepository = new HumanRepository(dataContext);
            IHumanService humanService = new HumanService(humanRepository);
            MenuService menuService = new MenuService(humanService);

            menuService.StartMenu();
        }
    }
}
