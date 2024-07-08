using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EDF4CBFD88F");

        builder.Property(e => e.DoctorId).HasColumnName("DoctorID");
        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(50);
        builder.Property(e => e.LastName).HasMaxLength(50);
        builder.Property(e => e.Phone).HasMaxLength(15);
        builder.Property(e => e.SpecializationId).HasColumnName("SpecializationID");

        builder.HasOne(d => d.Specialization).WithMany(p => p.Doctors)
            .HasForeignKey(d => d.SpecializationId)
            .HasConstraintName("FK_Doctors_Specializations");
    }
}
