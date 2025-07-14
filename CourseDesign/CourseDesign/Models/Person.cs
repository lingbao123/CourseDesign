using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Person
{
    public int PersonId { get; set; }
    
    [MaxLength(100)]
    public required string PersonName { get; set; }
    
    [MaxLength(200)]
    public required string Password { get; set; }
    
    public required string PersonType { get; set; }
    
    public int PersonSuperId { get; set; }

    public Person() { }

    public Person(string personName, string password, string personType)
    {
        PersonName = personName;
        Password = password;
        PersonType = personType;
    }
}