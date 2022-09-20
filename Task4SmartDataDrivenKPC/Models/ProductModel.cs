using Aquality.Selenium.Browsers;
using FileReader = Task4SmartDataDrivenKPC.Utilities.FileReader;
using Logger = Aquality.Selenium.Core.Logging.Logger;
namespace Task4SmartDataDrivenKPC.Models
{
    public class ProductModel
    {
        internal static Logger Logger => AqualityServices.Get<Logger>();

        public string OS { get; set; }
        public string ProductName { get; set; }
    }
}
