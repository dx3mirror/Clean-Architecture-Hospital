using API.Domain.EntityProcedure;
using Application.DTOs.Inpuct;
using MediatR;


namespace API.Core.Query
{
    public record GetTicketsByDateQuery(DateTime AppointmentDate) : IRequest<List<Domain.EntityProcedure.TicketByDateResult>>;
    // Queries/GetTicketsByDoctorQuery.cs
    public record GetTicketsByDoctorQuery(TicketDoctorResult TicketDoctorResult) : IRequest<List<Domain.EntityProcedure.TicketByDoctorResult>>;

    // Queries/GetTicketsByPatientQuery.cs
    public record GetTicketsByPatientQuery(int PatientId) : IRequest<List<Domain.EntityProcedure.TicketByPatientResult>>;

    // Queries/GetDoctorScheduleQuery.cs
    public record GetDoctorScheduleQuery(int DoctorId) : IRequest<List<DoctorSchedule>>;

    // Queries/GetAllDoctorsAndSpecializationsQuery.cs
    public record GetAllDoctorsAndSpecializationsQuery : IRequest<List<DoctorSpecialization>>;

}
