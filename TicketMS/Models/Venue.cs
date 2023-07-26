using System;
using System.Collections.Generic;

namespace TicketMS.Models;

public partial class Venue
{
    public int Venueid { get; set; }

    public int Capacity { get; set; }

    public string Location { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
