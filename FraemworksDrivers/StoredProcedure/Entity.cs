
namespace FraemworksDrivers.StoredProcedure
{
    public class Entity
    {
        public class TicketByDateResult
        {
            public int TicketID { get; set; }
            public string PatientFirstName { get; set; }
            public string PatientLastName { get; set; }
            public string DoctorFirstName { get; set; }
            public string DoctorLastName { get; set; }
            public string TicketTypeName { get; set; }
            public DateTime AppointmentDateTime { get; set; }
            public string SpecializationName { get; set; }
            public string Status { get; set; }
        }

        public class TicketByDoctorResult
        {
            public int TicketID { get; set; }
            public DateTime AppointmentDateTime { get; set; }
            public string TicketTypeName { get; set; }
            public string PatientFirstName { get; set; }
            public string PatientLastName { get; set; }
            public string Status { get; set; }
        }

        public class TicketByPatientResult
        {
            public int TicketID { get; set; }
            public DateTime AppointmentDateTime { get; set; }
            public string TicketTypeName { get; set; }
            public string DoctorFirstName { get; set; }
            public string DoctorLastName { get; set; }
            public string SpecializationName { get; set; }
            public string Status { get; set; }
        }

        public class DoctorScheduleResult
        {
            public int ScheduleID { get; set; }
            public DateTime WorkDay { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
        }

        public class DoctorAndSpecializationResult
        {
            public int DoctorID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SpecializationName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }

        public class NewPatientResult
        {
            public int NewPatientID { get; set; }
        }

        public class PatientByIDResult
        {
            public int PatientID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }

    }
}
