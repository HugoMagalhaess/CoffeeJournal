using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class FlavorsCoffee
{
    public int Id { get; set; }

    public int CoffeeId { get; set; }

    public int FlavorId { get; set; }

    public virtual Coffee Coffee { get; set; } = null!;

    public virtual Flavor Flavor { get; set; } = null!;
}
