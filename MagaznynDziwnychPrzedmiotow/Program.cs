using System;

class Program
{
    static Dictionary<string, Storage> storages = new Dictionary<string, Storage>();

    static void Main()
    {
        Console.WriteLine("=== Magazyn Dziwnych Przedmiotów ===");

        while (true)
        {
            Console.WriteLine("\n1. Utwórz nowy magazyn");
            Console.WriteLine("2. Dodaj przedmiot do magazynu");
            Console.WriteLine("3. Usuń przedmiot z magazynu");
            Console.WriteLine("4. Wypisz wszystkie przedmioty z magazynu");
            Console.WriteLine("5. Wypisz delikatne lub ciężkie (powyżej progu)");
            Console.WriteLine("6. Oblicz średni poziom dziwności");
            Console.WriteLine("7. Lista magazynów");
            Console.WriteLine("8. Wyjście");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateStorage();
                    break;
                case "2":
                    AddItemToStorage();
                    break;
                case "3":
                    RemoveItemFromStorage();
                    break;
                case "4":
                    PrintItemsFromStorage();
                    break;
                case "5":
                    PrintFragileOrHeavy();
                    break;
                case "6":
                    PrintAverageWeirdness();
                    break;
                case "7":
                    ListStorages();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }
        static void CreateStorage()
        {
            Console.Write("Podaj nazwę magazynu: ");
            string name = Console.ReadLine();

            Console.Write("Podaj pojemność: ");
            int capacity = int.Parse(Console.ReadLine());

            Console.Write("Podaj maksymalną wagę: ");
            double maxWeight = double.Parse(Console.ReadLine());

            storages[name] = new Storage(name, capacity, maxWeight);
            Console.WriteLine("Magazyn utworzony.");
        }

        static Storage GetStorage()
        {
            Console.Write("Podaj nazwę magazynu: ");
            string name = Console.ReadLine();
            if (storages.ContainsKey(name))
            {
                return storages[name];
            }
            Console.WriteLine("Magazyn nie istnieje.");
            return null;
        }

        static void AddItemToStorage()
        {
            var storage = GetStorage();
            if (storage == null) return;

            Console.Write("Nazwa przedmiotu: ");
            string name = Console.ReadLine();

            Console.Write("Waga (kg): ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Poziom dziwności (1-10): ");
            int weirdness = int.Parse(Console.ReadLine());

            Console.Write("Czy delikatny (tak/nie): ");
            string fragileInput = Console.ReadLine().ToLower();
            bool isFragile = fragileInput == "tak";

            var item = new Item(name, weight, weirdness, isFragile);
            storage.AddItem(item);
        }

        static void RemoveItemFromStorage()
        {
            var storage = GetStorage();
            if (storage == null) return;

            Console.Write("Podaj nazwę przedmiotu do usunięcia: ");
            string itemName = Console.ReadLine();
            storage.RemoveItem(itemName);
        }

        static void PrintItemsFromStorage()
        {
            var storage = GetStorage();
            if (storage == null) return;

            storage.PrintAll();
        }

        static void PrintFragileOrHeavy()
        {
            var storage = GetStorage();
            if (storage == null) return;

            Console.Write("Podaj próg wagi: ");
            double threshold = double.Parse(Console.ReadLine());
            storage.PrintFragileOrHeavy(threshold);
        }

        static void PrintAverageWeirdness()
        {
            var storage = GetStorage();
            if (storage == null) return;

            double avg = storage.CalculateAverageWeirdness();
            Console.WriteLine($"Średnia dziwność: {avg:F2}");
        }

        static void ListStorages()
        {
            if (storages.Count == 0)
            {
                Console.WriteLine("Brak magazynów.");
                return;
            }

            Console.WriteLine("Dostępne magazyny:");
            foreach (var name in storages.Keys)
            {
                Console.WriteLine($"- {name}");
            }
        }

    }
}
