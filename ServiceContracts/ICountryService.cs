﻿using ServiceContracts.DTO;

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
    }
}
