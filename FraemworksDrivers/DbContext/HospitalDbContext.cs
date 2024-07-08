using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using static FraemworksDrivers.StoredProcedure.Entity;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketType> TicketTypes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DX3MIRROR;Database=HospitalDB;Trusted_Connection=True;encrypt=False;MultipleActiveResultSets=True");
    
    /// <summary>
    /// Configures the entity mappings using separate configuration classes.
    /// </summary>
    /// <param name="modelBuilder">The model builder to configure.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TicketByDateResultConfiguration());
        modelBuilder.ApplyConfiguration(new TicketByDoctorResultConfiguration());
        modelBuilder.ApplyConfiguration(new TicketByPatientResultConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorScheduleResultConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorAndSpecializationResultConfiguration());
        modelBuilder.ApplyConfiguration(new NewPatientResultConfiguration());
        modelBuilder.ApplyConfiguration(new PatientByIDResultConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    #region Stored Procedure Methods

    /// <summary>
    /// Retrieves tickets by date asynchronously.
    /// </summary>
    /// <param name="appointmentDate">The appointment date.</param>
    /// <returns>A list of tickets by date.</returns>
    public async Task<List<TicketByDateResult>> GetTicketsByDateAsync(DateTime appointmentDate)
    {
        return await this.Set<TicketByDateResult>()
            .FromSqlRaw("EXEC GetTicketsByDate @AppointmentDate = {0}", appointmentDate)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves tickets by doctor asynchronously.
    /// </summary>
    /// <param name="doctorId">The doctor ID.</param>
    /// <returns>A list of tickets by doctor.</returns>
    public async Task<List<TicketByDoctorResult>> GetTicketsByDoctorAsync(int doctorId)
    {
        return await this.Set<TicketByDoctorResult>()
            .FromSqlRaw("EXEC GetTicketsByDoctor @DoctorID = {0}", doctorId)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves tickets by patient asynchronously.
    /// </summary>
    /// <param name="patientId">The patient ID.</param>
    /// <returns>A list of tickets by patient.</returns>
    public async Task<List<TicketByPatientResult>> GetTicketsByPatientAsync(int patientId)
    {
        return await this.Set<TicketByPatientResult>()
            .FromSqlRaw("EXEC GetTicketsByPatient @PatientID = {0}", patientId)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves the schedule of a doctor asynchronously.
    /// </summary>
    /// <param name="doctorId">The doctor ID.</param>
    /// <returns>A list of the doctor's schedule.</returns>
    public async Task<List<DoctorScheduleResult>> GetDoctorScheduleAsync(int doctorId)
    {
        return await this.Set<DoctorScheduleResult>()
            .FromSqlRaw("EXEC GetDoctorSchedule @DoctorID = {0}", doctorId)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves all doctors and their specializations asynchronously.
    /// </summary>
    /// <returns>A list of doctors and their specializations.</returns>
    public async Task<List<DoctorAndSpecializationResult>> GetAllDoctorsAndSpecializationsAsync()
    {
        return await this.Set<DoctorAndSpecializationResult>()
            .FromSqlRaw("EXEC GetAllDoctorsAndSpecializations")
            .ToListAsync();
    }

    /// <summary>
    /// Adds a new patient asynchronously.
    /// </summary>
    /// <param name="firstName">The first name.</param>
    /// <param name="lastName">The last name.</param>
    /// <param name="dateOfBirth">The date of birth.</param>
    /// <param name="phone">The phone number.</param>
    /// <param name="email">The email address.</param>
    /// <returns>The ID of the newly added patient.</returns>
    public async Task AddPatientAsync(string firstName, string lastName, DateTime dateOfBirth, string phone, string email)
    {
        await this.Database.ExecuteSqlRawAsync(
        "EXEC AddPatient @FirstName = {0}, @LastName = {1}, @DateOfBirth = {2}, @Phone = {3}, @Email = {4}",
        firstName, lastName, dateOfBirth, phone, email);

    }

    /// <summary>
    /// Deletes a patient asynchronously.
    /// </summary>
    /// <param name="patientId">The patient ID.</param>
    public async Task DeletePatientAsync(int patientId)
    {
        await this.Database.ExecuteSqlRawAsync("EXEC DeletePatient @PatientID = {0}", patientId);
    }

    /// <summary>
    /// Retrieves a patient by ID asynchronously.
    /// </summary>
    /// <param name="patientId">The patient ID.</param>
    /// <returns>The patient details.</returns>
    public async Task<PatientByIDResult> GetPatientByIDAsync(int patientId)
    {
        return await this.Set<PatientByIDResult>()
            .FromSqlRaw("EXEC GetPatientByID @PatientID = {0}", patientId)
            .FirstOrDefaultAsync();
    }

    #endregion
}
