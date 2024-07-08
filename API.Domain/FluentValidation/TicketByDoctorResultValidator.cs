using API.Domain.EntityProcedure;
using FluentValidation;

public class TicketByDoctorResultValidator : AbstractValidator<TicketByDoctorResult>
{
    public TicketByDoctorResultValidator()
    {
        RuleFor(ticket => ticket.TicketID).GreaterThan(0);
        RuleFor(ticket => ticket.AppointmentDateTime).GreaterThan(DateTime.Now);
        RuleFor(ticket => ticket.TicketTypeName).NotEmpty().WithMessage("Ticket type name cannot be empty");
        RuleFor(ticket => ticket.PatientFirstName).NotEmpty().WithMessage("Patient first name cannot be empty");
        RuleFor(ticket => ticket.PatientLastName).NotEmpty().WithMessage("Patient last name cannot be empty");
        RuleFor(ticket => ticket.Status).NotNull().WithMessage("Status cannot be null");
    }
}
