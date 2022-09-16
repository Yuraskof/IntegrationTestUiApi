using Aquality.Selenium.Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task4SmartDataDrivenKPC.Constants;

namespace Task4SmartDataDrivenKPC.Utilities
{
    public static class FileReader
    {
        public static Dictionary<string, string> TestData = new Dictionary<string, string>();
        public static Dictionary<string, string> ProductInfo = new Dictionary<string, string>();

        private static Logger Logger => Logger.Instance;

        public static void GetTestData()
        {
            Logger.Info("Got test data");

            if (TestData.Count == 0)
            {
                var filePath = ProjectConstants.PathToProductsInfo;
                var json = File.ReadAllText(filePath);
                var jsonObj = JObject.Parse(json);

                foreach (var element in jsonObj)
                {
                    TestData.Add(element.Key, element.Value.ToString());
                }
            }
        }

        public static void GetProductInfo(string key)
        {
            Logger.Info(string.Format("Got {0} info", key));
            string allUserInfo = TestData[key];
            string[] separatedData = allUserInfo.Split("\t");

            List<string> productInfoFields = new List<string>()
                { "OperatingSystem", "ProductName"};

            ProductInfo.Clear();

            for (int i = 0; i < separatedData.Length; i++)
            {
                ProductInfo.Add(productInfoFields[i], separatedData[i]);
            }
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
            return JsonConvert.DeserializeObject<T>(ReadFile(path));
        }

        private static string ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}