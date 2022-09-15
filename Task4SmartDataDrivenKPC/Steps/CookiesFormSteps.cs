using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Forms;
using Test.Web.Extensions;


namespace Task4SmartDataDrivenKPC.Steps
{
    public class CookiesFormSteps : BaseSteps
    {
        private readonly CookiesForm cookiesForm;

        public CookiesFormSteps()
        {
            cookiesForm = new CookiesForm();
        }

        public void CookiesFormIsPresent()
        {
            LogAssertion();
            cookiesForm.AssertIsPresent();
        }

        public void AcceptCookies()
        {
            LogStep();
            cookiesForm.AcceptCookies();
        }
    }
}