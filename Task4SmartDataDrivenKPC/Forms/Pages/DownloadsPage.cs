using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4SmartDataDrivenKPC.Constants;

namespace Task4SmartDataDrivenKPC.Forms.Pages
{
    public class DownloadsPage : Form
    {
        private IButton NextItemsButton => ElementFactory.GetButton(By.XPath("//div[contains (@class, \"w-carousel__arrow_right\")]//div"), "Show next items button");

        ILink SendToMailLink(string productName) => ElementFactory.GetLink(By.XPath(string.Format("//div[contains (text(), \"{0}\")]//ancestor:: div[@class =\"w-downloadProgramCard__logo\"]//following-sibling:: kl-link//span[contains (text(), \"Send to myself\")]", productName)), "Send to mail link");

        IButton SelectOsButton(string os) => ElementFactory.GetButton(By.XPath(string.Format("//div[@class = \"w-osSelect__list\"]//div[contains (text(), \"{0}\")]", os)), "Select Os button");

        ILabel ProductLabel(string productName) => ElementFactory.GetLabel(By.XPath(string.Format("//div[contains (text(), \"{0}\")]", productName)), "Product label");

        
        public SendEmailForm sendEmailForm = new SendEmailForm();

        public DownloadsPage() : base(By.XPath("//div[@class = \"w-osSelect__list\"]"), "Downloads page")
        {
        }

        public void SelectOs(string osName)
        {
            SelectOsButton(osName).MouseActions.Click();
        }

        public void OpenSendToMailForm(string productName)
        {
            if (FindProduct(productName))
            {
                SendToMailLink(productName).WaitAndClick();
            }
        }

        private bool FindProduct(string productName)
        {
            for (int i = 0; i < ProjectConstants.MaxCarouselSlidesCount; i++)
            {
                if (!AqualityServices.ConditionalWait.WaitFor(() => {
                            return ProductLabel(productName).State.IsDisplayed;
                        },
                        TimeSpan.FromSeconds(ProjectConstants.Timeout), TimeSpan.FromSeconds(ProjectConstants.PollingInterval)))
                {
                    NextItemsButton.ClickAndWait();
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
