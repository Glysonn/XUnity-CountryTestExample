﻿using Entities;
using ServiceContracts;
using ServiceContracts.DTO.CountryDTO;

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
            ArgumentNullException.ThrowIfNull(countryAddRequest);
            ArgumentNullException.ThrowIfNull(countryAddRequest.CountryName);

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
            if (countryId is null || countryId == Guid.Empty)
                return null;

            var matchingCountry = _countries.Find(x => x.CountryId == countryId);

            var countryResponse = matchingCountry?.ToCountryResponse();
            return countryResponse;
        }
    }
}
