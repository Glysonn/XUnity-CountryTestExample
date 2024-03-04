using Entities;
using ServiceContracts;
using ServiceContracts.DTO.PersonDTO;
using Services.Helpers;

namespace Services
{
    public class PersonsService : IPersonService
    {
        private readonly List<Person> _personList;
        private readonly ICountryService _countriesService;
        public PersonsService(ICountryService countriesService)
        {
            _personList = [];
            _countriesService = countriesService;
        }

        public PersonResponse AddPerson(PersonAddRequest? personToAdd)
        {
            ArgumentNullException.ThrowIfNull(personToAdd);
            ValidationHelper.ModelValidation(personToAdd);

            var person = personToAdd.ToPerson();
            person.PersonId = Guid.NewGuid();

            _personList.Add(person);
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            var personList = _personList.Select(x => ConvertPersonToPersonResponse(x)).ToList();
            return personList;
        }

        public PersonResponse? GetPersonById(Guid? personId)
        {
            var foundPerson = _personList?.Find(x => x.PersonId == personId);
            return foundPerson is not null ? ConvertPersonToPersonResponse(foundPerson) : null;
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
