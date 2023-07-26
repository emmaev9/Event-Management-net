using System;
using System.Collections.Generic;

namespace TicketMS.Models;

public partial class EventType
{
    public int EventTypeid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
