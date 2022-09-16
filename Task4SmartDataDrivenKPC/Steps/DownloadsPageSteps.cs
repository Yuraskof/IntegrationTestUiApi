using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Extensions;
using Task4SmartDataDrivenKPC.Forms.Pages;

namespace Task4SmartDataDrivenKPC.Steps
{
    public class DownloadsPageSteps : BaseSteps
    {
        private readonly DownloadsPage downloadsPage;
        public readonly SendEmailSteps sendEmailSteps = new SendEmailSteps();

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
            LogStep(nameof(SelectOs) + $" - [{osName}]");
            downloadsPage.SelectOs(osName);
        }

        public void OpenSendToMailForm(string productName)
        {
            LogStep(nameof(OpenSendToMailForm) + $"Product name: [{productName}]");
            downloadsPage.ClickToSendMailLink(productName);
        }
    }
}
