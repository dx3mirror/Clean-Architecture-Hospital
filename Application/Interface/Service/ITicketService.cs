// Services/ITicketService.cs
using API.Domain.EntityProcedure;
using Application.DTOs.Inpuct;


public interface ITicketService
{
    Task<List<TicketByDoctorResult>> GetTicketsByDoctorAsync(TicketDoctorResult ticketDoctorResult);
    Task<List<TicketByPatientResult>> GetTicketsByPatientAsync(int patientId);
    Task<List<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId);
    Task<List<DoctorSpecialization>> GetAllDoctorsAndSpecializationsAsync();
}
