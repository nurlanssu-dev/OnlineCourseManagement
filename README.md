# Online Course Management System

## Description

Online Course Management System is a C# Console Application developed using Entity Framework Core and SQL Server.

The purpose of this project is to manage students, courses and enrollment operations. The system allows adding students, creating courses, registering students to courses and managing related data through Entity Framework Core.

## Technologies

- C#
- .NET Console Application
- Entity Framework Core
- SQL Server
- LINQ
- EF Core Migration

## Database

Database name:

OnlineCourseDb

Database connection is configured through AppDbContext.

The project contains the following tables:

- Students
- Courses
- Enrollments


## Entity Relationship

The relationship between entities:

Student 1 ---- * Enrollment * ---- 1 Course


A student can be registered in multiple courses.

A course can contain multiple students.

Enrollment entity is used to manage the relationship between Student and Course.


## Models

### Student

Properties:

- Id
- FullName
- Email
- Age
- CreatedAt

Navigation Property:

- Enrollments


### Course

Properties:

- Id
- Name
- Description
- Price
- Duration
- CreatedAt

Navigation Property:

- Enrollments


### Enrollment

Properties:

- Id
- StudentId
- CourseId
- EnrollmentDate

Navigation Properties:

- Student
- Course


## Implemented Features

### Student Management

Completed operations:

- Add Student
- Get All Students
- Get Student By Id
- Search Student
- Update Student
- Delete Student


Validation:

- FullName cannot be empty
- Email cannot be empty
- Age must be greater than 0


### Course Management

Completed operations:

- Add Course
- Get All Courses
- Get Course By Id
- Search Course
- Filter Courses By Price
- Update Course
- Delete Course
- Course Pagination


Validation:

- Course name cannot be empty
- Price cannot be negative
- Duration must be greater than 0


### Enrollment Management

Completed operations:

- Enroll Student to Course
- Prevent Duplicate Enrollment
- Get All Enrollments
- Get Student Courses
- Get Course Students
- Remove Enrollment


Additional reports:

- Course Student Count
- Student Course Count
- Most Popular Course
- Most Active Student


## Entity Framework Core Features Used

The project uses:

- DbContext
- DbSet
- Add()
- Find()
- FirstOrDefault()
- ToList()
- Where()
- Include()
- ThenInclude()
- Any()
- Count()
- OrderBy()
- Skip()
- Take()
- Remove()
- SaveChanges()


## Pagination

Course pagination is implemented using Skip() and Take().

Pagination formula:

```csharp
.Skip((pageNumber - 1) * pageSize)
.Take(pageSize)
```

Example:

Page Size: 3

Page Number: 2

Result:

4 | Spring Boot  
5 | Docker  
6 | Microservices  


## Migration

Entity Framework Core Migration is used for database creation.

Migration:

```
Add-Migration InitialCreate
```

Database update:

```
Update-Database
```


## Project Structure

```
OnlineCourseManagement

├── Data
│   └── AppDbContext.cs
│
├── Models
│   ├── Student.cs
│   ├── Course.cs
│   └── Enrollment.cs
│
├── Services
│   ├── StudentService.cs
│   ├── CourseService.cs
│   └── EnrollmentService.cs
│
├── Migrations
│
└── Program.cs
```


## How To Run

1. Clone repository

```
git clone repository-url
```

2. Open the project.

3. Configure SQL Server connection in AppDbContext.

4. Run migration:

```
Update-Database
```

5. Start application:

```
dotnet run
```


## Current Status

Completed:

✅ Database Setup  
✅ Entity Models  
✅ Entity Relationships  
✅ EF Core Migration  
✅ Student CRUD  
✅ Course CRUD  
✅ Enrollment Operations  
✅ Reports  
✅ Course Pagination  


## Author

Online Course Management System
