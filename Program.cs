using DataManager.Infrastructure;
using DataManager.Menus;
using DataManager.Repositories.HumanRepositories;
using DataManager.Services.HumanServices;
using DataManager.Services.AnimalServices;
using DataManager.Repositories.AnimalRepositories;


namespace DataManager;

public class Program
{
    static async Task Main(string[] args)
    {
        await AnimalService.AnimalScan(args);
    }

    //static void Main(string[] args)
    //{

    //    using var dataContext = new DataManagerContext();
    //    bool isAppRunning = true;


    //    //while (isAppRunning)
    //    //{
    //    //    IHumanRepository humanRepository = new HumanRepository(dataContext);
    //    //    IHumanService humanService = new HumanService(humanRepository);
    //    //    MenuService menuService = new MenuService(humanService);

    //    //    menuService.StartMenu();
    //    //}
    //}
}
