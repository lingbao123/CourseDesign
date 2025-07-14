using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Area
{
    public int AreaId { get; set; }
    
    [MaxLength(50)]
    public required string AreaName { get; set; }
}