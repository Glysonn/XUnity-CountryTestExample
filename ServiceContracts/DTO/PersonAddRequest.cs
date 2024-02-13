using ServiceContracts.Enums;
using Entities;
using System.Net.Mail;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class for adding a new Person.
    /// </summary>
    public class PersonAddRequest
    {
        public string? Name { get; set; }
        public MailAddress? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOption? Gender { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public bool? ReceiveNewsletters { get; set; }

        /// <summary>
        /// Convert the current object of PersonAddRequest to a new Person object.
        /// </summary>
        /// <returns></returns>
        public Person ToPerson()
        {
            var person = new Person()
            {
                Name = Name,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryId = CountryId,
                Address = Address,
                ReceiveNewsletters = ReceiveNewsletters
            };

            return person;
        }
    }
}
