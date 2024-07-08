using API.Domain.EntityProcedure;
using Application.DTOs.Inpuct;
using Application.Interface.Repository;
using AutoMapper;
using static FraemworksDrivers.StoredProcedure.Entity;

namespace API.UseCase.Abstractions
{
    public abstract class TicketServiceBase : ITicketRepository
    {
        protected readonly HospitalDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        protected TicketServiceBase(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<List<Domain.EntityProcedure.TicketByDateResult>> GetTicketsByDateAsync(DateTime appointmentDate);
        public abstract Task<List<Domain.EntityProcedure.TicketByDoctorResult>> GetTicketsByDoctorAsync(TicketDoctorResult ticketDoctorResult);
        public abstract Task<List<Domain.EntityProcedure.TicketByPatientResult>> GetTicketsByPatientAsync(int patientId);
        public abstract Task<List<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId);
        public abstract Task<List<DoctorSpecialization>> GetAllDoctorsAndSpecializationsAsync();
        public abstract Task AddPatientAsync(string firstName, string lastName, DateTime dateOfBirth, string phone, string email);
        public abstract Task DeletePatientAsync(int patientId);
        public abstract Task<PatientByIDResult> GetPatientByIDAsync(int patientId);
    }
}
