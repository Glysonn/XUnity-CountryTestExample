using ServiceContracts.DTO;

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
        PersonResponse GetPersonById(Guid? personId);
    }
}
