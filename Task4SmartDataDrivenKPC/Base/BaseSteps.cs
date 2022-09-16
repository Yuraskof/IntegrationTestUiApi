using System.Runtime.CompilerServices;
using Humanizer;
using Logger = Aquality.Selenium.Core.Logging.Logger;

namespace Task4SmartDataDrivenKPC.Base
{
    public abstract class BaseSteps
    {
        private static Logger Logger => Logger.Instance;

        protected void LogStep([CallerMemberName] string stepIno = "")
        {
            LogStep(stepIno, stepType: "Action");
        }

        protected void LogAssertion([CallerMemberName] string stepInfo = "")
        {
            LogStep(stepInfo, stepType: "Assertion");
        }

        private void LogStep(string stepInfo, string stepType)
        {
            var shift = new string('#', 10);
            Logger.Info($"{shift} {stepType} {shift} {Environment.NewLine}{GetType().Name}: {stepInfo.Humanize()}");
        }
    }
}