using System;
using Xunit;
using AutoMapper;
using FraemworksDrivers.Mapping;
using static FraemworksDrivers.StoredProcedure.Entity;

public class MappingProfileTests
{
    private readonly IMapper _mapper;

    public MappingProfileTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void MappingConfiguration_IsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        config.AssertConfigurationIsValid();
    }

    [Fact]
    public void Map_TicketByDoctorResult_To_API_Domain_EntityProcedure_TicketByDoctorResult()
    {
        var source = new FraemworksDrivers.StoredProcedure.Entity.TicketByDoctorResult { Status = "Active" };
        var result = _mapper.Map<API.Domain.EntityProcedure.TicketByDoctorResult>(source);

        Assert.NotNull(result);
        Assert.Equal(Status.From(TicketStatus.Completed), result.Status);
    }

    [Fact]
    public void Map_TicketByDateResult_To_API_Domain_EntityProcedure_TicketByDateResult()
    {
        var source = new TicketByDateResult { Status = "Active" };
        var result = _mapper.Map<API.Domain.EntityProcedure.TicketByDateResult>(source);

        Assert.NotNull(result);
        Assert.Equal(Status.From(TicketStatus.Completed), result.Status);
    }

    [Fact]
    public void Map_TicketByPatientResult_To_API_Domain_EntityProcedure_TicketByPatientResult()
    {
        var source = new TicketByPatientResult { Status = "Active" };
        var result = _mapper.Map<API.Domain.EntityProcedure.TicketByPatientResult>(source);

        Assert.NotNull(result);
        Assert.Equal(Status.From(TicketStatus.Completed), result.Status);
    }

    [Fact]
    public void Convert_String_To_Status()
    {
        var source = "Active";
        var result = _mapper.Map<Status>(source);

        Assert.NotNull(result);
        Assert.Equal(Status.From(TicketStatus.Completed), result);
    }

    [Fact]
    public void Map_DoctorScheduleResult_To_API_Domain_EntityProcedure_DoctorSchedule()
    {
        var source = new DoctorScheduleResult();
        var result = _mapper.Map<API.Domain.EntityProcedure.DoctorSchedule>(source);

        Assert.NotNull(result);
    }

    [Fact]
    public void Map_DoctorAndSpecializationResult_To_API_Domain_EntityProcedure_DoctorSpecialization()
    {
        var source = new DoctorAndSpecializationResult();
        var result = _mapper.Map<API.Domain.EntityProcedure.DoctorSpecialization>(source);

        Assert.NotNull(result);
    }

    [Fact]
    public void Map_API_Domain_Entity_Patient_To_API_Infrastructure_Entity_Patient()
    {
        var source = new API.Domain.Entity.Patient("John", "Doe", new DateOnly(1990, 1, 1), "1234567890", "john.doe@example.com");
        var result = _mapper.Map<API.Infrastructure.Entity.Patient>(source);

        Assert.NotNull(result);
        Assert.Equal(source.FirstName, result.FirstName);
        Assert.Equal(source.LastName, result.LastName);
        Assert.Equal(source.DateOfBirth, result.DateOfBirth);
        Assert.Equal(source.Phone, result.Phone);
        Assert.Equal(source.Email, result.Email);
        Assert.Null(result.PatientId);
        Assert.Null(result.Tickets);
    }

    [Fact]
    public void Map_API_Infrastructure_Entity_Patient_To_API_Domain_Entity_Patient()
    {
        var source = new API.Infrastructure.Entity.Patient { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1), Phone = "1234567890", Email = "john.doe@example.com" };
        var result = _mapper.Map<API.Domain.Entity.Patient>(source);

        Assert.NotNull(result);
        Assert.Equal(source.FirstName, result.FirstName);
        Assert.Equal(source.LastName, result.LastName);
        Assert.Equal(source.DateOfBirth, result.DateOfBirth);
        Assert.Equal(source.Phone, result.Phone);
        Assert.Equal(source.Email, result.Email);
    }
}
