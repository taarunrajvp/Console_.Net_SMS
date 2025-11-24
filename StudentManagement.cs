using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class StudentManagement
{
    private List<Student> students = new List<Student>();
    private string dataFile = "students.txt"; // File to save data

    public StudentManagement()
    {
        LoadFromFile();
    }

    public void AddStudent(Student s)
    {
        students.Add(s);
        SaveToFile();
    }

    public void UpdateStudent(int id)
    {
        Student s = students.FirstOrDefault(st => st.Id == id);
        if (s != null)
        {
            Console.Write("Enter new name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter new age: ");
            s.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new marks: ");
            s.Marks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Student updated successfully!");
            SaveToFile();
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }

    public void DeleteStudent(int id)
    {
        Student s = students.FirstOrDefault(st => st.Id == id);
        if (s != null)
        {
            students.Remove(s);
            Console.WriteLine("Student deleted successfully!");
            SaveToFile();
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        Console.WriteLine("\nID\tName\tAge\tMarks\tGrade");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Age}\t{student.Marks}\t{student.GetGrade()}");
        }
    }

    public void SearchStudent(int id)
    {
        Student s = students.FirstOrDefault(st => st.Id == id);
        if (s != null)
        {
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}, Marks: {s.Marks}, Grade: {s.GetGrade()}");
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }

    private void SaveToFile()
    {
        List<string> lines = students.Select(s => s.ToString()).ToList();
        File.WriteAllLines(dataFile, lines);
    }

    private void LoadFromFile()
    {
        if (File.Exists(dataFile))
        {
            string[] lines = File.ReadAllLines(dataFile);
            students = lines.Select(l => Student.FromString(l)).ToList();
        }
    }
}
