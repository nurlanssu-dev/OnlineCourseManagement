using OnlineCourseManagement.Data;
using OnlineCourseManagement.Models;

using AppDbContext context = new AppDbContext();
#region yoxlama1
//Console.Write("Enter full name: ");
//string fullName = Console.ReadLine();

//Console.Write("Enter email: ");
//string email = Console.ReadLine();

//Console.Write("Enter age: ");
//int age = int.Parse(Console.ReadLine());

//Student student = new Student
//{
//    FullName = fullName,
//    Email = email,
//    Age = age
//};

//context.Students.Add(student);
//context.SaveChanges();

//Console.WriteLine("Student added successfully!");
#endregion
#region yoxlama2
//var students = context.Students.ToList();

//foreach (var student in students)
//{
//    Console.WriteLine(
//        $"ID: {student.Id} |Student Name: {student.FullName} |Student Email: {student.Email} |Student Age: {student.Age}"
//    );
//}
#endregion
#region yoxlama3
//Console.Write("Enter student id: ");
//int id = int.Parse(Console.ReadLine());

//var student = context.Students
//    .FirstOrDefault(s => s.Id == id);

//if (student != null)
//{
//    Console.WriteLine($"Id: {student.Id}");
//    Console.WriteLine($"Full Name: {student.FullName}");
//    Console.WriteLine($"Email: {student.Email}");
//    Console.WriteLine($"Age: {student.Age}");
//    Console.WriteLine($"Created At: {student.CreatedAt:yyyy-MM-dd}");
//}
//else
//{
//    Console.WriteLine("Student not found!");
//}
#endregion
