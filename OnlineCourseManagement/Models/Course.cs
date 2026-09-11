namespace OnlineCourseManagement.Models;

public class Course
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Duration { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<Enrollment> Enrollments { get; set; } = new();
}
