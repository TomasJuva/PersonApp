using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAppLibrary.Models;
public class PersonDbModel
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PersonNumber { get; set; }

    public bool NoPersonNumber { get; set; }

    public DateTime BirthDay { get; set; } = DateTime.Now;

    public int? Sex { get; set; }

    public string? Email { get; set; }

    public int? Nationality { get; set; }

    public bool Gdpr { get; set; }

}
