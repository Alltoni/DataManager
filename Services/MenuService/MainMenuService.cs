using DataManager.Enums;
using DataManager.Infrastructure;
using DataManager.Repositories.HumanRepositories;
using DataManager.Services.HumanServices;
using DataManager.Services.MenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Services.Menus
{
    public class MainMenuService : IMainMenuService
    {
        public void StartMenu()
        {
            while (true)
            {
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
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy. \n");
                    StartMenu();
                }
                if (!int.TryParse(input, out int userNumber) || userNumber < 1 || userNumber > 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: "Wprowadzona liczba jest nieprawidłowa.\n");
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
                            // idziemy do animalMenu
                            break;
                        case MainMenuOptions.MoreInfo:
                            MoreInfo();
                            break;
                        case MainMenuOptions.Exit:
                            // wyjscie z programu, moze jakos wykorzystac klase ExitProgram z HumanMenuService
                            Environment.Exit(0);
                            break;
                        default:
                            // klasa DefaultUserChoice z HumanMenuService
                            break;

                    }
                }
            }

        }



        public void MoveToHuman()
        {
            using var dataContext = new DataManagerContext();
            bool isAppRunning = true;

            while (isAppRunning)
            {
                IHumanRepository humanRepository = new HumanRepository(dataContext);
                IHumanService humanService = new HumanService(humanRepository);
                HumanMenuService menuService = new HumanMenuService(humanService);

                menuService.StarHumantMenu();

            }
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
        }
    }
}
