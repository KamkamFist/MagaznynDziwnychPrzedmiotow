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


}
