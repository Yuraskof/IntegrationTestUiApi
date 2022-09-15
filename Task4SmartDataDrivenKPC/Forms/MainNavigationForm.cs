using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4SmartDataDrivenKPC.Forms
{
    public class MainNavigationForm : Form
    {
        private IButton DownloadsPageButton => FormElement.FindChildElement<IButton>(By.XPath("//span[contains (text(), \" Downloads \")]"), "Downloads button");

        public MainNavigationForm() : base(By.XPath("//nav[@class = \"main-nav\"]"), "Main navigation form")
        {
        }

        public void GoToDownloadsPage() => DownloadsPageButton.MouseActions.Click();
    }
}