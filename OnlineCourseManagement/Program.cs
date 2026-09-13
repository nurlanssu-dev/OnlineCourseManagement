using OnlineCourseManagement.Services;

StudentService studentService = new StudentService();
CourseService courseService = new CourseService();
EnrollmentService enrollmentService = new EnrollmentService();


while (true)
{
    Console.WriteLine("\n==============================");
    Console.WriteLine(" ONLINE COURSE MANAGEMENT");
    Console.WriteLine("==============================");

    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Get All Students");
    Console.WriteLine("3. Get Student By Id");
    Console.WriteLine("4. Search Student");
    Console.WriteLine("5. Update Student");
    Console.WriteLine("6. Delete Student");

    Console.WriteLine();

    Console.WriteLine("7. Add Course");
    Console.WriteLine("8. Get All Courses");
    Console.WriteLine("9. Get Course By Id");
    Console.WriteLine("10. Search Course");
    Console.WriteLine("11. Filter Course By Price");
    Console.WriteLine("12. Update Course");
    Console.WriteLine("13. Delete Course");

    Console.WriteLine();

    Console.WriteLine("14. Enroll Student");
    Console.WriteLine("15. Get All Enrollments");
    Console.WriteLine("16. Get Student Courses");
    Console.WriteLine("17. Get Course Students");
    Console.WriteLine("18. Remove Enrollment");

    Console.WriteLine();

    Console.WriteLine("19. Course Pagination");

    Console.WriteLine("0. Exit");

    Console.Write("\nChoose option: ");

    int option = int.Parse(Console.ReadLine());


    switch (option)
    {

        // ADD STUDENT
        case 1:

            Console.Write("Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());


            bool result = studentService.AddStudent(fullName, email, age);

            Console.WriteLine(
                result
                ? "Student added successfully!"
                : "Student add failed!"
            );

            break;



        // GET ALL STUDENTS
        case 2:

            var students = studentService.GetAllStudents();

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Id} | {student.FullName} | {student.Email} | {student.Age}"
                );
            }

            break;



        // GET STUDENT BY ID
        case 3:

            Console.Write("Student Id: ");
            int studentId = int.Parse(Console.ReadLine());

            var studentById = studentService.GetStudentById(studentId);

            if (studentById == null)
            {
                Console.WriteLine("Student not found!");
            }
            else
            {
                Console.WriteLine(
                    $"{studentById.Id} | {studentById.FullName} | {studentById.Email}"
                );
            }

            break;



        // SEARCH STUDENT
        case 4:

            Console.Write("Name: ");
            string searchName = Console.ReadLine();

            var searchResult = studentService.SearchStudent(searchName);

            foreach (var student in searchResult)
            {
                Console.WriteLine(
                    $"{student.Id} | {student.FullName}"
                );
            }

            break;



        // ADD COURSE
        case 7:

            Console.Write("Course Name: ");
            string courseName = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Duration: ");
            int duration = int.Parse(Console.ReadLine());


            bool courseResult =
                courseService.AddCourse(
                    courseName,
                    description,
                    price,
                    duration
                );


            Console.WriteLine(
                courseResult
                ? "Course added successfully!"
                : "Course add failed!"
            );

            break;



        // GET ALL COURSES
        case 8:

            var courses = courseService.GetAllCourses();

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"{course.Id} | {course.Name} | {course.Price}"
                );
            }

            break;



        // COURSE PAGINATION
        case 19:

            Console.Write("Page Size: ");
            int pageSize = int.Parse(Console.ReadLine());


            Console.Write("Page Number: ");
            int pageNumber = int.Parse(Console.ReadLine());


            var coursePage =
                courseService.GetCoursesByPage(
                    pageNumber,
                    pageSize
                );


            Console.WriteLine(
                $"\n===== COURSE PAGE {pageNumber} ====="
            );


            foreach (var course in coursePage)
            {
                Console.WriteLine(
                    $"{course.Id} | {course.Name}"
                );
            }

            break;



        // EXIT
        case 0:

            return;



        default:

            Console.WriteLine("Wrong option!");

            break;
    }
}
