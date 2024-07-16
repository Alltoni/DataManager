using DataManager.Repositories;
using DataManager.Services;

namespace DataManager;

internal class Program
{
    static void Main(string[] args)
    {
        IHumanRepository humanRepository = new HumanRepository();
        IHumanService humanService = new HumanService(humanRepository);
        MenuService menuService = new MenuService(humanService);

        menuService.StartMenu();
    }
}
