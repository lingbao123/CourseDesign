using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class ApplyRecord
{
    public int ApplyRecordId { get; set; }
    
    public int ApplyId { get; set; }
    
    public int TeacherId { get; set; }
    
    [MaxLength(1000)]
    public string? Suggestion { get; set; }
    
    public DateTime Time { get; set; }
    
    public bool PassOrNot { get; set; }
    
    public int ActivityId { get; set; }
}