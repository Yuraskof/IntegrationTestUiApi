using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using Humanizer;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Models;
using Task4SmartDataDrivenKPC.Utilities;

namespace Task4SmartDataDrivenKPC.Base
{
    public abstract class BaseTest
    {
        protected string ScenarioName
            => TestContext.CurrentContext.Test.Properties.Get("Description")?.ToString()
            ?? TestContext.CurrentContext.Test.Name.Replace("_", string.Empty).Humanize();

        internal static Logger Logger => AqualityServices.Get<Logger>();
        private TestContext.ResultAdapter Result => TestContext.CurrentContext.Result;

        private readonly TestData testData = FileReader.ReadJsonData<TestData>(ProjectConstants.PathToTestData);

        [SetUp]
        public void Setup()
        {
            Logger.Info($"Start scenario [{ScenarioName}]");
            AqualityServices.Browser.GoTo(testData.Url);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            AqualityServices.Browser.Quit();
            LogScenarioResult();
        }

        private void LogScenarioResult()
        {
            Logger.Info($"Scenario [{ScenarioName}] result is {Result.Outcome.Status}!");
            if (Result.Outcome.Status != TestStatus.Passed)
            {
                Logger.Error(Result.Message);
            }
            Logger.Info(new string('=', 100));
        }
    }
}