using System;
namespace DecoratorPattern
{
    /// <summary>
    /// Student Component
    /// </summary>
    public abstract class Student
    {
        public abstract string DisplayStudentInformation();
    }

    /// <summary>
    /// concrete component for student
    /// </summary>
    public class StudentConcrete : Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }

        public override string DisplayStudentInformation()
        {
            string whois = ((Gender == "Male") ? "He" : "She");
            return Name + ". " + whois + " is " + Age + " years old. " + "Grade is " + Grade + ".";
        }
    }

    /// <summary>
    /// base student decorator for all dynamic functionalities
    /// </summary>
    public class StudentDecorator: Student
    {
        Student baseStudent = null;
        protected StudentDecorator(Student s)
        {
            baseStudent = s;
        }
        public override string DisplayStudentInformation()
        {
            string baseStudentInformation = baseStudent.DisplayStudentInformation();
            return baseStudentInformation;
        }
    }

    /// <summary>
    /// science student concrete decorator for dynamic functionality
    /// </summary>
    public class ScienceStudentDecorator : StudentDecorator
    {
        public string Labs { get; set; }
        public ScienceStudentDecorator(Student baseStudent) : base(baseStudent) { }

        public override string DisplayStudentInformation()
        {
            var result = base.DisplayStudentInformation();
            result = result + " Labs are " + Labs + ".";
            return result;
        }
    }

    /// <summary>
    /// sports student concrete decorator for dynamic functionality
    /// </summary>
    public class SportsStudentDecorator : StudentDecorator
    {
        public string Games { get; set; }
        public SportsStudentDecorator(Student baseStudent) : base(baseStudent) { }

        public override string DisplayStudentInformation()
        {
            var result = base.DisplayStudentInformation();
            result = result + " Games are " + Games + ".";
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //normal student
            StudentConcrete stdKumar = new StudentConcrete { Name = "Kumar", Age = 10, Gender = "Male", Grade = "B" };
            var stdKumarInformation = stdKumar.DisplayStudentInformation();
            Console.WriteLine("---------------------Normal Student--------------------");
            Console.WriteLine(stdKumarInformation);

            //science student
            StudentConcrete stdKavitha = new StudentConcrete { Name = "Kavitha", Age = 10, Gender = "FeMale", Grade = "A" };
            ScienceStudentDecorator stdScienceKavitha = new ScienceStudentDecorator(stdKavitha) { Labs = "Computer Science, Biology" };
            var stdScienceKavithaInformation = stdScienceKavitha.DisplayStudentInformation();
            Console.WriteLine("\n---------------------Science Student--------------------");
            Console.WriteLine(stdScienceKavithaInformation);

            //games student
            StudentConcrete stdArun = new StudentConcrete { Name = "Arun", Age = 10, Gender = "Male", Grade = "C" };
            SportsStudentDecorator stdSportArun = new SportsStudentDecorator(stdArun) { Games = "Cricket, Football" };
            var stdSportsArunInformation = stdSportArun.DisplayStudentInformation();
            Console.WriteLine("\n---------------------Sport Student--------------------");
            Console.WriteLine(stdSportsArunInformation);

            //science & sports student
            StudentConcrete stdMani = new StudentConcrete { Name = "Mani", Age = 10, Gender = "Male", Grade = "A" };
            ScienceStudentDecorator stdScienceMani = new ScienceStudentDecorator(stdMani) { Labs = "Computer Science, Biology" };
            SportsStudentDecorator stdSportScienceMani = new SportsStudentDecorator(stdScienceMani) { Games = "Cricket, Football" };
            var stdSportScienceManiInformation = stdSportScienceMani.DisplayStudentInformation();
            Console.WriteLine("\n---------------------Science & Sport Student--------------------");
            Console.WriteLine(stdSportScienceManiInformation);

            Console.Write("\nPress any key to exist...");
            Console.ReadKey();
        }
    }
}
