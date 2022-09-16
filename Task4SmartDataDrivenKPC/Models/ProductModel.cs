using FileReader = Task4SmartDataDrivenKPC.Utilities.FileReader;
using Logger = Aquality.Selenium.Core.Logging.Logger;

namespace Task4SmartDataDrivenKPC.Models
{
    public class ProductModel
    {
        private static Logger Logger => Logger.Instance;

        public string OperatingSystem { get; set; }
        public string ProductName { get; set; }
        
        public static ProductModel CreateModel(string key)
        {
            Logger.Info(string.Format("Model {0} created", key));
            FileReader.GetProductInfo(key);
            ProductModel model = new ProductModel();
            model.SetModelFieldsFromTestData(key);
            return model;
        }

        public void SetModelFieldsFromTestData(string key)
        {
            Logger.Info(string.Format("Set {0} model fields", key));

            OperatingSystem = FileReader.ProductInfo["OperatingSystem"];
            ProductName = FileReader.ProductInfo["ProductName"];
        }
    }
}
