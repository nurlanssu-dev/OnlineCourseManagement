using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services;

public class StudentService
{
    private readonly AppDbContext _context;

    public StudentService()
    {
        _context = new AppDbContext();
    }

    // 10.1 CREATE STUDENT
    public bool AddStudent(string fullName, string email, int age)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        if (age <= 0)
        {
            return false;
        }

        Student student = new Student
        {
            FullName = fullName,
            Email = email,
            Age = age
        };

        _context.Students.Add(student);
        _context.SaveChanges();

        return true;
    }

    // 10.2 GET ALL STUDENTS
    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    // 10.3 GET STUDENT BY ID
    public Student? GetStudentById(int id)
    {
        return _context.Students.Find(id);
    }

    // 10.4 SEARCH STUDENT
    public List<Student> SearchStudent(string name)
    {
        return _context.Students
            .Where(s => s.FullName.Contains(name))
            .ToList();
    }

    // 10.5 UPDATE STUDENT
    public bool UpdateStudent(int id, string newEmail, int newAge)
    {
        Student? student = _context.Students.Find(id);

        if (student == null)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(newEmail))
        {
            return false;
        }

        if (newAge <= 0)
        {
            return false;
        }

        student.Email = newEmail;
        student.Age = newAge;

        _context.SaveChanges();

        return true;
    }

    // 10.6 DELETE STUDENT
    public string DeleteStudent(int id)
    {
        Student? student = _context.Students.Find(id);

        if (student == null)
        {
            return "Student not found!";
        }

        bool hasEnrollments = _context.Enrollments
            .Any(e => e.StudentId == id);

        if (hasEnrollments)
        {
            return "Student has active enrollments. Student cannot be deleted!";
        }

        _context.Students.Remove(student);
        _context.SaveChanges();

        return "Student deleted successfully!";
    }
}
