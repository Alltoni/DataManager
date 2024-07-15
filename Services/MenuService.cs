using DataManager.Models;
using System.Text;


namespace DataManager.Services
{
    // DONE: jak zmienisz lokalizacje Human.cs do Modelu lub go usuniesz to pamietaj aby zaktualizowac tutaj referencje do nich (bedize brakowal USING namespace) (na Human kliknij, potem CTRL + . )
    internal class MenuService : IMenuService
    {
        // DONE: warto to przeniesc do folderu Services i dodać do niego Interface z prefixem "I" + NazwaKlasy
        // Przenieść tam dla czystosci zeby latwiej to bylo utrzymywac, a utworzenie interfejsu w celu utrzymania  "design patternu"

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
                // DONE: zastanów się jak to można przerobić np na string buildera, tablice stringów, liste lub jakas kolekcje (pokombinuj)

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
                    // DONE: wstaw rekurencje, do tej metody, zeby wrocilo do wyobur menu
                }


                if (!int.TryParse(input, out int userNumber) || userNumber < 1 || userNumber > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wprowadzona liczba jest nieprawidłowa.\n");
                    continue;
                }
                if (Enum.IsDefined(typeof(MenuOption), userNumber))
                {
                    MenuOption selectedOption = (MenuOption)userNumber;

                    // DONE: poczytaj sobie o Enumach (możesz np zamiast case 1: zrobic case Add, gdzie bedzie to przypisane w enumie jako Add = 1, a w tmy miejscu zastanów sie nad rzutowaniem tego enuma ktoryy wykorzystasz na int'a
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
            // DONE: ten == false poniżej jest zbedny troszke, zastanów się i napisz do mnie jak można to zrobić czysciej lub ladniej
            Console.Write("Podaj Id: ");
            string? idInput = Console.ReadLine();
            if (!int.TryParse(idInput, out int idNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id musi być liczbą!\n");
                Console.ResetColor();
                return;
            }
            // DONE: add exception or validation
            Console.Write("Podaj imię: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Imię nie może być puste!\n");
                Console.ResetColor();
                return;
            }
            // DONE: add exception or validation
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
            // DONE: add (exception || validation) && make variable above nullable
            Console.Write("Podaj Id osoby, którą chcesz usunąć z listy: ");
            string deleteInput = Console.ReadLine();
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
            // DONE: zastanów się nad użyciem @ prz tym WriteLine poniżej... np @$"twojTekst"
            var humans = _humanService.GetHumans();
            foreach (var human in humans)
            {
                Console.WriteLine(@$"ID: {human.Id}, Name: {human.Name}, Surname: {human.Surname}, Description: {human.Description ?? "No description"}");
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

