using System;

class Program
{
    static void Main()
    {
        StudentManagement sm = new StudentManagement();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== Student Management System =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Search Student by ID");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            
            int choice;
            bool valid = int.TryParse(Console.ReadLine(), out choice);

            if (!valid)
            {
                Console.WriteLine("Please enter a valid number!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Marks: ");
                    int marks = Convert.ToInt32(Console.ReadLine());

                    Student s = new Student { Id = id, Name = name, Age = age, Marks = marks };
                    sm.AddStudent(s);
                    Console.WriteLine("Student added successfully!");
                    break;

                case 2:
                    sm.ViewStudents();
                    break;

                case 3:
                    Console.Write("Enter ID to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    sm.UpdateStudent(updateId);
                    break;

                case 4:
                    Console.Write("Enter ID to delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    sm.DeleteStudent(deleteId);
                    break;

                case 5:
                    Console.Write("Enter ID to search: ");
                    int searchId = Convert.ToInt32(Console.ReadLine());
                    sm.SearchStudent(searchId);
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
