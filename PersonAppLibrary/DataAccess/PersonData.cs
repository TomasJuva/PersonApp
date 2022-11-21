using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonAppLibrary.Models;

namespace PersonAppLibrary.DataAccess;
public class PersonData : IPersonData
{
    private readonly ISqlDataAccess sql;

    public PersonData(ISqlDataAccess sql)
    {
        this.sql = sql;
    }

    public async Task<List<PersonDbModel>> GetAllPersons()
    {
        List<PersonDbModel> persons = await this.sql.LoadData<PersonDbModel, dynamic>("dbo.spGetAllPersons", new { }, "Default");
        return persons;
    }

    public async Task InsertPerson(PersonDbModel person)
    {
        await this.sql.SaveData<dynamic>("dbo.spInsertPerson", person, "Default");
    }
}
