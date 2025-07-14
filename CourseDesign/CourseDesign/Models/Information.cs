using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Information
{
    public int InformationId { get; set; }
    
    public int FromId { get; set; }
    
    public int ToId { get; set; }
    
    [MaxLength(100)]
    public required string Title { get; set; }
    
    public required string Content { get; set; }
    
    public DateTime Time { get; set; }
    
    public bool ReadOrNot { get; set; }
}