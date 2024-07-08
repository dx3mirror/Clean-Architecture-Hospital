using API.Domain.EntityProcedure;
using Application.DTOs.Inpuct;
using AutoMapper;
using Moq;
using static FraemworksDrivers.StoredProcedure.Entity;
using Xunit;
using API.Core.Repository;
using API.Domain.Entity;

namespace XUnitTesting.UseCase
{
    public class TicketTests
    {
        private readonly Mock<HospitalDbContext> _contextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Ticket _ticketService;

        public TicketTests()
        {
            _contextMock = new Mock<HospitalDbContext>();
            _mapperMock = new Mock<IMapper>();
            _ticketService = new Ticket(_contextMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetTicketsByDoctorAsync_ReturnsMappedTickets()
        {
            // Arrange
            var ticketDoctorResult = new TicketDoctorResult { doctorId = 1 };
            var ticketsFromDb = new List<FraemworksDrivers.StoredProcedure.Entity.TicketByDoctorResult> { new FraemworksDrivers.StoredProcedure.Entity.TicketByDoctorResult { Status = "Active" } };
            var mappedTickets = new List<API.Domain.EntityProcedure.TicketByDoctorResult> { new API.Domain.EntityProcedure.TicketByDoctorResult(1, DateTime.UtcNow, "", "", "Specialnost", Status.From(TicketStatus.Pending)) };

            _contextMock.Setup(ctx => ctx.GetTicketsByDoctorAsync(It.IsAny<int>())).ReturnsAsync(ticketsFromDb);
            _mapperMock.Setup(mapper => mapper.Map<List<API.Domain.EntityProcedure.TicketByDoctorResult>>(It.IsAny<List<FraemworksDrivers.StoredProcedure.Entity.TicketByDoctorResult>>())).Returns(mappedTickets);

            // Act
            var result = await _ticketService.GetTicketsByDoctorAsync(ticketDoctorResult);

            // Assert
            Assert.Equal(mappedTickets, result);
        }

        [Fact]
        public async Task GetTicketsByPatientAsync_ReturnsMappedTickets()
        {
            // Arrange
            var patientId = 1;
            var ticketsFromDb = new List<FraemworksDrivers.StoredProcedure.Entity.TicketByPatientResult> { new FraemworksDrivers.StoredProcedure.Entity.TicketByPatientResult { Status = "Completed" } };
            var mappedTickets = new List<API.Domain.EntityProcedure.TicketByPatientResult> { new API.Domain.EntityProcedure.TicketByPatientResult(1,  DateTime.UtcNow, "", "", "", "Specialnost", Status.From(TicketStatus.Pending)) };

            _contextMock.Setup(ctx => ctx.GetTicketsByPatientAsync(It.IsAny<int>())).ReturnsAsync(ticketsFromDb);
            _mapperMock.Setup(mapper => mapper.Map<List<API.Domain.EntityProcedure.TicketByPatientResult>>(It.IsAny<List<API.Domain.EntityProcedure.TicketByPatientResult>>())).Returns(mappedTickets);

            // Act
            var result = await _ticketService.GetTicketsByPatientAsync(patientId);

            // Assert
            Assert.Equal(mappedTickets, result);
        }

        [Fact]
        public async Task GetDoctorScheduleAsync_ReturnsMappedSchedule()
        {
            // Arrange
            var doctorId = 1;
            var scheduleFromDb = new List<DoctorScheduleResult> { new DoctorScheduleResult() };
            var mappedSchedule = new List<DoctorSchedule> { new DoctorSchedule(1,DayOfWeek.Friday,TimeSpan.Zero,TimeSpan.Zero) };

            _contextMock.Setup(ctx => ctx.GetDoctorScheduleAsync(It.IsAny<int>())).ReturnsAsync(scheduleFromDb);
            _mapperMock.Setup(mapper => mapper.Map<List<DoctorSchedule>>(It.IsAny<List<DoctorScheduleResult>>())).Returns(mappedSchedule);

            // Act
            var result = await _ticketService.GetDoctorScheduleAsync(doctorId);

            // Assert
            Assert.Equal(mappedSchedule, result);
        }

        [Fact]
        public async Task GetAllDoctorsAndSpecializationsAsync_ReturnsMappedDoctorsAndSpecializations()
        {
            // Arrange
            var doctorsFromDb = new List<DoctorAndSpecializationResult> { new DoctorAndSpecializationResult() };
            var mappedDoctors = new List<DoctorSpecialization> { new DoctorSpecialization(1,"fs","xm","Ye","+72984343","fd@gm.ru") };

            _contextMock.Setup(ctx => ctx.GetAllDoctorsAndSpecializationsAsync()).ReturnsAsync(doctorsFromDb);
            _mapperMock.Setup(mapper => mapper.Map<List<DoctorSpecialization>>(It.IsAny<List<DoctorAndSpecializationResult>>())).Returns(mappedDoctors);

            // Act
            var result = await _ticketService.GetAllDoctorsAndSpecializationsAsync();

            // Assert
            Assert.Equal(mappedDoctors, result);
        }

        [Fact]
        public async Task AddPatientAsync_AddsPatient()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var dateOfBirth = new DateTime(1990, 1, 1);
            var phone = "1234567890";
            var email = "john.doe@example.com";

            var domainPatient = Patient.Create(firstName, lastName, DateOnly.FromDateTime(dateOfBirth), phone, email);
            var dbPatient = new API.Infrastructure.Entity.Patient();

            _mapperMock.Setup(mapper => mapper.Map<API.Infrastructure.Entity.Patient>(It.IsAny<API.Domain.Entity.Patient>())).Returns(dbPatient);
            _contextMock.Setup(ctx => ctx.Patients.Add(It.IsAny<API.Infrastructure.Entity.Patient>()));
            _contextMock.Setup(ctx => ctx.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            await _ticketService.AddPatientAsync(firstName, lastName, dateOfBirth, phone, email);

            // Assert
            _contextMock.Verify(ctx => ctx.Patients.Add(It.IsAny<API.Infrastructure.Entity.Patient>()), Times.Once);
            _contextMock.Verify(ctx => ctx.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeletePatientAsync_DeletesPatient()
        {
            // Arrange
            var patientId = 1;

            _contextMock.Setup(ctx => ctx.DeletePatientAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            await _ticketService.DeletePatientAsync(patientId);

            // Assert
            _contextMock.Verify(ctx => ctx.DeletePatientAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetPatientByIDAsync_ReturnsPatient()
        {
            // Arrange
            var patientId = 1;
            var patientFromDb = new PatientByIDResult();

            _contextMock.Setup(ctx => ctx.GetPatientByIDAsync(It.IsAny<int>())).ReturnsAsync(patientFromDb);

            // Act
            var result = await _ticketService.GetPatientByIDAsync(patientId);

            // Assert
            Assert.Equal(patientFromDb, result);
        }

        [Fact]
        public async Task GetTicketsByDateAsync_ReturnsMappedTickets()
        {
            // Arrange
            var appointmentDate = new DateTime(2024, 7, 9);
            var ticketsFromDb = new List<FraemworksDrivers.StoredProcedure.Entity.TicketByDateResult> { new FraemworksDrivers.StoredProcedure.Entity.TicketByDateResult { Status = "Active" } };
            var mappedTickets = new List<API.Domain.EntityProcedure.TicketByDateResult>
{
    new API.Domain.EntityProcedure.TicketByDateResult(1, "Name", "Fam", "", "", "Nam", 12, 12, DateTime.UtcNow, "Specialnost", Status.From(TicketStatus.Pending))
};

            _contextMock.Setup(ctx => ctx.GetTicketsByDateAsync(It.IsAny<DateTime>())).ReturnsAsync(ticketsFromDb);
            _mapperMock.Setup(mapper => mapper.Map<List<API.Domain.EntityProcedure.TicketByDateResult>>(It.IsAny<List<FraemworksDrivers.StoredProcedure.Entity.TicketByDateResult>>())).Returns(mappedTickets);

            // Act
            var result = await _ticketService.GetTicketsByDateAsync(appointmentDate);

            // Assert
            Assert.Equal(mappedTickets, result);
        }

    }
}
