using API.Core.Query;
using API.Core.QueryHandler;
using API.Core.Repository;
using API.Core.Service;
using API.Domain.EntityProcedure;
using API.UseCase.Command;
using Application.Interface.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace API.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ITicketRepository), typeof(Ticket), lifetime));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(ITicketService), typeof(TicketService), lifetime));
            return services;
        }

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
            return services;
        }

        public static IServiceCollection AddRequestHandlers(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.Add(new ServiceDescriptor(typeof(IRequestHandler<GetTicketsByDoctorQuery, List<TicketByDoctorResult>>), typeof(GetTicketsByDoctorQueryHandler), lifetime));
            services.Add(new ServiceDescriptor(typeof(IRequestHandler<GetTicketsByPatientQuery, List<TicketByPatientResult>>), typeof(GetTicketsByPatientQueryHandler), lifetime));
            services.Add(new ServiceDescriptor(typeof(IRequestHandler<GetDoctorScheduleQuery, List<DoctorSchedule>>), typeof(GetDoctorScheduleQueryHandler), lifetime));
            services.Add(new ServiceDescriptor(typeof(IRequestHandler<GetAllDoctorsAndSpecializationsQuery, List<DoctorSpecialization>>), typeof(GetAllDoctorsAndSpecializationsQueryHandler), lifetime));
            services.Add(new ServiceDescriptor(typeof(IRequestHandler<GetTicketsByDateQuery, List<TicketByDateResult>>), typeof(GetTicketsByDateQueryHandler), lifetime));
            services.Add(new ServiceDescriptor(typeof(IRequestHandler<AddPatientCommand, Unit>), typeof(AddPatientCommandHandler), lifetime));
            return services;
        }
    }
    public class DependencyInjection
    {
        /// <summary>
        /// Configures services for the application.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddRepositories()
                    .AddServices()
                    .AddMediatRServices()
                    .AddMemoryCache()  // Register memory cache
                    .AddRequestHandlers();
        }
    }
}
