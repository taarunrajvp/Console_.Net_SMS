using System;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public string GetGrade()
    {
        if (Marks >= 90) return "A+";

        else if (Marks >= 80) return "A";
        
        else if (Marks >= 70) return "B";
        
        else if (Marks >= 60) return "C";
        
        else return "F";
    }

    public override string ToString()
    {
        return $"{Id},{Name},{Age},{Marks}";
    }

    // Parse student from string line (for file storage)
    public static Student FromString(string line)
    {
        string[] parts = line.Split(',');
        return new Student
        {
            Id = int.Parse(parts[0]),
            Name = parts[1],
            Age = int.Parse(parts[2]),
            Marks = int.Parse(parts[3])
        };
    }
}
