using DataManager.Enums;
using DataManager.Models;
using DataManager.Services.AnimalServices;
using System.Text;


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
                Console.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("Katalog zwierząt \n" +
                          "Podaj nazwę zwierzęcia, które Cie interesuje: \n" +
                          "Powrót do Menu Głownego - wprowadź wartość \"0\". ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(sb);
                Console.ResetColor();

                string? animalName = Console.ReadLine();

                isInputNullOrEmpty(animalName);

                if (IsZero(animalName))
                    break;


                if (IsNumber(animalName))
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Zwierzę nie może być liczbą...");
                    Console.ResetColor();
                    Console.WriteLine($"Kliknij cokolwiek aby kontynuować");
                    Console.ReadKey();
                    Task task = StartAnimalMenu();
                }


                var animal = await _animalService.GetAnimalByName(animalName);

                if (animal == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie znaleziono zwierzęcia o podanej nazwie.");
                    Console.WriteLine($"Kliknij cokolwiek aby kontynuować");
                    Console.ReadKey();
                    continue;
                }
                else
                {

                    printAnimalDetails(animal);

                }

                StringBuilder sb2 = new StringBuilder();
                sb2.Append("Kliknij \"1\" aby wybrać inne zwierzę. \n" +
                           "Kliknij \"2\" aby powrócić do głównego menu \n");
                Console.WriteLine(sb2);

                string input = Console.ReadLine();

                isInputNullOrEmpty(input);

                if (!int.TryParse(input, out int userNumber2) || userNumber2 < 1 || userNumber2 > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: "Wprowadzona liczba jest nieprawidłowa.");
                    Console.WriteLine($"Kliknij cokolwiek aby kontynuować");
                    Console.ReadKey();
                    continue;
                }


                if (Enum.IsDefined(typeof(AnimalMenuOptions), userNumber2))
                {
                    switch ((AnimalMenuOptions)userNumber2)
                    {
                        case AnimalMenuOptions.AnotherAnimal:
                            continue;
                        case AnimalMenuOptions.Return:
                            isRunning = false;
                            break;

                    }
                }

            }
        }

        private void printAnimalDetails(Animal animal)
        {
            StringBuilder animalFound = new StringBuilder();
            StringBuilder animalTaksonomy = new StringBuilder();
            StringBuilder animalCharacteristics = new StringBuilder();
            animalFound.Append($"Znaleziono: {animal.Name} ({animal.Taxonomy.ScientificName})\n");

            animalTaksonomy.Append($"Królestwo: {ValidateProperty(animal.Taxonomy.Kingdom)}\n" +
                            $"Typ: {ValidateProperty(animal.Taxonomy.Phylum)}\n" +
                            $"Gromada: {ValidateProperty(animal.Taxonomy.Class)}\n" +
                            $"Rząd: {ValidateProperty(animal.Taxonomy.Order)}\n" +
                            $"Rodzina: {ValidateProperty(animal.Taxonomy.Family)}\n" +
                            $"Rodzaj: {ValidateProperty(animal.Taxonomy.Genus)}\n");

            animalCharacteristics.Append($"Dieta: {ValidateProperty(animal.Characteristics.Diet)}\n" +
                           $"Typ skóry: {ValidateProperty(animal.Characteristics.SkinType)}\n" +
                           $"Średnia życia: {ValidateProperty(animal.Characteristics.Lifespan)}\n");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(animalFound);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Taksonomia:");
            Console.ResetColor();
            Console.WriteLine(animalTaksonomy);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Charakterystyka:");
            Console.ResetColor();
            Console.WriteLine(animalCharacteristics);
        }

        private string ValidateProperty(string? property)
        {
            return string.IsNullOrEmpty(property) ? "Not in database" : property;
        }

        private bool IsZero(string? animalName)
        {
            return animalName == "0";
        }
        public bool IsNumber(string animalName)
        {
            double result;
            bool isNumeric = double.TryParse(animalName, out result);

            return isNumeric;
        }
        private void isInputNullOrEmpty(string? animalName)
        {
            if (string.IsNullOrEmpty(animalName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy.");
                Console.WriteLine($"Kliknij cokolwiek aby kontynuować");
                Console.ReadKey();
                Task task = StartAnimalMenu();
            }
        }
    }
}
