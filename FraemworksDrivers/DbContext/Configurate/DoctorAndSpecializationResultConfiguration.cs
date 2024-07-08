using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;

public class DoctorAndSpecializationResultConfiguration : IEntityTypeConfiguration<DoctorAndSpecializationResult>
{
    public void Configure(EntityTypeBuilder<DoctorAndSpecializationResult> builder)
    {
        builder.HasNoKey();
    }
}
