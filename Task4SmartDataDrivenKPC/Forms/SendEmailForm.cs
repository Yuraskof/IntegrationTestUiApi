using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4SmartDataDrivenKPC.Constants;

namespace Task4SmartDataDrivenKPC.Forms
{
    public class SendEmailForm : Form
    {
        private IButton SendEmailButton => ElementFactory.GetButton(By.XPath("//button[@data-at-selector= \"installerSendSelfBtn\"] "), "Send email button");

        public SendEmailForm() : base(By.XPath("//div[@class = \"u-modalContainer__content\"]"), "Send email form")
        {
        }

        public void SendEmail()
        {
            SendEmailButton.State.WaitForEnabled(TimeSpan.FromSeconds(ProjectConstants.TimeoutForForm));
            SendEmailButton.Click();
        }
    }
}
