using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4SmartDataDrivenKPC.Forms.Pages
{
    public class LoginOrRegistrationPage : Form
    {
        private TimeSpan timeout = TimeSpan.FromSeconds(2);
        private ITextBox UserEmailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@type = \"email\"]"), "User email");

        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@type = \"password\"]"), "Password");

        private IButton LogInSubmitButton => ElementFactory.GetButton(By.XPath("//button[@data-at-selector = \"welcomeSignInBtn\"]"), "Login submit");


        public LoginOrRegistrationPage() : base(By.XPath("//div[contains (@class, \"entry-panel\")]"), "Login or registration page")
        {
        }

        public void SetUserEmail(string userName)
        {
            UserEmailTextBox.State.WaitForEnabled();
            UserEmailTextBox.ClearAndType(userName);
        }

        public void SetPassword(string userPassword) => PasswordTextBox.ClearAndType(userPassword);

        public void ClickSignInButton()
        {
            LogInSubmitButton.State.WaitForEnabled();
            LogInSubmitButton.Click();

            if (UserEmailTextBox.State.WaitForDisplayed(timeout))
            {
                LogInSubmitButton.Click();
            }
        }
    }
}