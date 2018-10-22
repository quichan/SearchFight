namespace appSearchFight.Common
{
    using Newtonsoft.Json.Linq;
    using System.IO;
    public class Configuration
    {
        public static string GetConfiguration(string key)
        {     
            var filePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "appsettings.json";
            var jsonText = File.ReadAllText(filePath);


            dynamic config = JObject.Parse(jsonText);
            var configValueString = config["Configuration"][key];

            return configValueString;
        }
    }
}
