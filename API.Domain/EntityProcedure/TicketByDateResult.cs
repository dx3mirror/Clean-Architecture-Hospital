
namespace API.Domain.EntityProcedure
{
    public class TicketByDateResult
    {
        public int TicketID { get; private set; }
        public string PatientFirstName { get; private set; }
        public string PatientLastName { get; private set; }
        public string DoctorFirstName { get; private set; }
        public string DoctorLastName { get; private set; }
        public string TicketTypeName { get; private set; }
        public DateTime AppointmentDateTime { get; private set; }
        public string SpecializationName { get; private set; }
        public Status Status { get; private set; }

        public TicketByDateResult(int ticketID, string patientFirstName, string patientLastName, string doctorFirstName, string doctorLastName, string ticketTypeName, double v, int v1, DateTime appointmentDateTime, string specializationName, Status status)
        {
            if (string.IsNullOrWhiteSpace(patientFirstName)) throw new ArgumentException("Patient first name cannot be null or empty", nameof(patientFirstName));
            if (string.IsNullOrWhiteSpace(patientLastName)) throw new ArgumentException("Patient last name cannot be null or empty", nameof(patientLastName));
            if (string.IsNullOrWhiteSpace(doctorFirstName)) throw new ArgumentException("Doctor first name cannot be null or empty", nameof(doctorFirstName));
            if (string.IsNullOrWhiteSpace(doctorLastName)) throw new ArgumentException("Doctor last name cannot be null or empty", nameof(doctorLastName));
            if (string.IsNullOrWhiteSpace(ticketTypeName)) throw new ArgumentException("Ticket type name cannot be null or empty", nameof(ticketTypeName));
            if (string.IsNullOrWhiteSpace(specializationName)) throw new ArgumentException("Specialization name cannot be null or empty", nameof(specializationName));

            TicketID = ticketID;
            PatientFirstName = patientFirstName;
            PatientLastName = patientLastName;
            DoctorFirstName = doctorFirstName;
            DoctorLastName = doctorLastName;
            TicketTypeName = ticketTypeName;
            AppointmentDateTime = appointmentDateTime;
            SpecializationName = specializationName;
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
            return $"Ticket ID: {TicketID}, Appointment: {AppointmentDateTime}, Type: {TicketTypeName}, Patient: {GetPatientFullName()}, Doctor: {GetDoctorFullName()}, Specialization: {SpecializationName}, Status: {Status}";
        }
    }
}
