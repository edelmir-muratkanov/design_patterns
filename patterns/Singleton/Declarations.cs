namespace patterns.week1;

internal interface IDeclaration
{
   void Display(int salary);
}

public class GeneralDeclaration : IDeclaration
{
   private readonly Dictionary<string, float>? _configData = Config.GetInstance().Data;

   public void Display(int salary)
   {
      var o = salary * _configData?.GetValueOrDefault("ОПВ");
      var v = salary * _configData?.GetValueOrDefault("ВОСМС");
      var m = _configData?.GetValueOrDefault("МРП");
      var i = _configData?.GetValueOrDefault("ИПН") * (salary - o - 14 * m - v);
      i = i > 0 ? i : 0;
      var z = salary - o - i - v;
      var co = _configData?.GetValueOrDefault("СО") * (salary - o);
      var ch = _configData?.GetValueOrDefault("СН") * (salary - o - v) - co;
      var os = _configData?.GetValueOrDefault("ОСМС") * salary;

      Console.WriteLine($"ОПВ: {o}");
      Console.WriteLine($"ВОСМС: {v}");
      Console.WriteLine($"ИПН: {i}");
      Console.WriteLine($"СО: {co}");
      Console.WriteLine($"СH: {ch}");
      Console.WriteLine($"ОСМС: {os}");
      Console.WriteLine($"ЗП: {z}");
   }
}

internal class CivDeclaration : IDeclaration
{
   private readonly Dictionary<string, float>? _configData = Config.GetInstance().Data;

   public void Display(int salary)
   {
      if (_configData != null)
      {
         var o = _configData.GetValueOrDefault("ОПВ") * salary;
         var i = _configData.GetValueOrDefault("ИПН") * (salary - o);
         var os = _configData.GetValueOrDefault("ОСМС") * salary;
         var z = salary - o - i - os;

         Console.WriteLine($"ИПН: {i}");
         Console.WriteLine($"ОПВ: {o}");
         Console.WriteLine($"ОСМС: {os}");
         Console.WriteLine($"ЗП: {z}");
      }
   }
}