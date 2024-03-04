using ServiceContracts.DTO.PersonDTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents the business logic for manipulating Person entity
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Adds a new Person into the existing List of Persons
        /// </summary>
        /// <param name="personToAdd">PersonAddRequest object to add into the list.</param>
        /// <returns>The same person details as a PersonResponse object</returns>
        PersonResponse AddPerson(PersonAddRequest? personToAdd);

        /// <summary>
        /// Retrieves all persons.
        /// </summary>
        /// <returns>Returns a list of PersonResponse</returns>
        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// Retrieves a specific person based on a given PersonId.
        /// </summary>
        /// <param name="personId">PersonId to find.</param>
        /// <returns>Returns the matching person object as a PersonResponse</returns>
        PersonResponse? GetPersonById(Guid? personId);

        /// <summary>
        /// Retrieves a list of persons based on the search field and the search string.
        /// </summary>
        /// <param name="searchBy">Search field to search</param>
        /// <param name="searchString">Search string to search</param>
        /// <returns>Return all matching persons based on the searchBy and name</returns>
        List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);
    }
}
