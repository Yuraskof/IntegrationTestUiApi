using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Forms.Pages;
using Test.Web.Extensions;

namespace Task4SmartDataDrivenKPC.Steps
{
    public class DownloadsPageSteps : BaseSteps
    {
        private readonly DownloadsPage downloadsPage;

        public DownloadsPageSteps()
        {
            downloadsPage = new DownloadsPage();
        }


        public void DownloadsPageIsPresent()
        {
            LogAssertion();
            downloadsPage.AssertIsPresent();
        }

        public void SelectOs(string osName)
        {
            LogStep();
            downloadsPage.SelectOs(osName);
        }

        public void OpenSendToMailForm(string productName)
        {
            LogStep();
            downloadsPage.ClickToSendMailLink(productName);
        }
    }
}
