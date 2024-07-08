using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;

public class TicketByPatientResultConfiguration : IEntityTypeConfiguration<TicketByPatientResult>
{
    public void Configure(EntityTypeBuilder<TicketByPatientResult> builder)
    {
        builder.HasNoKey();
    }
}
