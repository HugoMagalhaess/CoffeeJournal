using System;
using System.Collections.Generic;

namespace CoffeeJournal.Models;

public partial class Rate
{
    public int RateId { get; set; }

    public int? RateAppearance { get; set; }

    public int? RateAroma { get; set; }

    public int? RateFlavor { get; set; }

    public int? RateValue { get; set; }

    public int? CoffeeId { get; set; }

    public virtual Coffee? Coffee { get; set; }
}
