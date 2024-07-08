
namespace API.Domain.EntityProcedure
{ 
    public class TicketByPatientResult
    {
        public int TicketID { get; private set; }
        public DateTime AppointmentDateTime { get; private set; }
        public string TicketTypeName { get; private set; }
        public string DoctorFirstName { get; private set; }
        public string DoctorLastName { get; private set; }
        public string SpecializationName { get; private set; }
        public Status Status { get; private set; }

        public TicketByPatientResult(int ticketID, DateTime appointmentDateTime, string ticketTypeName, string doctorFirstName, string doctorLastName, string specializationName, Status status)
        {
            if (string.IsNullOrWhiteSpace(ticketTypeName)) throw new ArgumentException("Ticket type name cannot be null or empty", nameof(ticketTypeName));
            if (string.IsNullOrWhiteSpace(doctorFirstName)) throw new ArgumentException("Doctor first name cannot be null or empty", nameof(doctorFirstName));
            if (string.IsNullOrWhiteSpace(doctorLastName)) throw new ArgumentException("Doctor last name cannot be null or empty", nameof(doctorLastName));
            if (string.IsNullOrWhiteSpace(specializationName)) throw new ArgumentException("Specialization name cannot be null or empty", nameof(specializationName));

            TicketID = ticketID;
            AppointmentDateTime = appointmentDateTime;
            TicketTypeName = ticketTypeName;
            DoctorFirstName = doctorFirstName;
            DoctorLastName = doctorLastName;
            SpecializationName = specializationName;
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        public void UpdateStatus(Status newStatus)
        {
            Status = newStatus ?? throw new ArgumentNullException(nameof(newStatus));
        }

        public string GetDoctorFullName()
        {
            return $"{DoctorFirstName} {DoctorLastName}";
        }

        public void RescheduleAppointment(DateTime newAppointmentDateTime)
        {
            if (newAppointmentDateTime <= DateTime.Now) throw new ArgumentException("New appointment date and time must be in the future", nameof(newAppointmentDateTime));
            AppointmentDateTime = newAppointmentDateTime;
        }

        public override string ToString()
        {
            return $"Ticket ID: {TicketID}, Appointment: {AppointmentDateTime}, Type: {TicketTypeName}, Doctor: {GetDoctorFullName()}, Specialization: {SpecializationName}, Status: {Status}";
        }
    }

}
