using patterns.week1;

namespace patterns.Singleton;

public class Main
{
   public static void Client()
   {
      var config = Config.GetInstance();
      Console.Write("Введите сумму оклада: ");
      var salary = Convert.ToInt32(Console.ReadLine()?.Trim());

      Console.Write("Выберите форму договора [Общая(1), ГПХ(2)] : ");
      switch (Console.ReadLine()?.Trim())
      {
         case "1" or "Общая":
            new GeneralDeclaration().Display(salary);
            break;
         case "2" or "ГПХ":
            new CivDeclaration().Display(salary);
            break;
         default:
            Console.WriteLine("Нет такого договора");
            break;
      }
   }
}