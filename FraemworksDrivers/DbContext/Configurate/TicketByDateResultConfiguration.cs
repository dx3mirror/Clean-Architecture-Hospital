using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FraemworksDrivers.StoredProcedure.Entity;
public class TicketByDateResultConfiguration : IEntityTypeConfiguration<TicketByDateResult>
{
    public void Configure(EntityTypeBuilder<TicketByDateResult> builder)
    {
        builder.HasNoKey();
    }
}
