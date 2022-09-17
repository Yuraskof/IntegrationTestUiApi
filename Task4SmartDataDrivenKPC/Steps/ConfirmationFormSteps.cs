using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Extensions;
using Task4SmartDataDrivenKPC.Forms;

namespace Task4SmartDataDrivenKPC.Steps
{
    internal class ConfirmationFormSteps : BaseSteps
    {
        private readonly ConfirmationForm confirmationForm;

        private readonly TimeSpan timeout = TimeSpan.FromSeconds(60);

        public ConfirmationFormSteps()
        {
            confirmationForm = new ConfirmationForm();
        }

        public void ConfirmationFormFormIsPresent()
        {
            LogAssertion();
            confirmationForm.AssertIsPresent(timeout);
        }
    }
}
