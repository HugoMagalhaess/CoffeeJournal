using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class Brew
{
    public int BrewId { get; set; }

    public int? BrewGrindSize { get; set; }

    public double? BrewCoffeeWeight { get; set; }

    public double? BrewWaterVolume { get; set; }

    public string? BrewRatio { get; set; }

    public double? BrewTime { get; set; }

    public int? CoffeeId { get; set; }

    public virtual Coffee? Coffee { get; set; }
}
