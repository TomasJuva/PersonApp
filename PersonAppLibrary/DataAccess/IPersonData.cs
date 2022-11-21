using PersonAppLibrary.Models;

namespace PersonAppLibrary.DataAccess;
public interface IPersonData
{
    Task<List<PersonDbModel>> GetAllPersons();
    Task InsertPerson(PersonDbModel person);
}
