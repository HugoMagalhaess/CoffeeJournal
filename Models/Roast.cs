using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class Roast
{
    public int RoastId { get; set; }

    public string? RoastDescription { get; set; }

    public int? RoastRate { get; set; }

    public virtual ICollection<RoastCoffee> RoastCoffees { get; } = new List<RoastCoffee>();
}
