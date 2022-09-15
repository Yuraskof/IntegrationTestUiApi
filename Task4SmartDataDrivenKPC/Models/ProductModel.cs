using FileReader = Task4SmartDataDrivenKPC.Utilities.FileReader;
using Logger = Aquality.Selenium.Core.Logging.Logger;

namespace Task4SmartDataDrivenKPC.Models
{
    public class ProductModel
    {
        private static Logger Logger => Logger.Instance;

        public string OperatingSystem { get; set; }
        public string ProductName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ProductModel other = (ProductModel)obj;

            if (OperatingSystem.Equals(other.OperatingSystem) && ProductName.Equals(other.ProductName))
            {
                Logger.Info("User models are equal");
                return true;
            }
            Logger.Error("User models aren't  equal");
            return false;
        }

        public static ProductModel CreateModel(string key)
        {
            FileReader.GetProductInfo(key);
            ProductModel model = new ProductModel();
            model.SetModelFieldsFromTestData();
            return model;
        }

        public void SetModelFieldsFromTestData()
        {
            Logger.Info("Set product model fields");

            OperatingSystem = FileReader.ProductInfo["OperatingSystem"];
            ProductName = FileReader.ProductInfo["ProductName"];
        }

        public void SetUserModelFromTextFields(string info, ProductModel model) 
        {
            //List<string> userInfo = StringUtil.GetSeparateddStrings(info, "\r\n");

            // if link contains "Download", тема содержит "OS" "Name"
            OperatingSystem = model.OperatingSystem; // else null
            ProductName = model.ProductName;
        }
    }
}
