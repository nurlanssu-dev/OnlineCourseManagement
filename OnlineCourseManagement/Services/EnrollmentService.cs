using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services;

public class EnrollmentService
{
    private readonly AppDbContext _context;

    public EnrollmentService()
    {
        _context = new AppDbContext();
    }

    //ENROLL STUDENT

    public string EnrollStudent(int studentId, int courseId)
    {
        Student? student = _context.Students.Find(studentId);

        if (student == null)
        {
            return "Student not found!";
        }

        Course? course = _context.Courses.Find(courseId);

        if (course == null)
        {
            return "Course not found!";
        }

        bool alreadyEnrolled = _context.Enrollments
            .Any(e => e.StudentId == studentId &&
                      e.CourseId == courseId);

        if (alreadyEnrolled)
        {
            return "Student is already enrolled in this course!";
        }

        Enrollment enrollment = new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId
        };

        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();

        return "Student enrolled successfully!";
    }

    //DUPLICATE ENROLLMENT

    public bool IsAlreadyEnrolled(int studentId, int courseId)
    {
        return _context.Enrollments
            .Any(e => e.StudentId == studentId && e.CourseId == courseId);
    }

    //GET ALL ENROLLMENTS

    public List<Enrollment> GetAllEnrollments()
    {
        return _context.Enrollments
             .Include(e => e.Student)
             .Include(e => e.Course)
             .ToList();
    }

    //GET STUDENT COURSES

    public Student? GetStudentCourses(int studentId)
    {
        return _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .FirstOrDefault(s => s.Id == studentId);
    }
}
