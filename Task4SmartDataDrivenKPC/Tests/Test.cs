using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Models;
using Task4SmartDataDrivenKPC.Steps;
using Task4SmartDataDrivenKPC.Utilities;


namespace Task4SmartDataDrivenKPC.Tests
{
    public class Test : BaseTest
    {
        private readonly CookiesFormSteps cookiesSteps = new CookiesFormSteps();
        private readonly LoginOrRegistrationPageSteps loginOrRegistrationPageSteps = new LoginOrRegistrationPageSteps();
        private readonly MainNavigationFormSteps mainNavigationFormSteps = new MainNavigationFormSteps();
        private readonly DownloadsPageSteps downloadsPageSteps = new DownloadsPageSteps();
        private readonly ConfirmationFormSteps confirmationFormSteps = new ConfirmationFormSteps();

        private readonly TestData testData = FileReader.ReadJsonData<TestData>(ProjectConstants.PathToTestData);
        

        [SetUp]
        public void PrepareForTest()
        {
            GoToPage(testData.Url);
            SetScreenExpansionMaximize();
            cookiesSteps.CookiesFormIsPresent();
            cookiesSteps.AcceptCookies();
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }

        [Test(Description = "TC-0001 Check the letter contain correct link for downloading")]
        [TestCaseSource(nameof(PrepareToTest))]
        public void TC0001_CheckTheLetterContainCorrectLinkForDownloading(ProductModel model)
        {
            loginOrRegistrationPageSteps.LoginOrRegistrationPageIsPresent();
            loginOrRegistrationPageSteps.InputCredentionals();
            loginOrRegistrationPageSteps.ClickLogInButton();
            mainNavigationFormSteps.MainNavigationFormIsPresent();
            mainNavigationFormSteps.GoToDownloadsPage();
            downloadsPageSteps.DownloadsPageIsPresent();
            downloadsPageSteps.SelectOs(model.OperatingSystem);
            downloadsPageSteps.OpenSendToMailForm(model.ProductName);
            downloadsPageSteps.sendEmailSteps.SendEmailFormIsPresent();
            downloadsPageSteps.sendEmailSteps.SendEmailWithDownloadLink();
            confirmationFormSteps.ConfirmationFormFormIsPresent();
            Assert.IsTrue(MailClient.CheckMessage(model.ProductName), "Message isn't contain download link");
        }

        public static IEnumerable<object[]> PrepareToTest()
        {
            FileReader.ClearLogFile();
            FileReader.GetTestData();
            yield return new[] { ProductModel.CreateModel("Product1") };
            yield return new[] { ProductModel.CreateModel("Product2") };
            yield return new[] { ProductModel.CreateModel("Product3") };
            yield return new[] { ProductModel.CreateModel("Product4") };
            yield return new[] { ProductModel.CreateModel("Product5") };
            yield return new[] { ProductModel.CreateModel("Product6") };
            yield return new[] { ProductModel.CreateModel("Product7") };
            yield return new[] { ProductModel.CreateModel("Product8") };
            yield return new[] { ProductModel.CreateModel("Product9") };
            yield return new[] { ProductModel.CreateModel("Product10") };
            yield return new[] { ProductModel.CreateModel("Product11") };
            yield return new[] { ProductModel.CreateModel("Product12") };
            yield return new[] { ProductModel.CreateModel("Product13") };
            yield return new[] { ProductModel.CreateModel("Product14") };
            yield return new[] { ProductModel.CreateModel("Product15") };
            yield return new[] { ProductModel.CreateModel("Product16") };
            yield return new[] { ProductModel.CreateModel("Product17") };
            yield return new[] { ProductModel.CreateModel("Product18") };
            yield return new[] { ProductModel.CreateModel("Product19") };
            yield return new[] { ProductModel.CreateModel("Product20") };
        }
    }
}