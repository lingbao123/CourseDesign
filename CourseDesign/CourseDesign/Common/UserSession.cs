namespace CourseDesign.Common;

public class UserSession
{
    public static int PersonId { get; set; }
    public static string? PersonName { get; set; }
    public static string? PersonType { get; set; }

    public static void Clear()
    {
        PersonId = 0;
        PersonName = null;
        PersonType = null;
    }
}