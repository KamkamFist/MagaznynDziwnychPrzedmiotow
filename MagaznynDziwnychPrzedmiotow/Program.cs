using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter storage capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        Console.Write("Enter maximum total weight (kg): ");
        double maxWeight = double.Parse(Console.ReadLine());

        Storage storage = new Storage(capacity, maxWeight);

        while (true)
        {
            Console.WriteLine("\n1. Add item");
            Console.WriteLine("2. Print all items");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Item name: ");
                string name = Console.ReadLine();

                Console.Write("Item weight (kg): ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("Weirdness level (1-10): ");
                int level = int.Parse(Console.ReadLine());

                Console.Write("Is the item fragile? (yes/no): ");
                string fragileInput = Console.ReadLine();
                bool isFragile = fragileInput.ToLower() == "yes";

                Item item = new Item(name, weight, level, isFragile);
                storage.AddItem(item);
            }
            else if (choice == "2")
            {
                storage.PrintAll();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
