namespace patterns.AbstractFactory;

public interface IStudent
{
   public void SayHello();
}


public class CompSciSuStudent : IStudent
{
   public void SayHello()
   {
      Console.WriteLine("Студент SU по специальности ComputerScience");
   }
}

public class MathSuStudent : IStudent
{
   public void SayHello()
   {
      Console.WriteLine("Студент SU по специальности Math");
   }
}

public class CompSciKazNuStudent : IStudent
{
   public void SayHello()
   {
      Console.WriteLine("Студент KazNU по специальности ComputerScience");
   }
}

public class MathKazNuStudent : IStudent
{
   public void SayHello()
   {
      Console.WriteLine("Студент KazNU по специальности Math");
   }
}