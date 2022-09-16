using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Forms.Pages;
using Task4SmartDataDrivenKPC.Models;
using Task4SmartDataDrivenKPC.Utilities;
using Test.Web.Extensions;

namespace Task4SmartDataDrivenKPC.Steps
{
    public class LoginOrRegistrationPageSteps : BaseSteps
    {
        private readonly LoginOrRegistrationPage loginOrRegistrationPage;
        private readonly LoginUser loginUser;

        public LoginOrRegistrationPageSteps()
        {
            loginOrRegistrationPage = new LoginOrRegistrationPage();
            loginUser = FileReader.ReadJsonData<LoginUser>(ProjectConstants.PathToLoginUser);
        }

        public void LoginOrRegistrationPageIsPresent()
        {
            LogAssertion();
            loginOrRegistrationPage.AssertIsPresent();
        }

        public void ClickLogInButton()
        {
            LogStep();
            loginOrRegistrationPage.ClickSignInButton();
        }

        public void SetUserEmail(string userName)
        {
            LogStep(nameof(SetUserEmail) + $"Input user email - [{userName}]");
            loginOrRegistrationPage.SetUserEmail(userName);
        }

        public void SetPassword(string password)
        {
            LogStep(nameof(SetPassword) + $"Input password - [{password}]");
            loginOrRegistrationPage.SetPassword(password);
        }

        public void InputCredentionals()
        {
            SetUserEmail(loginUser.UserEmail);
            SetPassword(loginUser.Password);
        }
    }
}