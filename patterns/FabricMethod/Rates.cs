namespace patterns.FabricMethod;

public interface IRate
{
   double Calculate(double index);
}

public class PenthouseRate : IRate
{
   public double Calculate(double index)
   {
      // 1 кВТ/ч = 189тг
      return Math.Round(index * 189, 2);
   }
}

public class HouseRate : IRate
{
   public double Calculate(double index)
   {
      // 1 кВТ/ч = 150тг
      return Math.Round(index * 150, 2);
   }
}

public class FlatRate : IRate
{
   public double Calculate(double index)
   {
      // 1 кВТ/ч = 101.6тг
      return Math.Round(index * 101.6, 2);
   }
}
