using ServiceContracts.DTO.CountryDTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Adds a new country object to the list of countries.
        /// </summary>
        /// <param name="countryAddRequest">Country object to add.</param>
        /// <returns>Returns the country object after adding it.</returns>
        CountryReponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Retrieves all registered countries.
        /// </summary>
        /// <returns>Returns a list of all registered country objects.</returns>
        List<CountryReponse> GetAllCountries();

        /// <summary>
        /// Returns a Country object based on the given CountryId
        /// </summary>
        /// <param name="countryId">CountryId to search</param>
        /// <returns>Matching country as CountryResponse object</returns>
        CountryReponse? GetCountryById(Guid? countryId);
    }
}
