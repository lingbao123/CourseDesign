using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Activity
{
    public int ActivityId { get; set; }
    
    [MaxLength(200)]
    public required string ActivityName { get; set; }
    
    [MaxLength(50)]
    public string? ActivityState { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public int OrganizerId { get; set; }
    
    public int TeacherId { get; set; }
    
    public decimal Budget { get; set; }
    
    public decimal Cost { get; set; }
    
    [MaxLength(50)]
    public string? ActivityType { get; set; }
    
    public int PeopleNum { get; set; }
    
    [MaxLength(2000)]
    public string? Introduction { get; set; }
    
    [MaxLength(2000)]
    public string? ActivityStudentSummary { get; set; }
    
    [MaxLength(2000)]
    public string? ActivityTeacherummary { get; set; }
}