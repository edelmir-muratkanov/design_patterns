namespace patterns.AbstractFactory;

public interface IStudentFactory
{
   public IStudent? CreateStudent(string department);
}

public class SuStudentFactory : IStudentFactory
{
   public IStudent? CreateStudent(string department)
   {
      return department switch
      {
         "Math" => new MathSuStudent(),
         "CompSci" => new CompSciSuStudent(),
         _ => null
      };
   }
}

public class KazNuStudentFactory : IStudentFactory
{
   public IStudent? CreateStudent(string department)
   {
      return department switch
      {
         "Math" => new MathKazNuStudent(),
         "CompSci" => new CompSciKazNuStudent(),
         _ => null
      };
   }
}