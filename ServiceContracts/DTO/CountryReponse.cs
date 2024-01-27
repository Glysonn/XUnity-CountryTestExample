using System;
using System.Collections.Generic;
using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class used as return of CountryService methods
    /// </summary>
    public class CountryReponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }


    }

    public static class CountryExtensions
    {
        public static CountryReponse ToCountryResponse(this Country country)
        {
            return new CountryReponse() { CountryId = country.CountryId,
                                          CountryName = country.CountryName};
        }
    }
}
