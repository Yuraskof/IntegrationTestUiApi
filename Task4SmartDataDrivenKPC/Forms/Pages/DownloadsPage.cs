using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4SmartDataDrivenKPC.Forms.Pages
{
    public class DownloadsPage : Form
    {
        private ILink SendToMailLink => ElementFactory.GetLink(By.XPath("//div[contains (text(), \" Security Cloud \")]//following:: span[contains (text(), \" Send to myself \")][1]"), "Send to mail link");

        private IButton NextItemsButton => ElementFactory.GetButton(By.XPath("//div[contains (@class, \"w-carousel__arrow_right\")]//div"), "Show next items button");

        ////div[contains (text(), " Security Cloud ")]//ancestors::   span[contains (text(), " Send to myself ")]

        private static string selectOsButton;
        private static string sendToMailLink;
        private static string productLabel;

        public DownloadsPage() : base(By.XPath("//div[@class = \"w-osSelect__list\"]"), "Downloads page")
        {
        }

        public void SelectOs(string uniqueText)
        {
            IButton osButton = CreateSelectOsButton(selectOsButton, uniqueText);
            osButton.MouseActions.Click();
        }

        private IButton CreateSelectOsButton(string locator, string uniqueText)
        {
            locator = string.Format("//div[@class = \"w-osSelect__list\"]//div[contains (text(), \"{0}\")]", uniqueText);
            By selectOsButtonLocator = By.XPath(locator);
            IButton element = ElementFactory.GetButton(selectOsButtonLocator, "Select Os button");
            return element;
        }

        public void ClickToSendMailLink(string uniqueText)
        {
            if (FindProduct(uniqueText))
            {
                ILink sendMail = CreateSendToMailLink(sendToMailLink, uniqueText);
                sendMail.MouseActions.Click();
            }
        }

        private ILink CreateSendToMailLink(string locator, string uniqueText)
        {
            locator = string.Format("//div[contains (text(), \"{0}\")]//following:: span[contains (text(), \" Send to myself \")][1]", uniqueText);
            By sendToMailLinkLocator = By.XPath(locator);
            ILink element = ElementFactory.GetLink(sendToMailLinkLocator, "Send to mail link");
            return element;
        }

        private ILabel CreateProductLabel(string locator, string uniqueText)
        {
            locator = string.Format("//div[contains (text(), \"{0}\")]", uniqueText);
            By productLabelLocator = By.XPath(locator);
            ILabel element = ElementFactory.GetLabel(productLabelLocator, "Product label");
            return element; 
        }

        private bool FindProduct(string uniqueText)
        {
            ILabel product = CreateProductLabel(productLabel, uniqueText);

            for (int i = 0; i < 5; i++)
            {
                if (!product.State.IsDisplayed)
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
