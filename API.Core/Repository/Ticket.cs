using API.Domain.EntityProcedure;
using API.UseCase.Abstractions;
using Application.DTOs.Inpuct;
using AutoMapper;
using static FraemworksDrivers.StoredProcedure.Entity;

namespace API.Core.Repository
{
    public class Ticket : TicketServiceBase
    {
        
        public Ticket(HospitalDbContext context, IMapper mapper) : base(context,mapper)
        {

        }

        
        public override async Task<List<Domain.EntityProcedure.TicketByDoctorResult>> GetTicketsByDoctorAsync(TicketDoctorResult ticketDoctorResult)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                var tickets = await _context.GetTicketsByDoctorAsync(ticketDoctorResult.doctorId);
                return _mapper.Map<List<Domain.EntityProcedure.TicketByDoctorResult>>(tickets);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching tickets by doctor.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override async Task<List<Domain.EntityProcedure.TicketByPatientResult>> GetTicketsByPatientAsync(int patientId)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                var tickets = await _context.GetTicketsByPatientAsync(patientId);
                return _mapper.Map<List<Domain.EntityProcedure.TicketByPatientResult>>(tickets);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching tickets by patient.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override async Task<List<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                var tickets = await _context.GetDoctorScheduleAsync(doctorId);
                return _mapper.Map<List<DoctorSchedule>>(tickets);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching doctor schedule.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override async Task<List<DoctorSpecialization>> GetAllDoctorsAndSpecializationsAsync()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                var tickets = await _context.GetAllDoctorsAndSpecializationsAsync();
                return _mapper.Map<List<DoctorSpecialization>>(tickets);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching all doctors and specializations.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override async Task AddPatientAsync(string firstName, string lastName, DateTime dateOfBirth, string phone, string email)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                var domainPatient = API.Domain.Entity.Patient.Create(firstName, lastName, DateOnly.FromDateTime(dateOfBirth), phone, email);
                var dbPatient = _mapper.Map<API.Infrastructure.Entity.Patient>(domainPatient);

                _context.Patients.Add(dbPatient);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding a new patient.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }


        public override async Task DeletePatientAsync(int patientId)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                await _context.DeletePatientAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting a patient.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override async Task<PatientByIDResult> GetPatientByIDAsync(int patientId)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                return await _context.GetPatientByIDAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching patient by ID.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async override Task<List<Domain.EntityProcedure.TicketByDateResult>> GetTicketsByDateAsync(DateTime appointmentDate)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("_context is not initialized");
            }

            await _semaphore.WaitAsync();
            try
            {
                var tickets = await _context.GetTicketsByDateAsync(appointmentDate);
                return _mapper.Map<List<Domain.EntityProcedure.TicketByDateResult>>(tickets);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching tickets by date.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

}
