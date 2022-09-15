using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4SmartDataDrivenKPC.Constants;

namespace Task4SmartDataDrivenKPC.Forms.Pages
{
    public class LoginOrRegistrationPage : Form
    {
        private ITextBox UserEmailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@type = \"email\"]"), "User email");

        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@type = \"password\"]"), "Password");

        private IButton LogInSubmitButton => ElementFactory.GetButton(By.XPath("//button[@data-at-selector = \"welcomeSignInBtn\"]"), "Login submit");


        public LoginOrRegistrationPage() : base(By.XPath("//div[contains (@class, \"entry-panel\")]"), "Login or registration page")
        {
        }

        public void SetUserEmail(string userName)
        {
            AqualityServices.ConditionalWait.WaitForTrue(() => {
                    return UserEmailTextBox.State.IsEnabled;
                },
                TimeSpan.FromSeconds(ProjectConstants.Timeout), TimeSpan.FromSeconds(ProjectConstants.PollingInterval),
                "The email field must be enabled");

            UserEmailTextBox.ClearAndType(userName);
        }

        public void SetPassword(string userPassword) => PasswordTextBox.ClearAndType(userPassword);

        public void ClickSignInButton() => LogInSubmitButton.WaitAndClick();
    }
}