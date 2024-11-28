using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Öğretim Görevlisi oluşturma
            Instructor instructor1 = new Instructor("Dr. Mehmet Çelik", 101);
            Instructor instructor2 = new Instructor("Prof. Zeynep Yıldız", 102);
            Instructor instructor3 = new Instructor("Doç. Ahmet Karaca", 103);

            // Ders oluşturma
            Course course1 = new Course("Algoritmalar", 4, instructor1);
            Course course2 = new Course("Veri Yapıları", 3, instructor2);
            Course course3 = new Course("Yapay Zeka", 4, instructor3);
            Course course4 = new Course("Makine Öğrenimi", 4, instructor1);
            Course course5 = new Course("Veritabanı Yönetimi", 3, instructor2);

            // Derslerin öğretim görevlilerine atanması
            instructor1.Courses.Add(course1);
            instructor1.Courses.Add(course4);
            instructor2.Courses.Add(course2);
            instructor2.Courses.Add(course5);
            instructor3.Courses.Add(course3);

            // Öğrenci oluşturma
            List<Student> students = new List<Student>
            {
                new Student("Elif Demir", 201),
                new Student("Can Yılmaz", 202),
                new Student("Fatma Ak", 203)
            };

            List<Instructor> instructors = new List<Instructor> { instructor1, instructor2, instructor3 };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Öğrenci ve Ders Yönetim Sistemi ===");
                Console.WriteLine("1. Öğretim Görevlisi Seç");
                Console.WriteLine("2. Ders Listesi ve Öğrenci Kayıt");
                Console.WriteLine("3. Kayıtlı Öğrencileri Listele");
                Console.WriteLine("4. Öğrenci Kaydı Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Öğretim Görevlisi Seçin:");
                    for (int i = 0; i < instructors.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {instructors[i].Name}");
                    }
                    int instructorChoice = GetValidInput(instructors.Count) - 1;
                    Instructor selectedInstructor = instructors[instructorChoice];

                    Console.Clear();
                    Console.WriteLine($"\n{selectedInstructor.Name}'in Verdiği Dersler:");
                    for (int i = 0; i < selectedInstructor.Courses.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {selectedInstructor.Courses[i].Name} (Kredi: {selectedInstructor.Courses[i].Credit})");
                    }

                    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Bir ders seçmek için önce öğretim görevlisini seçin:");
                    for (int i = 0; i < instructors.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {instructors[i].Name}");
                    }
                    int instructorChoice = GetValidInput(instructors.Count) - 1;
                    Instructor selectedInstructor = instructors[instructorChoice];

                    Console.Clear();
                    Console.WriteLine($"{selectedInstructor.Name}'in Verdiği Dersler:");
                    for (int i = 0; i < selectedInstructor.Courses.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {selectedInstructor.Courses[i].Name} (Kredi: {selectedInstructor.Courses[i].Credit})");
                    }
                    int courseChoice = GetValidInput(selectedInstructor.Courses.Count) - 1;
                    Course selectedCourse = selectedInstructor.Courses[courseChoice];

                    Console.WriteLine("\nKayıt edilecek öğrenciyi seçin:");
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {students[i].Name}");
                    }
                    int studentChoice = GetValidInput(students.Count) - 1;
                    Student selectedStudent = students[studentChoice];
                    selectedCourse.RegisterStudent(selectedStudent);

                    Console.WriteLine($"\n{selectedStudent.Name}, {selectedCourse.Name} dersine başarıyla kayıt oldu.");
                    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Kayıtlı Öğrenciler:");
                    foreach (var instructor in instructors)
                    {
                        foreach (var course in instructor.Courses)
                        {
                            Console.WriteLine($"\nDers: {course.Name} (Öğretim Görevlisi: {instructor.Name})");
                            course.ShowCourseInfo();
                        }
                    }
                    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Bir ders seçmek için önce öğretim görevlisini seçin:");
                    for (int i = 0; i < instructors.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {instructors[i].Name}");
                    }
                    int instructorChoice = GetValidInput(instructors.Count) - 1;
                    Instructor selectedInstructor = instructors[instructorChoice];

                    Console.Clear();
                    Console.WriteLine($"{selectedInstructor.Name}'in Verdiği Dersler:");
                    for (int i = 0; i < selectedInstructor.Courses.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {selectedInstructor.Courses[i].Name} (Kredi: {selectedInstructor.Courses[i].Credit})");
                    }
                    int courseChoice = GetValidInput(selectedInstructor.Courses.Count) - 1;
                    Course selectedCourse = selectedInstructor.Courses[courseChoice];

                    Console.WriteLine("\nSilinecek öğrenciyi seçin:");
                    for (int i = 0; i < selectedCourse.RegisteredStudents.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {selectedCourse.RegisteredStudents[i].Name}");
                    }
                    int studentChoice = GetValidInput(selectedCourse.RegisteredStudents.Count) - 1;
                    Student selectedStudent = selectedCourse.RegisteredStudents[studentChoice];
                    selectedCourse.RemoveStudent(selectedStudent);

                    Console.WriteLine($"\n{selectedStudent.Name}, {selectedCourse.Name} dersinden başarıyla silindi.");
                    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim! Devam etmek için bir tuşa basın...");
                    Console.ReadKey();
                }
            }
        }

        // Geçerli bir kullanıcı girişi al
        private static int GetValidInput(int maxOption)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > maxOption)
            {
                Console.WriteLine($"Lütfen 1 ile {maxOption} arasında geçerli bir sayı girin:");
            }
            return input;
        }
    }

    // Öğretim Görevlisi ve Öğrenci arasında ortak olan özellikleri ve metotları tanımlar
    public interface IPerson
    {
        void ShowInfo(); // Bilgi gösterme işlemi
    }

    public abstract class Person : IPerson
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Person(string name, int id)
        {
            Name = name;
            ID = id;
        }

        public abstract void ShowInfo();
    }

    public class Student : Person
    {
        public Student(string name, int id) : base(name, id) { }

        public override void ShowInfo()
        {
            Console.WriteLine($"Öğrenci Adı: {Name}, ID: {ID}");
        }
    }

    public class Instructor : Person
    {
        public List<Course> Courses { get; set; }

        public Instructor(string name, int id) : base(name, id)
        {
            Courses = new List<Course>();
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Öğretim Görevlisi Adı: {Name}, ID: {ID}");
        }
    }

    public class Course
    {
        public string Name { get; set; }
        public int Credit { get; set; }
        public Instructor Instructor { get; set; }
        public List<Student> RegisteredStudents { get; set; }

        public Course(string name, int credit, Instructor instructor)
        {
            Name = name;
            Credit = credit;
            Instructor = instructor;
            RegisteredStudents = new List<Student>();
        }

        public void ShowCourseInfo()
        {
            Console.WriteLine($"Ders Adı: {Name}, Kredi: {Credit}");
            Console.WriteLine("Kayıtlı Öğrenciler:");
            foreach (var student in RegisteredStudents)
            {
                Console.WriteLine($" - {student.Name}");
            }
        }

        public void RegisterStudent(Student student)
        {
            RegisteredStudents.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            RegisteredStudents.Remove(student);
        }
    }
}
