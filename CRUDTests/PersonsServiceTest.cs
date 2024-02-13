using System.Net.Mail;

namespace CRUDTests
{
    public class PersonsServiceTest
    {
        private readonly IPersonService _personService;
        public PersonsServiceTest()
        {
            _personService = new PersonsService();
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
    }
}
