using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Place
{
    public int PlaceId { get; set; }
    
    [MaxLength(50)]
    public string? PlaceName { get; set; }
}