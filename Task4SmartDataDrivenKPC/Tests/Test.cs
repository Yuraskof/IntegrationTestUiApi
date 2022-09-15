using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Task4SmartDataDrivenKPC.Base;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Models;
using Task4SmartDataDrivenKPC.Steps;
using Task4SmartDataDrivenKPC.Utilities;
using Test.Web.Models;

namespace Task4SmartDataDrivenKPC.Tests
{
    public class Test : BaseTest
    {
        private readonly CookiesFormSteps cookiesSteps = new CookiesFormSteps();
        private readonly LoginOrRegistrationPageSteps loginOrRegistrationPageSteps = new LoginOrRegistrationPageSteps();
        private readonly MainNavigationFormSteps mainNavigationFormSteps = new MainNavigationFormSteps();
        private readonly DownloadsPageSteps downloadsPageSteps = new DownloadsPageSteps();
        

        private readonly TestData testData = FileReader.ReadJsonData<TestData>(ProjectConstants.PathToTestData);


        [SetUp]
        public void Setup()
        {
            
            //MailClient.GetMessages();

            GoToPage(testData.Url);
            SetScreenExpansionMaximize();
            cookiesSteps.CookiesFormIsPresent();
            cookiesSteps.AcceptCookies();
        }

        [TearDown]
        public void AfterEach()
        {
            AqualityServices.Browser.Quit();
        }

        [Test(Description = "TC-0001 Check the letter contain correct link for downloading")]
        [TestCaseSource("PrepareToTest")]
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
        }

        public static IEnumerable<object[]> PrepareToTest()
        {
            FileReader.ClearLogFile();
            FileReader.GetTestData();
            yield return new[] { ProductModel.CreateModel("Product1") };
            yield return new[] { ProductModel.CreateModel("Product2") };
        }
    }
}