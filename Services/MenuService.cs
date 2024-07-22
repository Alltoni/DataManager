using System.Text;
using DataManager.Enums;
using DataManager.Models;

namespace DataManager.Services;

// TODO: widzialem ze zmieniles nazewnictwo metod, poczytaj konwencje nazewnictwa "ENDPOINTÓW" warto trzymac sie jednej wersji w przyszlsci
//       żeby tez byla zrozumiala dla wszystkich https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/conventions?view=aspnetcore-8.0
public class MenuService : IMenuService
{
    private readonly IHumanService _humanService;

    public MenuService(IHumanService humanService)
    {
        _humanService = humanService ?? throw new ArgumentNullException(nameof(humanService));
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
                Console.WriteLine(value: "Wprowadzona liczba jest nieprawidłowa.\n");
                continue;
            }

            if (Enum.IsDefined(typeof(MenuOption), userNumber))
            {
                switch ((MenuOption)userNumber)
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
                        ExitProgram();
                        return;
                    default:
                        DefaultUserChoice();
                        break;
                }
            }
        }
    }

    private void ExitProgram()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(value: "Zamykanie programu...");
        Console.ResetColor();
    }

    private void DefaultUserChoice()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(value: "Proszę wprowadzić jakiś znak.");
        Console.ResetColor();
    }

    private void AddHuman()
    {
        //Console.Write(value: "Podaj Id: ");
        //string? idInput = Console.ReadLine();
        //if (!int.TryParse(idInput, out int idNumber))
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine(value: "Id musi być liczbą!\n");
        //    Console.ResetColor();
        //    return;
        //}

        Console.Write(value: "Podaj imię: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value: "Imię nie może być puste!\n");
            Console.ResetColor();
            return;
        }

        Console.Write(value: "Podaj nazwisko: ");
        string? surname = Console.ReadLine();
        if (string.IsNullOrEmpty(surname))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value: "Nazwisko nie może być puste!\n");
            Console.ResetColor();
            return;
        }

        Console.Write(value: "Podaj opis (opcjonalny): ");
        string? description = Console.ReadLine();

        var human = new Human(name, surname, description);
        _humanService.AddHuman(human);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(value: "Osoba została dodana do listy.\n");
        Console.ResetColor();
    }

    private void DeleteHuman()
    {
        Console.Write(value: "Podaj Id osoby, którą chcesz usunąć z listy: ");
        string? deleteInput = Console.ReadLine();
        if (!int.TryParse(deleteInput, out int idToDelete))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value: "ID musi być liczbą!\n");
            Console.ResetColor();
            return;
        }

        try
        {
            _humanService.DeleteHumanById(idToDelete);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value: "Pomyslnie usunięto z listy.");
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
            Console.WriteLine(value: @$"ID: {human.Id}, Name: {human.Name}, Surname: {human.Surname}, Description: {human.Description ?? "No description"}");
            Console.WriteLine(value: "");
        }
    }

    private void ClearHumans()
    {
        _humanService.ClearHumans();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(value: "Lista została wyczyszczona.");
        Console.ResetColor();
    }
}

