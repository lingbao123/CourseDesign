using System.ComponentModel.DataAnnotations;

namespace CourseDesign.Models;

public class Files
{
    public int FileId { get; set; }
    
    [MaxLength(200)]
    public required string FileName { get; set; }
    
    [MaxLength(300)]
    public required string FileAddress { get; set; }
}