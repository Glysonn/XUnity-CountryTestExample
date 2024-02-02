using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountryService _countryService;

        public CountriesServiceTest()
        {
            _countryService = new CountriesService();
        }

        #region AddCountry Method

        [Fact]
        public void AddCountry_GivenCountryIsNull()
        {
            // Arrange
            CountryAddRequest? requestCountry = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _countryService.AddCountry(requestCountry);
            });
        }

        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            // Arrange
            var requestCountry = new CountryAddRequest()
            {
                CountryName = null
            };

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _countryService.AddCountry(requestCountry);
            });
        }

        [Fact]
        public void AddCountry_CountryNameAlreadyExists()
        {
            // Arrange
            var countryRequest1 = new CountryAddRequest() { CountryName = "BRAZIL" };
            var countryRequest2 = new CountryAddRequest() { CountryName = "BRAZIL" };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countryService.AddCountry(countryRequest1);
                _countryService.AddCountry(countryRequest2);
            });
        }

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            // Arrange
            var countryRequest = new CountryAddRequest() { CountryName = "BRAZIL" };

            // Act
            var countryResponse = _countryService.AddCountry(countryRequest);
            var allCountries = _countryService.GetAllCountries();

            // Assert
            Assert.True(countryResponse.CountryId != Guid.Empty);
            Assert.Contains(countryResponse, allCountries);
        }

        #endregion

        #region GetAllCountries Method

        [Fact]
        public void GetAllCountries_CountriesListIsEmpty()
        {
            // Act
            var registeredCountries = _countryService.GetAllCountries();

            // Assert
            Assert.Empty(registeredCountries);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            // Arrange
            var countriesToAdd = new List<CountryAddRequest>()
            {
                new() { CountryName = "BRAZIL" },
                new() { CountryName = "SINGAPORE"},
                new() { CountryName = "CHINA"},
            };

            // Act
            var addedCountries = new List<CountryReponse>();
            
            foreach (var country in countriesToAdd)
                addedCountries.Add(_countryService.AddCountry(country));

            // Assert
            var countryList = _countryService.GetAllCountries();
            Assert.All(addedCountries, country => Assert.Contains(country, countryList));

        }
        #endregion
    }
}
