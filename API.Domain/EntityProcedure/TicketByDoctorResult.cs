
namespace API.Domain.EntityProcedure
{
    public class TicketByDoctorResult
    {
        public int TicketID { get; private set; }
        public DateTime AppointmentDateTime { get; private set; }
        public string TicketTypeName { get; private set; }
        public string PatientFirstName { get; private set; }
        public string PatientLastName { get; private set; }
        public Status Status { get; private set; }

        public TicketByDoctorResult(int ticketID, DateTime appointmentDateTime, string ticketTypeName, string patientFirstName, string patientLastName, Status status)
        {
            if (string.IsNullOrWhiteSpace(ticketTypeName)) throw new ArgumentException("Ticket type name cannot be null or empty", nameof(ticketTypeName));
            if (string.IsNullOrWhiteSpace(patientFirstName)) throw new ArgumentException("Patient first name cannot be null or empty", nameof(patientFirstName));
            if (string.IsNullOrWhiteSpace(patientLastName)) throw new ArgumentException("Patient last name cannot be null or empty", nameof(patientLastName));

            TicketID = ticketID;
            AppointmentDateTime = appointmentDateTime;
            TicketTypeName = ticketTypeName;
            PatientFirstName = patientFirstName;
            PatientLastName = patientLastName;
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }

        public void UpdateStatus(Status newStatus)
        {
            Status = newStatus ?? throw new ArgumentNullException(nameof(newStatus));
        }

        public string GetPatientFullName()
        {
            return $"{PatientFirstName} {PatientLastName}";
        }

        public void RescheduleAppointment(DateTime newAppointmentDateTime)
        {
            if (newAppointmentDateTime <= DateTime.Now) throw new ArgumentException("New appointment date and time must be in the future", nameof(newAppointmentDateTime));
            AppointmentDateTime = newAppointmentDateTime;
        }

        public override string ToString()
        {
            return $"Ticket ID: {TicketID}, Appointment: {AppointmentDateTime}, Type: {TicketTypeName}, Patient: {GetPatientFullName()}, Status: {Status}";
        }
    }

}
