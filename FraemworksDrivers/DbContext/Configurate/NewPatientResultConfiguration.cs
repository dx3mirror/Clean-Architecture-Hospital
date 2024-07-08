using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;

public class NewPatientResultConfiguration : IEntityTypeConfiguration<NewPatientResult>
{
    public void Configure(EntityTypeBuilder<NewPatientResult> builder)
    {
        builder.HasNoKey();
    }
}
