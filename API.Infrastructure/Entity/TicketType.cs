using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entity;

public partial class TicketType
{
    public int TicketTypeId { get; set; }

    public string TicketTypeName { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
