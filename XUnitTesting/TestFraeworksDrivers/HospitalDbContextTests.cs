using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class HospitalDbContextTests
{
    private HospitalDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new HospitalDbContext(options);
    }

    [Fact]
    public async Task GetTicketsByDateAsync_ReturnsTickets()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Tickets.Add(new Ticket { TicketId = 1, AppointmentDateTime = new DateTime(2023, 1, 1) });
        context.Tickets.Add(new Ticket { TicketId = 2, AppointmentDateTime = new DateTime(2023, 1, 1) });
        await context.SaveChangesAsync();

        // Act
        var result = await context.GetTicketsByDateAsync(new DateTime(2023, 1, 1));

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetTicketsByDoctorAsync_ReturnsTickets()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Tickets.Add(new Ticket { TicketId = 1, DoctorId = 1 });
        context.Tickets.Add(new Ticket { TicketId = 2, DoctorId = 1 });
        await context.SaveChangesAsync();

        // Act
        var result = await context.GetTicketsByDoctorAsync(1);

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetTicketsByPatientAsync_ReturnsTickets()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Tickets.Add(new Ticket { TicketId = 1, PatientId = 1 });
        context.Tickets.Add(new Ticket { TicketId = 2, PatientId = 1 });
        await context.SaveChangesAsync();

        // Act
        var result = await context.GetTicketsByPatientAsync(1);

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task AddPatientAsync_AddsPatient()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var patientCountBefore = await context.Patients.CountAsync();

        // Act
        await context.AddPatientAsync("John", "Doe", new DateTime(1990, 1, 1), "1234567890", "john.doe@example.com");
        var patientCountAfter = await context.Patients.CountAsync();

        // Assert
        Assert.Equal(patientCountBefore + 1, patientCountAfter);
    }

    [Fact]
    public async Task DeletePatientAsync_DeletesPatient()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var patient = new Patient { PatientId = 1, FirstName = "John", LastName = "Doe" };
        context.Patients.Add(patient);
        await context.SaveChangesAsync();

        var patientCountBefore = await context.Patients.CountAsync();

        // Act
        await context.DeletePatientAsync(1);
        var patientCountAfter = await context.Patients.CountAsync();

        // Assert
        Assert.Equal(patientCountBefore - 1, patientCountAfter);
    }

    [Fact]
    public async Task GetPatientByIDAsync_ReturnsPatient()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var patient = new Patient { PatientId = 1, FirstName = "John", LastName = "Doe" };
        context.Patients.Add(patient);
        await context.SaveChangesAsync();

        // Act
        var result = await context.GetPatientByIDAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
    }
    [Fact]
    public async Task UpdatePatientAsync_UpdatesPatient()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var patient = new Patient { PatientId = 1, FirstName = "John", LastName = "Doe" };
        context.Patients.Add(patient);
        await context.SaveChangesAsync();

        // Act
        patient.FirstName = "Jane";
        context.Patients.Update(patient);
        await context.SaveChangesAsync();

        var updatedPatient = await context.Patients.FindAsync(1);

        // Assert
        Assert.Equal("Jane", updatedPatient.FirstName);
    }

    [Fact]
    public async Task GetPatientByIDAsync_ReturnsNullForNonExistentPatient()
    {
        // Arrange
        var context = GetInMemoryDbContext();

        // Act
        var result = await context.GetPatientByIDAsync(999); // Non-existent patient ID

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllDoctorsAndSpecializationsAsync_ReturnsMultipleResults()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Doctors.Add(new Doctor { DoctorId = 1, FirstName = "Dr. Smith" });
        context.Specializations.Add(new Specialization { SpecializationId = 1, SpecializationName = "Cardiology" });
        context.Specializations.Add(new Specialization { SpecializationId = 2, SpecializationName = "Neurology"});
        await context.SaveChangesAsync();

        // Act
        var result = await context.GetAllDoctorsAndSpecializationsAsync();

        // Assert
        Assert.Single(result);
    }

    [Fact]
    public async Task AddPatientAsync_HandlesConcurrency()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var initialPatientCount = await context.Patients.CountAsync();

        // Act
        var task1 = context.AddPatientAsync("John", "Doe", new DateTime(1990, 1, 1), "1234567890", "john.doe@example.com");
        var task2 = context.AddPatientAsync("Jane", "Doe", new DateTime(1990, 1, 1), "0987654321", "jane.doe@example.com");

        await Task.WhenAll(task1, task2);

        var finalPatientCount = await context.Patients.CountAsync();

        // Assert
        Assert.Equal(initialPatientCount + 2, finalPatientCount);
    }

    [Fact]
    public async Task ComplexQueryAsync_ReturnsCorrectResults()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        context.Doctors.Add(new Doctor { DoctorId = 1, FirstName = "Dr. Smith" });
        context.Patients.Add(new Patient { PatientId = 1, FirstName = "John", LastName = "Doe" });
        context.Tickets.Add(new Ticket { TicketId = 1, DoctorId = 1, PatientId = 1, AppointmentDateTime = DateTime.Now });
        await context.SaveChangesAsync();

        // Act
        var tickets = await context.Tickets
            .Include(t => t.Doctor)
            .Include(t => t.Patient)
            .ToListAsync();

        // Assert
        Assert.Single(tickets);
        Assert.Equal("Dr. Smith", tickets[0].Doctor.FirstName);
        Assert.Equal("John", tickets[0].Patient.FirstName);
    }
}
