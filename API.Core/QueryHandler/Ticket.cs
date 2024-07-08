using API.Core.Query;
using API.Domain.EntityProcedure;
using API.UseCase.Command;
using Application.Interface.Repository;
using MediatR;


namespace API.Core.QueryHandler
{
    // Handlers/GetTicketsByDateQueryHandler.cs
    public class GetTicketsByDateQueryHandler : IRequestHandler<GetTicketsByDateQuery, List<Domain.EntityProcedure.TicketByDateResult>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsByDateQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Domain.EntityProcedure.TicketByDateResult>> Handle(GetTicketsByDateQuery request, CancellationToken cancellationToken)
        {
            return await _ticketRepository.GetTicketsByDateAsync(request.AppointmentDate);
        }
    }

    // Handlers/AddPatientCommandHandler.cs
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, Unit>
    {
        private readonly ITicketRepository _ticketRepository;

        public AddPatientCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Unit> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            await _ticketRepository.AddPatientAsync(request.FirstName, request.LastName, request.DateOfBirth, request.Phone, request.Email);
            return Unit.Value;
        }

    }

    // Handlers/GetTicketsByDoctorQueryHandler.cs
    public class GetTicketsByDoctorQueryHandler : IRequestHandler<GetTicketsByDoctorQuery, List<Domain.EntityProcedure.TicketByDoctorResult>>
    {
        private readonly ITicketService _ticketService;

        public GetTicketsByDoctorQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<List<Domain.EntityProcedure.TicketByDoctorResult>> Handle(GetTicketsByDoctorQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetTicketsByDoctorAsync(request.TicketDoctorResult);
        }
    }

    public class GetTicketsByPatientQueryHandler : IRequestHandler<GetTicketsByPatientQuery, List<Domain.EntityProcedure.TicketByPatientResult>>
    {
        private readonly ITicketService _ticketService;

        public GetTicketsByPatientQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<List<Domain.EntityProcedure.TicketByPatientResult>> Handle(GetTicketsByPatientQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetTicketsByPatientAsync(request.PatientId);
        }
    }

    public class GetDoctorScheduleQueryHandler : IRequestHandler<GetDoctorScheduleQuery, List<DoctorSchedule>>
    {
        private readonly ITicketService _ticketService;

        public GetDoctorScheduleQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<List<DoctorSchedule>> Handle(GetDoctorScheduleQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetDoctorScheduleAsync(request.DoctorId);
        }
    }

    public class GetAllDoctorsAndSpecializationsQueryHandler : IRequestHandler<GetAllDoctorsAndSpecializationsQuery, List<DoctorSpecialization>>
    {
        private readonly ITicketService _ticketService;

        public GetAllDoctorsAndSpecializationsQueryHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<List<DoctorSpecialization>> Handle(GetAllDoctorsAndSpecializationsQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetAllDoctorsAndSpecializationsAsync();
        }
    }

}



