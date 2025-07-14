namespace CourseDesign.Models;

public class Budget
{
    public int BudgetId { get; set; }
    
    public decimal BudgetValue { get; set; }
    
    public required string BudgetWhereAbouts { get; set; }
    
    public int ApplyId { get; set; }
}