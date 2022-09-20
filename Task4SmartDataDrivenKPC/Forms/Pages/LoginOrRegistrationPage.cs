using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Models;
using Task4SmartDataDrivenKPC.Utilities;

namespace Task4SmartDataDrivenKPC.Forms.Pages
{
    public class LoginOrRegistrationPage : Form
    {
       
        private ITextBox UserEmailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@type = \"email\"]"), "User email");

        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@type = \"password\"]"), "Password");

        private IButton LogInSubmitButton => ElementFactory.GetButton(By.XPath("//button[@data-at-selector = \"welcomeSignInBtn\"]"), "Login submit");

        private readonly LoginUser loginUser;

        public LoginOrRegistrationPage() : base(By.XPath("//div[contains (@class, \"entry-panel\")]"), "Login or registration page")
        {
            loginUser = FileReader.ReadJsonData<LoginUser>(ProjectConstants.PathToLoginUser);
        }

        private void SetUserEmail(string userName)
        {
            UserEmailTextBox.State.WaitForEnabled();
            UserEmailTextBox.ClearAndType(userName);
        }

        private void SetPassword(string userPassword) => PasswordTextBox.ClearAndType(userPassword);

        private void ClickSignInButton()
        {
            LogInSubmitButton.State.WaitForEnabled();
            LogInSubmitButton.Click();

            if (UserEmailTextBox.State.WaitForDisplayed(TimeSpan.FromSeconds(ProjectConstants.TimeoutForElements)))
            {
                LogInSubmitButton.Click();
            }
        }

        public void PerformAuthorisation()
        {
            SetUserEmail(loginUser.UserEmail);
            SetPassword(loginUser.Password);
            ClickSignInButton();
        }
    }
}