namespace CourseDesign.Models;

public class PlaceState
{
    int PlaceStateId { get; set; }
    
    int PlaceId { get; set; }
    
    DateTime StartTime { get; set; }
    
    DateTime EndTime { get; set; }
}