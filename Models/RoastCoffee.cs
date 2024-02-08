using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class RoastCoffee
{
    public int Id { get; set; }

    public int CoffeeId { get; set; }

    public int RoastId { get; set; }

    public virtual Coffee Coffee { get; set; } = null!;

    public virtual Roast Roast { get; set; } = null!;
}
