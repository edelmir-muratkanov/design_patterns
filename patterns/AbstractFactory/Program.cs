namespace patterns.AbstractFactory;

public class App
{
   private readonly IStudentFactory? _factory;

   public App(IStudentFactory? factory)
   {
      _factory = factory;
   }

   public List<IStudent?> CreateStudents()
   {
      var students = new List<IStudent?>();
      var departments = new List<string>{"CompSci", "Math"};
      var random = new Random();
      for (var i = 0; i < 10; i++)
      {
         students.Add(_factory?.CreateStudent(departments[random.Next(departments.Count)]));
      }

      return students;
   }
}


public static class Program
{
   private static IStudentFactory? Factory { get; set; }

   public static void Client()
   {
      Console.WriteLine("Choose university (KazNU, SU) :");
      Factory = Console.ReadLine()?.ToLower() switch
      {
         "kaznu" => new KazNuStudentFactory(),
         "su" => new SuStudentFactory(),
         _ => null
      };
      
      foreach (var student in new App(Factory).CreateStudents())
      {
         student?.SayHello();
      }
   }
}