using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(e => e.SpecializationId).HasName("PK__Speciali__5809D84F09B55BD5");

        builder.Property(e => e.SpecializationId).HasColumnName("SpecializationID");
        builder.Property(e => e.SpecializationName).HasMaxLength(100);
    }
}
