using ServiceContracts.DTO.PersonDTO;
using System.Net.Mail;

namespace Tests.PersonTest
{
    public class PersonsServiceTest
    {
        private readonly IPersonService _personService;
        private readonly ICountryService _countryService;
        private readonly ITestOutputHelper _outputHelper;

        public PersonsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _countryService = new CountriesService();
            _personService = new PersonsService(_countryService);
            _outputHelper = testOutputHelper;
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
            var personToAdd = DummyDataHelper.CreateAddDummyPerson();

            // Act
            var addedPerson = _personService.AddPerson(personToAdd);
            var allPersonList = _personService.GetAllPersons();

            // Assert
            Assert.True(addedPerson != null && addedPerson.PersonId != Guid.Empty);
            Assert.Contains(addedPerson, allPersonList);
        }

        #endregion

        #region GetPerson Methods
        [Fact]
        public void GetAllPersons_EmptyByDefault()
        {
            // Act
            var personList = _personService.GetAllPersons();

            // Assert
            Assert.Empty(personList);
        }

        [Fact]
        public void GetAllPersons_AddFewPersons()
        {
            // Arrange
            var addedPersonsList = new List<PersonResponse>();

            _outputHelper.WriteLine("Expected value:");
            var personsToAdd = DummyDataHelper.CreateAddDummyPersonList();
            foreach (var person in personsToAdd)
            {
                var addedPerson = _personService.AddPerson(person);
                _outputHelper.WriteLine(addedPerson.ToString());

                addedPersonsList.Add(addedPerson);
            }

            // Act 
            _outputHelper.WriteLine("Current value:");
            var storedPersons = _personService.GetAllPersons();
            foreach (var addedPerson in addedPersonsList)
            {
                _outputHelper.WriteLine(addedPerson.ToString());
                Assert.Contains(addedPerson, storedPersons);
            }
        }

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
            var personToAdd = DummyDataHelper.CreateAddDummyPerson();

            // Act
            var person = _personService.AddPerson(personToAdd);
            var storedPerson = _personService.GetPersonById(person.PersonId);

            // Assert
            Assert.Equal(person, storedPerson);
        }
        #endregion
    }
}
