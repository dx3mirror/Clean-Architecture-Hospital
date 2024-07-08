
using AutoMapper;
using static FraemworksDrivers.StoredProcedure.Entity;

namespace FraemworksDrivers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map TicketByDoctorResult to its corresponding entity
            CreateMap<TicketByDoctorResult, API.Domain.EntityProcedure.TicketByDoctorResult>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Status.From(Enum.Parse<TicketStatus>(src.Status))));

            // Map TicketByDateResult to its corresponding entity
            CreateMap<TicketByDateResult, API.Domain.EntityProcedure.TicketByDateResult>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Status.From(Enum.Parse<TicketStatus>(src.Status))));

            // Map TicketByPatientResult to its corresponding entity
            CreateMap<TicketByPatientResult, API.Domain.EntityProcedure.TicketByPatientResult>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Status.From(Enum.Parse<TicketStatus>(src.Status))));

            // Convert string to Status using TicketStatus enum
            CreateMap<string, Status>().ConvertUsing(s => Status.From(Enum.Parse<TicketStatus>(s)));

            // Map DoctorScheduleResult to its corresponding entity
            CreateMap<DoctorScheduleResult, API.Domain.EntityProcedure.DoctorSchedule>();

            // Map DoctorAndSpecializationResult to its corresponding entity
            CreateMap<DoctorAndSpecializationResult, API.Domain.EntityProcedure.DoctorSpecialization>();

            // Map Patient domain entity to infrastructure entity and ignore specific properties
            CreateMap<API.Domain.Entity.Patient, API.Infrastructure.Entity.Patient>()
                .ForMember(dest => dest.PatientId, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            // Construct Patient domain entity from infrastructure entity
            CreateMap<API.Infrastructure.Entity.Patient, API.Domain.Entity.Patient>()
                .ConstructUsing(src => new API.Domain.Entity.Patient(
                    src.FirstName,
                    src.LastName,
                    src.DateOfBirth,
                    src.Phone,
                    src.Email));
        }
    }

}
