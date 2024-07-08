using API.Domain.EntityProcedure;
using Application.DTOs.Inpuct;
using Application.Interface.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace API.Core.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMemoryCache _memoryCache;

        public TicketService(ITicketRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        public async Task<List<Domain.EntityProcedure.TicketByDoctorResult>> GetTicketsByDoctorAsync(TicketDoctorResult ticketDoctorResult)
        {
            var cacheKey = $"TicketsByDoctor_{ticketDoctorResult.doctorId}";

            if (_memoryCache.TryGetValue(cacheKey, out List<Domain.EntityProcedure.TicketByDoctorResult> cachedData))
            {
                return cachedData;
            }

            var result = await _repository.GetTicketsByDoctorAsync(ticketDoctorResult);
            _memoryCache.Set(cacheKey, result, TimeSpan.FromHours(1));

            return result;
        }

        public async Task<List<Domain.EntityProcedure.TicketByPatientResult>> GetTicketsByPatientAsync(int patientId)
        {
            var cacheKey = $"TicketsByPatient_{patientId}";

            if (_memoryCache.TryGetValue(cacheKey, out List<Domain.EntityProcedure.TicketByPatientResult> cachedData))
            {
                return cachedData;
            }

            var result = await _repository.GetTicketsByPatientAsync(patientId);
            _memoryCache.Set(cacheKey, result, TimeSpan.FromHours(1));

            return result;
        }

        public async Task<List<DoctorSchedule>> GetDoctorScheduleAsync(int doctorId)
        {
            var cacheKey = $"DoctorSchedule_{doctorId}";

            if (_memoryCache.TryGetValue(cacheKey, out List<DoctorSchedule> cachedData))
            {
                return cachedData;
            }

            var result = await _repository.GetDoctorScheduleAsync(doctorId);
            _memoryCache.Set(cacheKey, result, TimeSpan.FromHours(1));

            return result;
        }

        public async Task<List<DoctorSpecialization>> GetAllDoctorsAndSpecializationsAsync()
        {
            var cacheKey = "AllDoctorsAndSpecializations";

            if (_memoryCache.TryGetValue(cacheKey, out List<DoctorSpecialization> cachedData))
            {
                return cachedData;
            }

            var result = await _repository.GetAllDoctorsAndSpecializationsAsync();
            _memoryCache.Set(cacheKey, result, TimeSpan.FromHours(1));

            return result;
        }
    }
}
