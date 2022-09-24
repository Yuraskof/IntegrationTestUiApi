using System.Collections.Specialized;
using NUnit.Framework;
using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Forms;
using Task4SmartDataDrivenKPC.Forms.Pages;
using Task4SmartDataDrivenKPC.Models;
using Task4SmartDataDrivenKPC.Utilities;


namespace Task4SmartDataDrivenKPC.Tests
{
    public class Test : BaseTest
    {
        [Test(Description = "TC-0001 Check the letter contain correct link for downloading")]
        [TestCaseSource(nameof(PrepareToTest))]
        public void TC0001_CheckTheLetterContainCorrectLinkForDownloading(ProductModel model)
        {
            CookiesForm cookiesForm = new CookiesForm();
            Assert.IsTrue(cookiesForm.State.WaitForDisplayed(), $"{cookiesForm.Name} should be presented");
            cookiesForm.AcceptCookies();

            LoginOrRegistrationPage loginOrRegistrationPage = new LoginOrRegistrationPage();
            Assert.IsTrue(loginOrRegistrationPage.State.WaitForDisplayed(), $"{loginOrRegistrationPage.Name} should be presented");
            loginOrRegistrationPage.PerformAuthorisation();
            Logger.Info("Step 1 completed.");

            MainNavigationForm mainNavigationForm = new MainNavigationForm();
            Assert.IsTrue(mainNavigationForm.State.WaitForDisplayed(), $"{mainNavigationForm.Name} should be presented");
            mainNavigationForm.GoToDownloadsPage();
            Logger.Info("Step 2 completed.");

            DownloadsPage downloadsPage = new DownloadsPage();
            Assert.IsTrue(downloadsPage.State.WaitForDisplayed(), $"{downloadsPage.Name} should be presented");
            downloadsPage.SelectOs(model.OS);
            downloadsPage.OpenSendToMailForm(model.ProductName);
            Assert.IsTrue(downloadsPage.sendEmailForm.State.WaitForDisplayed(), $"{downloadsPage.sendEmailForm.Name} should be presented");
            downloadsPage.sendEmailForm.SendEmail();
            ConfirmationForm confirmationForm = new ConfirmationForm();
            Assert.IsTrue(confirmationForm.State.WaitForDisplayed(TimeSpan.FromSeconds(ProjectConstants.TimeoutForForm)), $"{confirmationForm.Name} should be presented");
            Assert.IsTrue(MailClient.CheckMessage(model.ProductName), "Message isn't contain download link");
            Logger.Info("Step 3 completed.");
        }

        public static IEnumerable<object[]> PrepareToTest()
        {
            FileReader.ClearLogFile();

            List<ProductModel> modelsList = FileReader.GetModels();

            foreach (var model in modelsList)
            {
                yield return new[] { model };
            }
        }
    }
}