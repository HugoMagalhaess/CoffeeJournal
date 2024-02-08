using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class Coffee
{
    public int CoffeeId { get; set; }

    public string? CoffeeName { get; set; }

    public string? CoffeBrand { get; set; }

    public string? CoffeRegion { get; set; }

    public virtual ICollection<Brew> Brews { get; } = new List<Brew>();

    public virtual ICollection<FlavorsCoffee> FlavorsCoffees { get; } = new List<FlavorsCoffee>();

    public virtual ICollection<Rate> Rates { get; } = new List<Rate>();

    public virtual ICollection<RoastCoffee> RoastCoffees { get; } = new List<RoastCoffee>();
}
