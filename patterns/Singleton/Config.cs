using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace patterns.week1;

internal class Config
{
   private const string Filepath = "../../../Data/SingletonData.json";
   private static Config? _instance;

   public Dictionary<string, float> Data;

   private Config()
   {
   }

   private static Dictionary<string, float>? ReadConfigFile()
   {
      return JsonSerializer.Deserialize<Dictionary<string, float>>(File.ReadAllText(Filepath));
   }

   private static Dictionary<string, float> WriteConfigFile()
   {
      var data = GetData();
      var serializeOptions = new JsonSerializerOptions
      {
         WriteIndented = true,
         Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
      };

      File.WriteAllText(
         Filepath,
         JsonSerializer.Serialize(data, serializeOptions),
         Encoding.UTF8
      );
      return data;
   }
   
   private static Dictionary<string, float> GetData()
   {
      var data = new Dictionary<string, float>();
      var options = new List<string> { "ИПН", "ОПВ", "ВОСМС", "ОСМС", "СН", "СО" };
      foreach (var option in options)
      {
         Console.Write($"Введите процент {option}: ");
         var answer = Console.ReadLine()?.Replace("%", "").Trim();
         var val = Convert.ToSingle(answer) / 100;
         data.Add(option, val);
      }

      Console.Write("Введите сумму МРП: ");
      data.Add("МРП", Convert.ToSingle(Console.ReadLine()?.Trim()));
      return data;
   }


   public static Config GetInstance()
   {
      if (_instance == null)
      {
         if (File.Exists(Filepath))
         {
            _instance = new Config
            {
               Data = ReadConfigFile()
            };
         }
         else
         {
            _instance = new Config
            {
               Data = WriteConfigFile()
            };
         }
      }

      return _instance;
   }
}