using DataManager.Enums;
using DataManager.Models;
using DataManager.Services.AnimalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataManager.Services.MenuService.AnimalMenuService
{
    public class AnimalMenu : IAnimalMenu
    {
        private readonly IAnimalService _animalService;

        public AnimalMenu(IAnimalService animalService)
        {
            _animalService = animalService ?? throw new ArgumentNullException(nameof(animalService));
        }

        public async Task StartAnimalMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                // Console.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Katalog zwierząt \n" +
                          "Podaj nazwę zwierzęcia, które Cie interesuje: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(sb);
                Console.ResetColor();

                string? animalName = Console.ReadLine();
                if (string.IsNullOrEmpty(animalName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy. \n");
                    continue;

                }


                if (int.TryParse(animalName, out int userNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Zwierzę nie może być liczbą... \n");
                    Console.ResetColor();
                    continue;

                }
                //Działa tylko jeden raz xd pozniej nie wyszukuje zwierzecia
                var animal = await _animalService.GetAnimalByName(animalName);
                if (animal == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie znaleziono zwierzęcia o podanej nazwie.\n");
                    continue;
                }
                Console.WriteLine($"Znaleziono: {animal.Name} ({animal.Taxonomy.ScientificName})");


                StringBuilder sb2 = new StringBuilder();
                sb2.Append("Kliknij \"1\" aby wyświetlić taksonomie wybranego zwierzęcia. \n" +
                           "Kliknij \"2\" aby wyświetlić charakterystyke wybranego zwierzęcia. \n" +
                           "Kliknij \"3\" aby wybrać inne zwierzę. \n" +
                           "Kliknij \"4\" aby powrócić do głównego menu \n");

                Console.WriteLine(sb2);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy. \n");
                    continue;
                }

                if (!int.TryParse(input, out int userNumber2) || userNumber2 < 1 || userNumber2 > 5)
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
                            ShowTaxonomy(animal.Taxonomy);
                            break;
                        case AnimalMenuOptions.Characteristic:
                            ShowCharacteristic(animal.Characteristics);
                            break;
                        case AnimalMenuOptions.AnotherAnimal:
                            continue;
                        case AnimalMenuOptions.Return:
                            isRunning = false;
                            break;

                    }
                }

            }
        }

        

        private void ShowTaxonomy(Taxonomy taxonomy)
        {
            Console.WriteLine($"Królestwo: {taxonomy.Kingdom}");
            Console.WriteLine($"Typ: {taxonomy.Phylum}");
            Console.WriteLine($"Gromada: {taxonomy.Class}");
            Console.WriteLine($"Rząd: {taxonomy.Order}");
            Console.WriteLine($"Rodzina: {taxonomy.Family}");
            Console.WriteLine($"Rodzaj: {taxonomy.Genus}");
            Console.WriteLine($"Nazwa naukowa: {taxonomy.ScientificName}");
        }

        //TODO: charakterystyka nie dziala
        private void ShowCharacteristic(Characteristics characteristics)
        {
            Console.WriteLine($"Pożywienie: {characteristics.Prey}");
            Console.WriteLine($"Nazwa młodych: {characteristics.NameOfYoung}");
            Console.WriteLine($"Zachowanie grupowe: {characteristics.GroupBehavior}");
            
        }
    }


}
