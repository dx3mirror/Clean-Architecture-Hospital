using API.Domain.EntityProcedure;
using FluentValidation;

public class TicketByDateResultValidator : AbstractValidator<TicketByDateResult>
{
    public TicketByDateResultValidator()
    {
        RuleFor(ticket => ticket.TicketID).GreaterThan(0);
        RuleFor(ticket => ticket.PatientFirstName).NotEmpty().WithMessage("Patient first name cannot be empty");
        RuleFor(ticket => ticket.PatientLastName).NotEmpty().WithMessage("Patient last name cannot be empty");
        RuleFor(ticket => ticket.DoctorFirstName).NotEmpty().WithMessage("Doctor first name cannot be empty");
        RuleFor(ticket => ticket.DoctorLastName).NotEmpty().WithMessage("Doctor last name cannot be empty");
        RuleFor(ticket => ticket.TicketTypeName).NotEmpty().WithMessage("Ticket type name cannot be empty");
        RuleFor(ticket => ticket.AppointmentDateTime).GreaterThan(DateTime.Now).WithMessage("Appointment date and time must be in the future");
        RuleFor(ticket => ticket.SpecializationName).NotEmpty().WithMessage("Specialization name cannot be empty");
        RuleFor(ticket => ticket.Status).NotNull().WithMessage("Status cannot be null");
    }
}
