using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class ReimbursementRecord
{
    public int ReimbursementRecordId { get; set; }
    
    public int CostId { get; set; }
    
    public int PersonId { get; set; }
    
    public DateTime Time { get; set; }
    
    public bool PassOrNot { get; set; }
    
    [MaxLength(1000)]
    public string? Note { get; set; }
}