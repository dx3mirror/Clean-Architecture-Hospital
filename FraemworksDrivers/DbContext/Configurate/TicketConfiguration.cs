using API.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC6275912C36D");

        builder.Property(e => e.TicketId).HasColumnName("TicketID");
        builder.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
        builder.Property(e => e.DoctorId).HasColumnName("DoctorID");
        builder.Property(e => e.PatientId).HasColumnName("PatientID");
        builder.Property(e => e.Status).HasMaxLength(20);
        builder.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");

        builder.HasOne(d => d.Doctor).WithMany(p => p.Tickets)
            .HasForeignKey(d => d.DoctorId)
            .HasConstraintName("FK__Tickets__DoctorI__403A8C7D");

        builder.HasOne(d => d.Patient).WithMany(p => p.Tickets)
            .HasForeignKey(d => d.PatientId)
            .HasConstraintName("FK__Tickets__Patient__3F466844");

        builder.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
            .HasForeignKey(d => d.TicketTypeId)
            .HasConstraintName("FK__Tickets__TicketT__412EB0B6");
    }
}
