
namespace API.Domain.EntityProcedure
{
    public class DoctorSpecialization
    {
        public int DoctorID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string SpecializationName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public DoctorSpecialization(int doctorID, string firstName, string lastName, string specializationName, string phone, string email)
        {
            DoctorID = doctorID;
            FirstName = firstName;
            LastName = lastName;
            SpecializationName = specializationName;
            Phone = phone;
            Email = email;

            Validate();
        }

        private void Validate()
        {
            if (DoctorID <= 0)
                throw new ArgumentException("Doctor ID must be greater than zero.");

            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("First name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Last name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(SpecializationName))
                throw new ArgumentException("Specialization name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(Phone))
                throw new ArgumentException("Phone number cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email))
                throw new ArgumentException("Invalid email address.");
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by the RFC
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateContactInformation(string phone, string email)
        {
            Phone = phone;
            Email = email;

            if (string.IsNullOrWhiteSpace(Phone))
                throw new ArgumentException("Phone number cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(Email) || !IsValidEmail(Email))
                throw new ArgumentException("Invalid email address.");
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return $"Doctor ID: {DoctorID}, Name: {GetFullName()}, Specialization: {SpecializationName}, Phone: {Phone}, Email: {Email}";
        }
    }

}
