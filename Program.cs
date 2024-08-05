using DataManager.Infrastructure;
using DataManager.Repositories.HumanRepositories;
using DataManager.Services.HumanServices;
using DataManager.Services.AnimalServices;
using DataManager.Repositories.AnimalRepositories;
using System.Text;
using System.Threading.Channels;
using DataManager.Services.Menus;


namespace DataManager;

public class Program
{
    //static async Task Main(string[] args)
    //{
    //    await AnimalService.AnimalScan(args);
    //}

    static void Main(string[] args)
    {
        MainMenuService mainMenu = new MainMenuService();
        mainMenu.StartMenu();

        //using var dataContext = new DataManagerContext();
        //bool isAppRunning = true;


        //while (isAppRunning)
        //{
        //    IHumanRepository humanRepository = new HumanRepository(dataContext);
        //    IHumanService humanService = new HumanService(humanRepository);
        //    MenuService menuService = new MenuService(humanService);

        //    menuService.StartMenu();
        //}
    }


}
