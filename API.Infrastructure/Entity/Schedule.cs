using System;
using System.Collections.Generic;

namespace API.Infrastructure.Entity;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? WorkDay { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
