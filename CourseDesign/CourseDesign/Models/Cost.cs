using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Cost
{
    public int CostId { get; set; }
    
    public decimal PlanValue { get; set; }
    
    public decimal ActualCost { get; set; }
    
    [MaxLength(200)]
    public required string WhereAbouts { get; set; }
    
    public bool PassOrNot { get; set; }
    
    public int WhoCheck { get; set; }
    
    public int ActivityId { get; set; }
    
    public int FileId { get; set; }
}