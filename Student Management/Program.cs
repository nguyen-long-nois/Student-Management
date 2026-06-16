using System;
using System.Data.Common;
using System.Numerics;
using System.Xml.Linq;
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }
    public Student(int id, string name, int age, double grade)
    {
        Id = id;
        Name = name;
        Age = age;
        GPA = grade;
    }
}
class Program
{
    static List<Student> notes = new List<Student>();
    static void Main()
    {
        menu();
    }
    static void addStudent()
    {
        Console.WriteLine("What's the ID?");
        int id = Convert.ToInt32(Console.ReadLine());
        Student target = notes.Find(a => a.Id == id);
        if (target != null)
        {
            Console.WriteLine("ID already exist!");
        }
        else
        {
            Console.WriteLine("What's the name?");
            string studentName = Console.ReadLine();
            Console.WriteLine("How old?");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What's the grade?");
            double grade = Convert.ToDouble(Console.ReadLine());
            notes.Add(new Student(id, studentName, age, grade));
        }
    }
    static void getAllStudent()
    {
        if (notes.Count == 0)
        {
            Console.WriteLine("List is empty!");
        }
        else
        {
            Console.WriteLine($"{"ID",-10}{"Name",-20}{"Age",-8}{"GPA",-8}");
            foreach (Student a in notes)
            {
                Console.WriteLine($"{a.Id,-10}{a.Name,-20}{a.Age,-8}{a.GPA,-8}");
            }
        }
    }
    static void updateStudent(int ID)
    {
        Student target = notes.Find(a => a.Id == ID);
        if (target != null)
        {
            Console.WriteLine("what's the new name?");
            target.Name = Console.ReadLine();
            Console.WriteLine("what's the new age?");
            target.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("what's the new grade?");
            target.GPA = Convert.ToDouble(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Student doesn't exist in the list!");
        }


    }
    static void deleteStudent(int ID)
    {
        Student target = notes.Find(a => a.Id == ID);
        if (target != null)
        {
            notes.Remove(target);
            Console.WriteLine("Delete student successfully!");
        }
        else
        {
            Console.WriteLine("Student doesn't exist in the list!");
        }
    }
    static void menu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to student management app!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Update a student");
            Console.WriteLine("3. Delete a student");
            Console.WriteLine("4. View all students");
            Console.WriteLine("5. Exit");

            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    addStudent();
                    break;
                case 2:
                    Console.WriteLine("Which student do u want to update?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    updateStudent(id);
                    break;
                case 3:
                    Console.WriteLine("Which student do u want to delete?");
                    int deleteID = Convert.ToInt32(Console.ReadLine());
                    deleteStudent(deleteID);
                    break;
                case 4:
                    getAllStudent();
                    break;

                case 5:
                    return;
            }
        }
    }
}



