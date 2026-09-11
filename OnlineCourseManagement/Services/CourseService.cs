using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services;

public class CourseService
{
    private readonly AppDbContext _context;

    public CourseService()
    {
        _context = new AppDbContext();
    }

    // 11.1 CREATE COURSE
    public bool AddCourse(string name, string description, decimal price, int duration)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        if (price < 0)
        {
            return false;
        }

        if (duration <= 0)
        {
            return false;
        }

        Course course = new Course
        {
            Name = name,
            Description = description,
            Price = price,
            Duration = duration
        };

        _context.Courses.Add(course);
        _context.SaveChanges();

        return true;
    }

    // 11.2 GET ALL COURSES
    public List<Course> GetAllCourses()
    {
        return _context.Courses.ToList();
    }

    // 11.3 GET COURSE BY ID
    public Course? GetCourseById(int id)
    {
        return _context.Courses.Find(id);
    }

    // 11.4 SEARCH COURSE
    public List<Course> SearchCourse(string name)
    {
        return _context.Courses
            .Where(c => c.Name.Contains(name))
            .ToList();
    }

    // 11.5 FILTER COURSES BY PRICE
    public List<Course> FilterCoursesByPrice(decimal maximumPrice)
    {
        return _context.Courses
            .Where(c => c.Price <= maximumPrice)
            .ToList();
    }

    // 11.6 UPDATE COURSE
    public bool UpdateCourse(int id, decimal newPrice, int newDuration)
    {
        Course? course = _context.Courses.Find(id);

        if (course == null)
        {
            return false;
        }

        if (newPrice < 0)
        {
            return false;
        }

        if (newDuration <= 0)
        {
            return false;
        }

        course.Price = newPrice;
        course.Duration = newDuration;

        _context.SaveChanges();

        return true;
    }

    // 11.7 DELETE COURSE
    public string DeleteCourse(int id)
    {
        Course? course = _context.Courses.Find(id);

        if (course == null)
        {
            return "Course not found!";
        }

        bool hasEnrollments = _context.Enrollments
            .Any(e => e.CourseId == id);

        if (hasEnrollments)
        {
            return "Course has active enrollments. Course cannot be deleted!";
        }

        _context.Courses.Remove(course);
        _context.SaveChanges();

        return "Course deleted successfully!";
    }
}