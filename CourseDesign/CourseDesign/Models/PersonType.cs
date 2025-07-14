using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class PersonType
{
    [MaxLength(20)]
    public required string PersonTypeName { get; set; }
}