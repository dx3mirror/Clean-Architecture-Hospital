using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;

public class PatientByIDResultConfiguration : IEntityTypeConfiguration<PatientByIDResult>
{
    public void Configure(EntityTypeBuilder<PatientByIDResult> builder)
    {
        builder.HasNoKey();
    }
}
