﻿using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class used as return of CountryService methods.
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewsletters { get; set; }
        public int? Age { get; set; }

        public override int GetHashCode() => base.GetHashCode();
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
                           person.CountryId == CountryId &&
                           person.Address == Address &&
                           person.ReceiveNewsletters == ReceiveNewsletters;

            return isEquals;
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
            var personResponse = new PersonResponse()
            {
                PersonId = person.PersonId,
                Name = person.Name,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                CountryId = person.CountryId,
                Address = person.Address,
                ReceiveNewsletters = person.ReceiveNewsletters,
                Age = (person.DateOfBirth != null) ? (int)Math.Round(DateTime.Now.Subtract(person.DateOfBirth.Value).TotalDays / 365.25) : null
            };

            return personResponse;
        }

    }
}
