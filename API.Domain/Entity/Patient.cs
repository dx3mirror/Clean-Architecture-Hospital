using System.Text.RegularExpressions;

namespace API.Domain.Entity
{
    public partial class Patient
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        private Patient() { }

        public Patient(string firstName, string lastName, DateOnly? dateOfBirth, string? phone, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
        }

        public static Patient Create(string firstName, string lastName, DateOnly? dateOfBirth, string? phone, string? email)
        {
            firstName = Capitalize(firstName);
            lastName = Capitalize(lastName);
            phone = FormatPhone(phone);
            ValidateEmail(email);

            return new Patient(firstName, lastName, dateOfBirth, phone, email);
        }

        private static string Capitalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or empty.");
            }
            return char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }

        private static string? FormatPhone(string? phone)
        {
            if (phone != null && !phone.StartsWith("+"))
            {
                phone = "+" + phone;
            }
            if (phone != null && !Regex.IsMatch(phone, @"^\+?[1-9]\d{1,14}$"))
            {
                throw new ArgumentException("Phone number is not in a valid format.");
            }
            return phone;
        }

        /// <summary>
        /// Validates if the given email address is in a valid format.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <exception cref="ArgumentException">Thrown if the email address is not in a valid format.</exception>
        private static bool ValidateEmail(string? email)
        {
            if (email != null && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            return true;
        }


        public void SetFirstName(string firstName)
        {
            FirstName = Capitalize(firstName);
        }

        public void SetLastName(string lastName)
        {
            LastName = Capitalize(lastName);
        }

        public void SetDateOfBirth(DateOnly? dateOfBirth)
        {
            if (dateOfBirth != null && dateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
            DateOfBirth = dateOfBirth;
        }

        public void SetPhone(string? phone)
        {
            Phone = FormatPhone(phone);
        }

        public void SetEmail(string? email)
        {
            ValidateEmail(email);
            Email = email;
        }

        public void UpdatePatientInfo(string firstName, string lastName, DateOnly? dateOfBirth, string? phone, string? email)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetDateOfBirth(dateOfBirth);
            SetPhone(phone);
            SetEmail(email);
        }

        public override string ToString()
        {
            return $"Patient: {FirstName} {LastName}, Date of Birth: {DateOfBirth}, Phone: {Phone}, Email: {Email}";
        }
    }
}
