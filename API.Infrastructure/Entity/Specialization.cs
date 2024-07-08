using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entity;

public partial class Specialization
{
    public int SpecializationId { get; set; }

    public string SpecializationName { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
