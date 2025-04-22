using System;

public class Item
{
    public string Name { get; set; }
    public double WeightKg { get; set; }
    public int WeirdnessLevel { get; set; }
    public bool IsFragile { get; set; }

    public Item(string name, double weightKg, int weirdnessLevel, bool isFragile)
    {
        Name = name;
        WeightKg = Math.Round(weightKg, 3);
        WeirdnessLevel = weirdnessLevel;
        IsFragile = isFragile;
    }

  
}