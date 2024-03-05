using ServiceContracts.DTO.CountryDTO;
using ServiceContracts.DTO.PersonDTO;
using System.Globalization;
using System.Net.Mail;

namespace Tests.Helpers
{
    internal static class DummyDataHelper
    {
        #region Person
        internal static PersonAddRequest CreateAddDummyPerson()
        {
            var country = CreateAddDummyCountry().ToCountry();

            var personToAdd = new PersonAddRequest()
            {
                Name = "Example Person",
                Email = new MailAddress("example@email.com"),
                DateOfBirth = DateTime.Now,
                Gender = GenderOption.Male,
                CountryId = country.CountryId,
                Address = "Example Address",
                ReceiveNewsletters = true,
            };

            return personToAdd;
        }

        internal static List<PersonAddRequest> CreateAddDummyPersonList()
        {
            var countriesToAdd = CreateAddDummyCountries();
            var countryList = countriesToAdd.Select(x => x.ToCountry());

            var brazilCountry = countryList.First(x => x.CountryName == "BRAZIL");
            var chinaCountry = countryList.First(x => x.CountryName == "CHINA");

            var person1 = new PersonAddRequest()
            {
                Name = "Person 1",
                Email = new MailAddress("person1@email.com"),
                DateOfBirth = DateTime.Parse("2001-02-13", CultureInfo.InvariantCulture),
                Gender = GenderOption.Male,
                CountryId = brazilCountry.CountryId,
                Address = "Address Example 01",
                ReceiveNewsletters = true,
            };
            var person2 = new PersonAddRequest()
            {
                Name = "Person 2",
                Email = new MailAddress("person2@email.com"),
                DateOfBirth = DateTime.Parse("2003-07-23", CultureInfo.InvariantCulture),
                Gender = GenderOption.Female,
                CountryId = brazilCountry.CountryId,
                Address = "Address Example 02",
                ReceiveNewsletters = false,
            };
            var person3 = new PersonAddRequest()
            {
                Name = "Person 3",
                Email = new MailAddress("person3@email.com"),
                DateOfBirth = DateTime.Parse("2000-04-01", CultureInfo.InvariantCulture),
                Gender = GenderOption.Others,
                CountryId = chinaCountry.CountryId,
                Address = "Address Example 03",
                ReceiveNewsletters = false,
            };

            var personsToAddList = new List<PersonAddRequest> { person1, person2, person3 };
            return personsToAddList;
        }
        #endregion

        #region Country
        internal static CountryAddRequest CreateAddDummyCountry()
        {
            return new CountryAddRequest() { CountryName = "BRAZIL" };
        }

        internal static List<CountryAddRequest> CreateAddDummyCountries()
        {
            return
            [
                new() { CountryName = "BRAZIL" },
                new() { CountryName = "CHINA" }
            ];
        }
        #endregion
    }
}
