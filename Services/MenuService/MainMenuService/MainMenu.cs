using DataManager.Enums;
using DataManager.Infrastructure;
using DataManager.Repositories.AnimalRepositories;
using DataManager.Repositories.HumanRepositories;
using DataManager.Services.AnimalServices;
using DataManager.Services.HumanServices;
using DataManager.Services.MenuService.AnimalMenuService;
using DataManager.Services.MenuService.HumanMenuService;
using System.Text;

namespace DataManager.Services.MenuService.MainMenuService
{
    public class MainMenu : IMainMenu
    {
        bool isRunning = true;

        public async Task StartMenu()
        {

            while (isRunning)
            {
                Console.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Witaj w naszej aplikacji! \n" +
                          "Kliknij \"1\" aby przejść do Bazy danych \"Human\". \n" +
                          "Kliknij \"2\" aby przejśc do Katalogu zwierząt. \n" +
                          "Kliknij \"3\" aby wyświetlić więcej informacji na temat aplikacji. \n" +
                          "Kliknij \"4\" aby zamknąć aplikację.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sb);
                Console.ResetColor();

                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy.");
                    Console.WriteLine($"Kliknij cokolwiek aby kontynuować");
                    Console.ReadKey();
                    continue;
                }
                if (!int.TryParse(input, out int userNumber) || userNumber < 1 || userNumber > 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: "Wprowadzona liczba jest nieprawidłowa.");
                    Console.WriteLine($"Kliknij cokolwiek aby kontynuować");
                    Console.ReadKey();
                    continue;

                }

                if (Enum.IsDefined(typeof(MainMenuOptions), userNumber))
                {
                    switch ((MainMenuOptions)userNumber)
                    {
                        case MainMenuOptions.MoveToHuman:
                            MoveToHuman();
                            break;
                        case MainMenuOptions.MoveToAnimal:
                            await MoveToAnimal();
                            break;
                        case MainMenuOptions.MoreInfo:
                            MoreInfo();
                            break;
                        case MainMenuOptions.Exit:
                            isRunning = false;
                            break;
                        default:
                            break;

                    }
                }
            }

        }



        public void MoveToHuman()
        {
            using var dataContext = new DataManagerContext();
            IHumanRepository humanRepository = new HumanRepository(dataContext);
            IHumanService humanService = new HumanService(humanRepository);
            HumanMenu menuService = new HumanMenu(humanService);

            menuService.StartHumanMenu();
        }

        private async Task MoveToAnimal()
        {
            using var dataContext = new DataManagerContext();
            IAnimalRepository animalRepository = new AnimalRepository(dataContext);
            IAnimalService animalService = new AnimalService(animalRepository);

            AnimalMenu animalMenu = new AnimalMenu(animalService);
            await animalMenu.StartAnimalMenu();
        }


        private void MoreInfo()
        {
            StringBuilder moreInfo = new StringBuilder();
            moreInfo.Append("W bazie danych Human mozesz dodać," +
               " usnąć, wyświetlnić informacje o dodancyh ludziach \n" +
               "w katologu zwierząt możesz wyszukać dodatkowe informacje o" +
               "interesującym Cie zwierzęciu.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(moreInfo);
            Console.ResetColor();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do głównego menu...");
            Console.ReadKey();
        }
    }
}
