using DataManager.Enums;
using DataManager.Services.AnimalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Services.MenuService
{
    public class AnimalMenu //: IAnimalMenu
    {


        public void StartAnimalMenu()
        {
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Katalog zwierząt \n" +
                          "Podaj nazwę zwierzęcia, które Cie interesuje: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(sb);
                Console.ResetColor();

                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy. \n");
                    continue;

                }

                if (int.TryParse(input, out int userNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Zwierzę nie może być liczbą... \n");
                    Console.ResetColor();
                    continue;

                }
                //TODO: ogarnać to
                AnimalService animalService = new AnimalService();
                animalService.AnimalScan(input);

                StringBuilder sb2 = new StringBuilder();
                sb2.Append("Kliknij \"1\" aby wyświetlić taksonomie wybranego zwierzęcia. \n" +
                           "Kliknij \"2\" aby wyświetlić charakterystyke wybranego zwierzęcia. \n" +
                           "Kliknij \"3\" aby wybrać inne zwierzę. \n" +
                           "Kliknij \"4\" aby powrócić do głównego menu \n");

                Console.WriteLine(sb2);
                string? input2 = Console.ReadLine();

                if (string.IsNullOrEmpty(input2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy. \n");
                    continue;
                }

                if (!int.TryParse(input2, out int userNumber2) || userNumber2 < 1 || userNumber2 > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: "Wprowadzona liczba jest nieprawidłowa.\n");
                    continue;
                }


                if (Enum.IsDefined(typeof(AnimalMenuOptions), userNumber2))
                {
                    switch ((AnimalMenuOptions)userNumber2)
                    {
                        case AnimalMenuOptions.Taksonomy:
                            ShowTaksonomy();
                            break;
                        case AnimalMenuOptions.Characteristic:
                            ShowCharacteristic();
                            break;
                        case AnimalMenuOptions.AnotherAnimal:
                            StartAnimalMenu();
                            break;
                        case AnimalMenuOptions.Return:
                            ReturnToMainMenu();
                            break;

                    }
                }

            }
        }
        //TODO: uzupełnic metody
        private void ReturnToMainMenu()
        {
            throw new NotImplementedException();
        }

        private void ShowCharacteristic()
        {
            throw new NotImplementedException();
        }

        private void ShowTaksonomy()
        {
            throw new NotImplementedException();
        }
    }


}
