using Entities;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;

namespace ServiceContracts.DTO.PersonDTO
{
    /// <summary>
    /// DTO class used as return of CountryService methods.
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? Name { get; set; }
        public MailAddress? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? CountryName { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewsletters { get; set; }
        public int? Age { get; set; }

        // Overriding to compare only the value types instead of reference
        public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (obj.GetType() != typeof(PersonResponse))
                return false;

            var person = (PersonResponse)obj;

            var isEquals = person.PersonId == PersonId &&
                           person.Name == Name &&
                           person.Email == Email &&
                           person.DateOfBirth == DateOfBirth &&
                           person.CountryName == CountryName &&
                           person.Address == Address &&
                           person.ReceiveNewsletters == ReceiveNewsletters;

            return isEquals;
        }
        public override string ToString()
        {
            var sb = new StringBuilder().Append($"ID: {PersonId}, ")
                                        .Append($"Name: {Name}, ")
                                        .Append($"Email: {Email?.Address}, ")
                                        .Append($"Bith Date: {DateOfBirth:yyyy-MM-dd}, ")
                                        .Append($"Age: {Age}, ")
                                        .Append($"Gender: {Gender}, ")
                                        .Append($"Country Name: {CountryName}, ")
                                        .Append($"Recieve NewsLetter: {ReceiveNewsletters}");
            return sb.ToString();
        }
    }

    public static class PersonExtensions
    {
        /// <summary>
        /// Converts the Person object into a new PersonResponse object.
        /// </summary>
        /// <param name="person">Person object to convert</param>
        /// <returns>Converted Person as PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            var currentTime = DateTime.Now;
            var personResponse = new PersonResponse()
            {
                PersonId = person.PersonId,
                Name = person.Name,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                Address = person.Address,
                ReceiveNewsletters = person.ReceiveNewsletters,
                Age = person.DateOfBirth != null ? (int)Math.Round(currentTime.Subtract(person.DateOfBirth.Value).TotalDays / 365.25) : null
            };

            return personResponse;
        }

    }
}
