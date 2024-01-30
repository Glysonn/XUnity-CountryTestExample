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

            // Assert
            Assert.True(countryResponse.CountryId != Guid.Empty);
        }
    }
}
