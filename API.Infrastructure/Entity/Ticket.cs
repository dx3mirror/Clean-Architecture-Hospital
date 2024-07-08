using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entity;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? TicketTypeId { get; set; }

    public DateTime? AppointmentDateTime { get; set; }

    public string? Status { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual TicketType? TicketType { get; set; }
}
