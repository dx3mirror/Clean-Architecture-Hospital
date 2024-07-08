using API.Domain.EntityProcedure;
using FluentValidation;

namespace API.Domain.FluentValidation
{
    public class TicketByPatientResultValidator : AbstractValidator<TicketByPatientResult>
    {
        public TicketByPatientResultValidator()
        {
            RuleFor(x => x.TicketID).GreaterThan(0);
            RuleFor(x => x.AppointmentDateTime).NotEmpty();
            RuleFor(x => x.TicketTypeName).NotEmpty().NotNull().WithMessage("Ticket type name cannot be null or empty");
            RuleFor(x => x.DoctorFirstName).NotEmpty().NotNull().WithMessage("Doctor first name cannot be null or empty");
            RuleFor(x => x.DoctorLastName).NotEmpty().NotNull().WithMessage("Doctor last name cannot be null or empty");
            RuleFor(x => x.SpecializationName).NotEmpty().NotNull().WithMessage("Specialization name cannot be null or empty");
            RuleFor(x => x.Status).NotNull().WithMessage("Status must be specified");
        }
    }
}
