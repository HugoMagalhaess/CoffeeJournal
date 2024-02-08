using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class Flavor
{
    public int FlavorId { get; set; }

    public string? FlavorDescription { get; set; }

    public virtual ICollection<FlavorsCoffee> FlavorsCoffees { get; } = new List<FlavorsCoffee>();
}
