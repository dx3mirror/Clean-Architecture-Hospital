using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3462D6B724A");

        builder.Property(e => e.PatientId).HasColumnName("PatientID");
        builder.Property(e => e.Email).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(50);
        builder.Property(e => e.LastName).HasMaxLength(50);
        builder.Property(e => e.Phone).HasMaxLength(15);
    }
}
