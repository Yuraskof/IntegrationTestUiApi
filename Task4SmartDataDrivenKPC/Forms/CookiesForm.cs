using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4SmartDataDrivenKPC.Forms
{
    public class CookiesForm : Form
    {
        private IButton AcceptCookiesButton => FormElement.FindChildElement<IButton>(By.XPath("//button[@id = \"CybotCookiebotDialogBodyLevelButtonAccept\"]"), "Accept cookies");
       
        public CookiesForm() : base(By.XPath("//div[@id = \"CybotCookiebotDialog\"]"), "Cookies")
        {
        }

        public void AcceptCookies() => AcceptCookiesButton.MouseActions.Click();
    }
}