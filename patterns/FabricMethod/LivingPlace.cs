namespace patterns.FabricMethod;

public class LivingPlace
{
   private IRate? CreateRate(string type)
   {
      switch (type)
      {
         case "flat":
            return new FlatRate();
         case "house":
            return new HouseRate();
         case "penthouse":
            return new PenthouseRate();
         default:
            return null;
      }
   }

   public double GetReceipt(string type, double index)
   {
      var rate = CreateRate(type);
      if (rate != null)
      {
         return rate.Calculate(index);
      }

      return 0;
   }
}
