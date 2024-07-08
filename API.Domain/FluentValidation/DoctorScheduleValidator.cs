using API.Domain.EntityProcedure;
using FluentValidation;
namespace API.Domain.FluentValidation
{
    public class DoctorScheduleValidator : AbstractValidator<DoctorSchedule>
    {
        public DoctorScheduleValidator()
        {
            RuleFor(x => x.ScheduleID).GreaterThan(0).WithMessage("Schedule ID must be greater than zero.");
            RuleFor(x => x.StartTime).LessThan(x => x.EndTime).WithMessage("Start time must be earlier than end time.");
        }
    }

}
