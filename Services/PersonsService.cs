using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
    public class PersonsService : IPersonService
    {
        private readonly List<Person> _personList;
        private readonly ICountryService _countriesService;
        public PersonsService()
        {
            _personList = [];
            _countriesService = new CountriesService();
        }

        public PersonResponse AddPerson(PersonAddRequest? personToAdd)
        {
            ArgumentNullException.ThrowIfNull(personToAdd, nameof(personToAdd));
            ValidationHelper.ModelValidation(personToAdd);

            var person = personToAdd.ToPerson();
            person.PersonId = Guid.NewGuid();

            _personList.Add(person);
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            var personList = _personList.Select(x => x.ToPersonResponse()).ToList();
            return personList;
        }

        public PersonResponse? GetPersonById(Guid? personId)
        {
            var foundPerson = _personList?.Find(x => x.PersonId == personId);
            return foundPerson?.ToPersonResponse();
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
        {
            throw new NotImplementedException();
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            var personResponse = person.ToPersonResponse();
            personResponse.CountryName = _countriesService.GetCountryById(person.CountryId)?.CountryName;

            return personResponse;
        }
    }
}
