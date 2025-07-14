namespace CourseDesign.Models;

public class PersonRecord
{
    public int PersonRecordId { get; set; }
    
    public int PersonId { get; set; }
    
    public int OperatorId { get; set; }
    
    public string? Action { get; set; }
    
    public DateTime Time { get; set; }
}