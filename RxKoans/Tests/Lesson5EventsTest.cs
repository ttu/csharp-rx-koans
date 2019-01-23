using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentLesson = Koans.Lessons.Lesson5Events;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson5EventsTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.TheMainEvent(), "BAR");
        }
    }
}