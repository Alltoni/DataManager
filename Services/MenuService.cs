using System.Text;
using DataManager.Models;

// TODO potrzebuje dziedziczenia po IMenuService i implementacji jego metod
namespace DataManager.Services
{
    internal class MenuService
    {
        enum MenuOption
        {
            Add = 1,
            Delete = 2,
            View = 3,
            Clear = 4,
            Exit = 5,
        }

        private readonly IHumanService _humanService;
        public MenuService(IHumanService humanService)
        {
            _humanService = humanService;
        }

        public void StartMenu()
        {

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("1 - dodaj na liste \n" +
                          "2 - usuń z listy \n" +
                          "3 - wyświetl liste \n" +
                          "4 - wyczyść liste \n" +
                          "5 - zamknij program \n");
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


                if (!int.TryParse(input, out int userNumber) || userNumber < 1 || userNumber > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wprowadzona liczba jest nieprawidłowa.\n");
                    continue;
                }
                if (Enum.IsDefined(typeof(MenuOption), userNumber))
                {
                    // TODO: Możesz to bezposrednio wstrzyknąć do switcha (MenuOption)userNumber
                    MenuOption selectedOption = (MenuOption)userNumber;

                    switch (selectedOption)
                    {
                        case MenuOption.Add:
                            AddHuman();
                            break;
                        case MenuOption.Delete:
                            DeleteHuman();
                            break;
                        case MenuOption.View:
                            ViewHumans();
                            break;
                        case MenuOption.Clear:
                            ClearHumans();
                            break;
                        case MenuOption.Exit:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Zamykanie programu...");
                            Console.ResetColor();
                            return;
                    }
                }
            }
        }

        private void AddHuman()
        {
            // TODO: mozesz zrobic metode pomocnicza która ebdize tylko dla tej klasy i bedzie ona odpowiadal np za tekstDoWypisania + wprowadzenie warotści ( zasada DRY (Don't repeat yourself)
            Console.Write("Podaj Id: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int idNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id musi być liczbą!\n");
                Console.ResetColor();
                return;
            }
            Console.Write("Podaj imię: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Imię nie może być puste!\n");
                Console.ResetColor();
                return;
            }
            Console.Write("Podaj nazwisko: ");
            string? surname = Console.ReadLine();
            if (string.IsNullOrEmpty(surname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nazwisko nie może być puste!\n");
                Console.ResetColor();
                return;
            }

            Console.Write("Podaj opis (opcjonalny): ");
            string? description = Console.ReadLine();

            var human = new Human(idNumber, name, surname, description);
            _humanService.AddHuman(human);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Osoba została dodana do listy.\n");
            Console.ResetColor();
        }

        private void DeleteHuman()
        {
            Console.Write("Podaj Id osoby, którą chcesz usunąć z listy: ");
            string? deleteInput = Console.ReadLine();
            if (!int.TryParse(deleteInput, out int idToDelete))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID musi być liczbą!\n");
                Console.ResetColor();
                return;
            }

            try
            {
                _humanService.DeleteHumanById(idToDelete);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pomyslnie usunięto z listy.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }

        private void ViewHumans()
        {
            var humans = _humanService.GetHumans();
            foreach (var human in humans)
            {
                // TODO "verbatim string literal (@)" uzywamy czesto zeby wyrazeenie zapisac jak ponizej bez koniecznosci uzywania backslashy oraz najczesciej do ścieżek plików lub url
                Console.WriteLine(@$"ID: {human.Id},
                                            Name: {human.Name},
                                            Surname: {human.Surname}, 
                                            Description: {human.Description ?? "No description"}");
                Console.WriteLine("");
            }
        }
        private void ClearHumans()
        {
            _humanService.ClearHumans();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lista została wyczyszczona.");
            Console.ResetColor();
        }
    }
}

