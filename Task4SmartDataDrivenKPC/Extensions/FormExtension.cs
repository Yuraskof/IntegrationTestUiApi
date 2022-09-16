using Aquality.Selenium.Forms;
using NUnit.Framework;

namespace Task4SmartDataDrivenKPC.Extensions
{
    public static class FormExtensions
    {
        public static void AssertIsPresent(this Form form)
        {
            Assert.IsTrue(form.State.WaitForDisplayed(), $"{form.Name} should be presented");
        }
    }
}
