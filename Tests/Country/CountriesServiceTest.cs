using ServiceContracts.DTO.CountryDTO;

namespace Tests.Country
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
            var countryRequest = DummyDataHelper.CreateAddDummyCountry();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countryService.AddCountry(countryRequest);
                _countryService.AddCountry(countryRequest);
            });
        }

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            // Arrange
            var countryRequest = DummyDataHelper.CreateAddDummyCountry();

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
            var countriesToAdd = DummyDataHelper.CreateAddDummyCountries();

            // Act
            var addedCountries = new List<CountryReponse>();

            foreach (var country in countriesToAdd)
                addedCountries.Add(_countryService.AddCountry(country));

            // Assert
            var countryList = _countryService.GetAllCountries();
            Assert.All(addedCountries, country => Assert.Contains(country, countryList));
        }

        #endregion

        #region GetCountryById
        [Fact]
        public void GetCountryById_NullOrEmptyCountryId()
        {
            // Arrange
            Guid? countryId = null;
            var emptyCountryId = Guid.Empty;

            // Act
            var retrievedCountry = _countryService.GetCountryById(countryId);
            var emptyGuidretrievedCountry = _countryService.GetCountryById(emptyCountryId);

            // Assert
            Assert.Null(retrievedCountry);
            Assert.Null(emptyGuidretrievedCountry);
        }

        [Fact]
        public void GetCountryById_ValidCountryId()
        {
            // Arrange
            var countryToAdd = DummyDataHelper.CreateAddDummyCountry();
            var countryResponse = _countryService.AddCountry(countryToAdd);

            // Act
            var retrievedCountry = _countryService.GetCountryById(countryResponse.CountryId);

            // Assert
            Assert.Equal(countryResponse, retrievedCountry);
        }
        #endregion
    }
}
