namespace patterns.FabricMethod;

public class Main
{
   public static void Client()
   {
      var places = new Dictionary<string, double>
      {
         {"flat", 21.13 },
         {"house", 21.13 },
         {"penthouse", 21.13 }
      };

      var factory = new LivingPlace();

      foreach (var (place, receipt) in places)
         Console.WriteLine($"{place}: {factory.GetReceipt(place, receipt)} тг");
   }
}
