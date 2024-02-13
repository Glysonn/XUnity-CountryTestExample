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
