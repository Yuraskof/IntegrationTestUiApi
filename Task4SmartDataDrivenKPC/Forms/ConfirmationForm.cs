using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4SmartDataDrivenKPC.Forms
{
    public class ConfirmationForm : Form
    {
        public ConfirmationForm() : base(By.XPath("//h2[@data-at-selector=\"successfullySentLabel\"]"), "Mail sent confirmation form")
        {
        }
    }
}
