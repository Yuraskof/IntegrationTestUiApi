using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Models;

namespace Task4SmartDataDrivenKPC.Utilities
{
    public static class FileReader
    {
        private static Logger Logger => AqualityServices.Get<Logger>();
        
        public static List<ProductModel> GetModels()
        {
            var json = File.ReadAllText(ProjectConstants.PathToProductsInfo);
            var jsonObj = JObject.Parse(json);
            var products = jsonObj["Products"].ToString();

            var modelsList = JsonConvert.DeserializeObject<List<ProductModel>>(products);

            return modelsList;
        }

        public static void ClearLogFile()
        {
            FileInfo file = new FileInfo(ProjectConstants.PathToLogFile);

            if (file.Exists)
            {
                file.Delete();
                Logger.Info("Log file deleted");
            }
        }

        public static T ReadJsonData<T>(string path)
        {
            Logger.Info(string.Format("Path {0} deserialized", path));
            return JsonConvert.DeserializeObject<T>(ReadFile(path));
        }

        private static string ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Logger.Info(string.Format("File {0} read", path));
                return sr.ReadToEnd();
            }
        }
    }
}