using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4SmartDataDrivenKPC.Forms
{
    internal class SendEmailForm : Form
    {
        private readonly TimeSpan timeout = TimeSpan.FromSeconds(60);
        private IButton SendEmailButton => ElementFactory.GetButton(By.XPath("//button[@data-at-selector= \"installerSendSelfBtn\"] "), "Send email button");

        public SendEmailForm() : base(By.XPath("//div[@class = \"u-modalContainer__content\"]"), "Send email form")
        {
        }

        public void SendEmail()
        {
            SendEmailButton.State.WaitForEnabled(timeout);
            SendEmailButton.Click();
        }
    }
}
