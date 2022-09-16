using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Extensions;
using Task4SmartDataDrivenKPC.Forms;

namespace Task4SmartDataDrivenKPC.Steps
{
    public class SendEmailSteps : BaseSteps
    {
        private readonly SendEmailForm sendEmailForm;

        public SendEmailSteps()
        {
            sendEmailForm = new SendEmailForm();
        }

        public void SendEmailFormIsPresent()
        {
            LogAssertion();
            sendEmailForm.AssertIsPresent();
        }

        public void SendEmailWithDownloadLink()
        {
            LogStep();
            sendEmailForm.SendEmail();
        }
    }
}
