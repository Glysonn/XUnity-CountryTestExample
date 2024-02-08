using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountryService
    {
        private readonly List<Country> _countries;
        public CountriesService()
        {
            _countries = [];
        }
        public CountryReponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            ArgumentNullException.ThrowIfNull(countryAddRequest, nameof(countryAddRequest));
            ArgumentNullException.ThrowIfNull(countryAddRequest.CountryName, nameof(countryAddRequest.CountryName));

            if (_countries.Exists(x => x.CountryName == countryAddRequest.CountryName))
                throw new ArgumentException(nameof(countryAddRequest.CountryName));

            var country = countryAddRequest.ToCountry();
            country.CountryId = Guid.NewGuid();

            _countries.Add(country);
            return country.ToCountryResponse();
        }

        public List<CountryReponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse())
                             .ToList();
        }

        public CountryReponse? GetCountryById(Guid? countryId)
        {
            throw new NotImplementedException();
        }
    }
}
