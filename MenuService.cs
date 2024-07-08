namespace DataManager
{
    internal class MenuService
    {

        public static void StartMenu()
        {
            List<Human> humans = new List<Human>();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 - dodaj na liste");
                Console.WriteLine("2 - usuń z listy");
                Console.WriteLine("3 - wyświetl liste");
                Console.WriteLine("4 - wyczyść liste");
                Console.WriteLine("5 - zamknij program");
                Console.WriteLine("");

                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(value: $"Wprowadzony znak jest pusty lub nieprawidłowy.");
                    // TODO: wstaw rekurencje, do tej metody, zeby wrocilo do wyobur menu
                }


                int userNumber;

                if (!int.TryParse(input, out userNumber) || userNumber < 1 || userNumber > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!\n");

                }
                else
                {
                    switch (userNumber)
                    {
                        case 1:
                            Console.Write("Podaj Id: ");
                            string? idInput = Console.ReadLine();
                            int idNumber;
                            if (!int.TryParse(idInput, out idNumber))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input!\n");
                                continue;


                            }

                            if (IdIsOnList(idNumber, humans) == false)
                            {
                                Console.Write("Podaj imię: ");
                                string? name = Console.ReadLine();
                                if (string.IsNullOrEmpty(name))
                                    throw new ArgumentNullException(name);

                                Console.Write("Podaj nazwisko: ");
                                string? surname = Console.ReadLine();
                                // TODO: add exception or validation

                                Console.Write("Podaj opis (opcjonalny): ");
                                string destription = Console.ReadLine();
                                // TODO: add (exception || validation) && make variable above nullable

                                humans.Add(new Human(idNumber, name, surname, destription));
                            }
                            else
                            {
                                Console.WriteLine("Id znajduje się już na liście!");
                            }
                            Console.WriteLine("");
                            break;
                        case 2:
                            Console.Write("Podaj Id osoby, która chcesz usunąć z listy: ");
                            string deleteInput = Console.ReadLine();
                            // TODO: add (exception || validation) && make variable above nullable

                            int idToDelete = int.Parse(deleteInput);
                            // TODO: add (exception || validation) && make variable above nullable


                            foreach (var human in humans)
                            {
                                if (human.Id == idToDelete)
                                {
                                    humans.Remove(human);
                                    Console.WriteLine("\nPomyslnie usunięto z listy.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nNie znaleziono na liście Id do usunięcia.");
                                }
                            }
                            Console.WriteLine("");
                            break;
                        case 3:
                            foreach (var human in humans)
                            {
                                Console.WriteLine($"ID: " +
                                    $"{human.Id}, " +
                                    $"Name: {human.Name}, " +
                                    $"Surname: {human.Surname}, " +
                                    $"Description: {human.Description ?? "No description"}");
                                Console.WriteLine("");
                            }
                            break;
                        case 4:
                            humans.Clear();
                            Console.WriteLine("\nLista została wyczyszczona");
                            Console.WriteLine("");

                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Zamykanie programu...");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        private static bool IdIsOnList(int idNumber, List<Human> humans)
        {
            foreach (var human in humans)
            {
                if (idNumber == human.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

