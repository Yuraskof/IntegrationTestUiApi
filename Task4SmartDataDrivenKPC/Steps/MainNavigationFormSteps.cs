using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Forms;
using Test.Web.Extensions;

namespace Task4SmartDataDrivenKPC.Steps
{
    public class MainNavigationFormSteps : BaseSteps
    {
        private readonly MainNavigationForm mainNavigationForm;

        public MainNavigationFormSteps()
        {
            mainNavigationForm = new MainNavigationForm();
        }

        public void MainNavigationFormIsPresent()
        {
            LogAssertion();
            mainNavigationForm.AssertIsPresent();
        }

        public void GoToDownloadsPage()
        {
            LogStep();
            mainNavigationForm.GoToDownloadsPage();
        }
    }
}
