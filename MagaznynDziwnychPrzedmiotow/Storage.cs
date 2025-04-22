using System;
using System.Collections.Generic;

public class Storage
{
    public int Capacity { get; private set; }
    public int CurrentItemCount { get; private set; } = 0;
    public double MaxTotalWeight { get; private set; }
    private double currentWeight = 0.0;

    private List<Item> items = new List<Item>();

    public Storage(int capacity, double maxTotalWeight)
    {
        Capacity = capacity;
        MaxTotalWeight = Math.Round(maxTotalWeight, 3);
    }

    public bool AddItem(Item item)
    {
        if (CurrentItemCount >= Capacity)
        {
            Console.WriteLine("Storage is full.");
            return false;
        }

        if (currentWeight + item.WeightKg > MaxTotalWeight)
        {
            Console.WriteLine("Adding this item would exceed the maximum total weight.");
            return false;
        }

        items.Add(item);
        CurrentItemCount++;
        currentWeight += item.WeightKg;

        Console.WriteLine("Item added successfully.");
        return true;
    }

    public void PrintAll()
    {
        foreach (Item item in items)
        {
            Console.WriteLine(item.Describe());
        }
    }


    public void RemoveItem(string itemName)
    {
        bool firstItemFound = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Name == itemName)
            {
                currentWeight -= items[i].WeightKg;
                CurrentItemCount--;
                items.RemoveAt(i);
                Console.WriteLine("Item removed successfully.");
                firstItemFound = true;
                if(firstItemFound == true)
                {
                    break;
                }
            }
        }
        if (firstItemFound == false)
        {
            Console.WriteLine("Item not found.");
        }
      
    }


    

   
}

