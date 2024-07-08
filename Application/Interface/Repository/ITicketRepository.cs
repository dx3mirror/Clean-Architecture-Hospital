using API.Domain.EntityProcedure;
using Application.DTOs.Inpuct;
using static FraemworksDrivers.StoredProcedure.Entity;

namespace Application.Interface.Repository
{
    public interface ITicketRepository
    {
        public Task<List<API.Domain.EntityProcedure.TicketByDateResult>> GetTicketsByDateAsync(DateTime appointmentDate);
        public Task<List<API.Domain.EntityProcedure.TicketByDoctorResult>> GetTicketsByDoctorAsync(TicketDoctorResult ticketDoctorResult);
        public Task<List<API.Domain.EntityProcedure.TicketByPatientResult>> GetTicketsByPatientAsync(int patientId);
        public Task<List<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId);
        public Task<List<DoctorSpecialization>> GetAllDoctorsAndSpecializationsAsync();
        public Task AddPatientAsync(string firstName, string lastName, DateTime dateOfBirth, string phone, string email);
        public Task DeletePatientAsync(int patientId);
        public Task<PatientByIDResult> GetPatientByIDAsync(int patientId);
    }
}
