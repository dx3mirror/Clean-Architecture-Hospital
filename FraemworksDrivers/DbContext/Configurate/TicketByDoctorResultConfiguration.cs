using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;

public class TicketByDoctorResultConfiguration : IEntityTypeConfiguration<TicketByDoctorResult>
{
    public void Configure(EntityTypeBuilder<TicketByDoctorResult> builder)
    {
        builder.HasNoKey();
    }
}
