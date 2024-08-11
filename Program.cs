using DataManager.Infrastructure;
using DataManager.Repositories.AnimalRepositories;
using DataManager.Services.AnimalServices;
using DataManager.Services.MenuService.AnimalMenuService;
using DataManager.Services.MenuService.MainMenuService;


namespace DataManager;

public class Program
{


    static async Task Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();
        await mainMenu.StartMenu();


    }


}
