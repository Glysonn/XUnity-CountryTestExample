using Entities;
using System.Runtime.CompilerServices;

namespace ServiceContracts.DTO.CountryDTO
{
    /// <summary>
    /// DTO class used as return of CountryService methods
    /// </summary>
    public class CountryReponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        // Overriding to compare only the value types instead of reference
        public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != typeof(CountryReponse))
                return false;

            var countryObj = obj as CountryReponse;
            return CountryId == countryObj?.CountryId
                && CountryName == countryObj.CountryName;
        }
    }

    public static class CountryExtensions
    {
        public static CountryReponse ToCountryResponse(this Country country)
        {
            return new CountryReponse()
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
        }
    }
}
