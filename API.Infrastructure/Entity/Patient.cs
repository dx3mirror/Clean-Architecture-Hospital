using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entity;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
