using MediatR;

namespace API.UseCase.Command
{
    public record AddPatientCommand(string FirstName, string LastName, DateTime DateOfBirth, string Phone, string Email) : IRequest<Unit>;
}
