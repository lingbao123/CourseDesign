using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class LoginRecord
{
    public int LoginRecordId { get; set; }
    
    public int PersonId { get; set; }
    
    [MaxLength(50)]
    public string? Result { get; set; }
    
    [MaxLength(50)]
    public string? IpAddress { get; set; }
    
    public DateTime Time { get; set; }
    
    public bool SuccessOrNot { get; set; }
}