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

    //GET COURSE STUDENTS

    public Course? GetCourseStudents(int courseId)
    {
        return _context.Courses
            .Include(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .FirstOrDefault(c => c.Id == courseId);
    }

    // REMOVE ENROLLMENT

    public string RemoveEnrollment(int studentId, int courseId)
    {
        Enrollment? enrollment = _context.Enrollments
            .FirstOrDefault(e => e.StudentId == studentId &&
                                 e.CourseId == courseId);

        if (enrollment == null)
        {
            return "Enrollment not found!";
        }

        _context.Enrollments.Remove(enrollment);
        _context.SaveChanges();

        return "Student removed from course successfully!";
    }

    //COURSE STUDENT COUNT

    public int GetCourseStudentCount(int courseId)
    {
        return _context.Enrollments
            .Count(e => e.CourseId == courseId);
    }

    //STUDENT COURSE COUNT

    public int GetStudentCourseCount(int studentId)
    {
        return _context.Enrollments
            .Count(e => e.StudentId == studentId);
    }

    //MOST POPULAR COURSE

    public Course? GetMostPopularCourse()
    {
        return _context.Courses
            .Include(c => c.Enrollments)
            .OrderByDescending(c => c.Enrollments.Count)
            .FirstOrDefault();
    }

    //MOST ACTIVE STUDENT

    public Student? GetMostActiveStudent()
    {
        return _context.Students
            .Include(s => s.Enrollments)
            .OrderByDescending(s => s.Enrollments.Count)
            .FirstOrDefault();
    }

    // STUDENT PAGINATION

    public List<Student> GetStudentsByPage(int pageNumber, int pageSize)
    {
        return _context.Students
            .OrderBy(s => s.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    // COURSE PAGINATION

    public List<Course> GetCoursesByPage(int pageNumber, int pageSize)
    {

        return _context.Courses
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    

}
