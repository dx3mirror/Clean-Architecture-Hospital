using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69EA5EBE9F");

        builder.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
        builder.Property(e => e.DoctorId).HasColumnName("DoctorID");

        builder.HasOne(d => d.Doctor).WithMany(p => p.Schedules)
            .HasForeignKey(d => d.DoctorId)
            .HasConstraintName("FK__Schedules__Docto__440B1D61");
    }
}
