namespace CourseDesign.Models;

public class ActivityRecord
{
    public int ActivityRecordId { get; set; }
    
    public int ActivityId { get; set; }
    
    public int PersonId { get; set; }
    
    public string? Action { get; set; }
    
    public DateTime Time { get; set; }
}