
using UniversityStudentsMenager.DAL.Entities;
using UniversityStudentsMenager.DAL.Repositories;

namespace UniversityStudentsManager
{

    internal class StudentAplicationHandlers
    {
        public static void PauseConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static Student? UserInputStudent()
        {
            try
            {
                Console.WriteLine("Enter first name: ");
                string? first_name = Console.ReadLine();

                Console.WriteLine("Enter last name: ");
                string? last_name = Console.ReadLine();

                Console.WriteLine("Enter email: ");
                string? email = Console.ReadLine();

                Console.WriteLine("Enter date of birth: ");
                string? date_of_birth = Console.ReadLine();

                if (date_of_birth is null || first_name is null || last_name is null || email is null)
                    return null;

                DateTime dob = DateTime.Parse(date_of_birth);

                return new Student { FirstName = first_name, LastName = last_name, Email = email, DateOfBirth = dob };
            }
            catch
            {
                return null;
            }
        }

        public static void AddNewStudent(StudentRepository repository)
        {
            Console.Clear();
            Student? student = UserInputStudent();
            if (student is null)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            repository.Add(student);
            Console.WriteLine("Student added");
            PauseConsole();
        }

        public static void ShowAllStudents(StudentRepository repository)
        {
            Console.Clear();
            IEnumerable<Student> students = repository.GetAll();
            foreach (var student in students)
            { 
                Console.WriteLine($"{student.Id} | {student.FirstName}, {student.LastName}");
            }
            PauseConsole();
        }

        public static void ModifyStudent(StudentRepository repository)
        {
            try { 
                Console.Clear();
                Console.WriteLine("Enter student id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Student? student = repository.GetById(id);
                if (student is null)
                {
                    Console.WriteLine("Student not found");
                    PauseConsole();
                    return;
                }
                Console.WriteLine("Enter new first name or leave it blank to not change: ");
                string? first_name = Console.ReadLine();
                if (first_name is not null && first_name != String.Empty)
                    student.FirstName = first_name;

                Console.WriteLine("Enter new last name or leave it blank to not change: ");
                string? last_name = Console.ReadLine();
                if (last_name is not null && last_name != String.Empty)
                    student.LastName = last_name;

                Console.WriteLine("Enter new email or leave it blank to not change: ");
                string? email = Console.ReadLine();
                if (email is not null && email != String.Empty)
                    student.Email = email;

                Console.WriteLine("Enter new date of birth or leave it blank to not change: ");
                string? date_of_birth = Console.ReadLine();
                if (date_of_birth is not null && date_of_birth != String.Empty)
                    student.DateOfBirth = DateTime.Parse(date_of_birth);

                repository.Update(student);
                Console.WriteLine("Student modified");
                PauseConsole();
            }
            catch
            {
                Console.WriteLine("Invalid input");
                PauseConsole();
            }
        }

        public static void DeleteStudent(StudentRepository repository)
        {
            Console.Clear();
            Console.WriteLine("Enter student id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Student? student = repository.GetById(id);
            if (student is null)
            {
                Console.WriteLine("Student not found");
                PauseConsole();
                return;
            }

            Console.WriteLine($"Are you sure you want to delete this student? [{student.FirstName}, {student.LastName}] (yes/no)");
            string? rep = Console.ReadLine();

            if (rep is null || (rep.ToLower() != "yes" && rep.ToLower() != "no"))
            {
                Console.WriteLine("Student not deleted");
                PauseConsole();
                return;
            }

            repository.Delete(student);
            Console.WriteLine("Student deleted");
            PauseConsole();
        }

        public static void ShowInfo(StudentRepository repository)
        {
            Console.Clear();
            Console.WriteLine("Enter student id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Student? student = repository.GetById(id);
            if (student is null)
            {
                Console.WriteLine("Student not found");
                PauseConsole();
                return;
            }
            Console.Clear();
            Console.WriteLine($"Id: {student.Id}");
            Console.WriteLine($"First name: {student.FirstName}");
            Console.WriteLine($"Last name: {student.LastName}");
            Console.WriteLine($"Email: {student.Email}");
            Console.WriteLine($"Date of birth: {student.DateOfBirth.ToString("d")}\n");
            PauseConsole();
        }
    }
}
