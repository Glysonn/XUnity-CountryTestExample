using System.Net.Mail;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonService _personService;
        private readonly ICountryService _countryService;
        public PersonsServiceTest()
        {
            _personService = new PersonsService();
            _countryService = new CountriesService();
        }

        #region AddPerson Method

        [Fact]
        public void AddPerson_GivenPersonIsNull()
        {
            // Arrange
            PersonAddRequest? personToAdd = null;

            // Assert and Act
            Assert.Throws<ArgumentNullException>(() => _personService.AddPerson(personToAdd));
        }

        [Fact]
        public void AddPerson_GivenPersonNameIsEmpty()
        {
            // Arrange
            var personToAddEmptyName = new PersonAddRequest() { Name = string.Empty };

            // Assert and Act
            Assert.Throws<ArgumentException>(() => _personService.AddPerson(personToAddEmptyName));
        }

        [Fact]
        public void AddPerson_GivenEmailIsInvalid()
        {
            // Arrange
            var personToAdd = new PersonAddRequest();

            // Act and Assert
            Assert.Throws<FormatException>(() =>
            {
                personToAdd.Email = new MailAddress("invalid@.com");
            });
        }

        [Fact]
        public void AddPerson_ValidGivenPerson()
        {
            // Arrange
            var personToAdd = new PersonAddRequest()
            {
                Name = "Example Person",
                Email = new MailAddress("example@email.com"),
                DateOfBirth = DateTime.Now,
                Gender = GenderOption.Male,
                CountryId = Guid.NewGuid(),
                Address = "Example Address",
                ReceiveNewsletters = true,
            };

            // Act
            var addedPerson = _personService.AddPerson(personToAdd);
            var allPersonList = _personService.GetAllPersons();

            // Assert
            Assert.True(addedPerson != null && addedPerson.PersonId != Guid.Empty);
            Assert.Contains(addedPerson, allPersonList);
        }

        #endregion

        #region GetPersonById Method
        [Fact]
        public void GetPersonById_NullPersonId()
        {
            // Arrange
            Guid? personId = null;

            // Act
            var person = _personService.GetPersonById(personId);

            // Assert
            Assert.Null(person);
        }

        [Fact]
        public void GetPersonById_ValidPersonId()
        {
            // Arrange
            // Getting a country object so its CountryId can be used to create a PersonAddRequest object
            var countryToAdd = new CountryAddRequest() { CountryName = "BRAZIL" };
            var country = _countryService.AddCountry(countryToAdd);

            // Act
            var personToAdd = new PersonAddRequest()
            {
                Name = "Example Person",
                Address = "Example Address",
                Email = new MailAddress("example@email.com"),
                CountryId = country.CountryId,
                DateOfBirth = DateTime.Now,
                Gender = GenderOption.Male,
                ReceiveNewsletters = true,
            };

            var person = _personService.AddPerson(personToAdd);
            var storedPerson = _personService.GetPersonById(person.PersonId);

            // Assert
            Assert.Equal(person, storedPerson);
        }
        #endregion
    }
}
