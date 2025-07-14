namespace CourseDesign.Models;

public class Audit//待审核表
{
    public int AuditId { get; set; }
    
    public int ApplyId { get; set; }
    
    public int TeacherId { get; set; }
}