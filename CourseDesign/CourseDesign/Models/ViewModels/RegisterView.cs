namespace CourseDesign.Models.ViewModels;

public class RegisterView
{
    public required string Name { get; set; }
    
    public required string Password  { get; set; }
    
    public required string CheckPassword { get; set; }
}