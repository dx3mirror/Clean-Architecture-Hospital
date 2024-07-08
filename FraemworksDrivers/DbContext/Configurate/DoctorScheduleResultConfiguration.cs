using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;

public class DoctorScheduleResultConfiguration : IEntityTypeConfiguration<DoctorScheduleResult>
{
    public void Configure(EntityTypeBuilder<DoctorScheduleResult> builder)
    {
        builder.HasNoKey();
    }
}
