using API.Domain.EntityProcedure;
using FluentValidation;

namespace API.Domain.FluentValidation
{
    public class DoctorAndSpecializationValidator : AbstractValidator<DoctorSpecialization>
    {
        public DoctorAndSpecializationValidator()
        {
            RuleFor(x => x.DoctorID).GreaterThan(0).WithMessage("Doctor ID must be greater than zero.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be null or empty.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be null or empty.");
            RuleFor(x => x.SpecializationName).NotEmpty().WithMessage("Specialization name cannot be null or empty.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number cannot be null or empty.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address cannot be null or empty.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
