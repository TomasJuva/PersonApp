using Microsoft.AspNetCore.Mvc;
using PersonAppLibrary.DataAccess;
using PersonAppLibrary.Models;
using PersonAppLibrary.Types;
using PersonAppUI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonAppUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly IPersonData personData;
    private readonly ILogger<PersonsController> logger;

    public PersonsController(IPersonData personData, ILogger<PersonsController> logger)
    {
        this.personData = personData;
        this.logger = logger;
    }
    // GET: api/<PersonsController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonModel>>> Get()
    {
        this.logger.LogInformation("GET: Persons succeeded");
        try
        {
            List<PersonDbModel> personDbList = await this.personData.GetAllPersons();
            List<PersonModel> result = new();
            foreach (PersonDbModel personDb in personDbList)
            {
                PersonModel person = new();
                person.FirstName = personDb.FirstName;
                person.LastName = personDb.LastName;
                person.PersonNumber = personDb.PersonNumber;
                person.NoPersonNumber = personDb.NoPersonNumber;
                person.BirthDay = personDb.BirthDay;
                person.Sex = (Sex?)personDb.Sex;
                person.Email = personDb.Email;
                person.Nationality = (Nationality?)personDb.Nationality;
                person.Gdpr = personDb.Gdpr;
                result.Add(person);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "The GET call to Persons failed");
            return BadRequest();
        }
    }
}
