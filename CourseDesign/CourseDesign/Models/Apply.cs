using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Apply
{
    public int ApplyId { get; set; }
    
    public DateTime SubmitTime { get; set; }
    
    [MaxLength(100)]
    public required string ApplyName { get; set; }
    
    [MaxLength(50)]
    public string? ActivityType { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public int OrganizerId { get; set; }
    
    public int TeacherId { get; set; }
    
    public decimal Budget { get; set; }
    
    public int PerpleNumber { get; set; }
    
    [MaxLength(2000)]
    public string? Introduction { get; set; }
}