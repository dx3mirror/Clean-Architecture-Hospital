using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        builder.HasKey(e => e.TicketTypeId).HasName("PK__TicketTy__6CD68451729A1724");

        builder.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");
        builder.Property(e => e.TicketTypeName).HasMaxLength(50);
    }
}
