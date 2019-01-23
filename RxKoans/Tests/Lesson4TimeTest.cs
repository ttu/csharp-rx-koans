using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentLesson = Koans.Lessons.Lesson4Time;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson4TimeTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.LaunchingAnActionInTheFuture(), 0);
            KoanUtils.Verify<CurrentLesson>(l => l.LaunchingAnEventInTheFuture(), 0);
            KoanUtils.Verify<CurrentLesson>(l => l.YouCanPlaceATimelimitOnHowLongAnEventShouldTake(), 2100);
            KoanUtils.Verify<CurrentLesson>(l => l.Throttling(), "from scott");
            KoanUtils.Verify<CurrentLesson>(l => l.Buffering(), "Scott Reed");
            KoanUtils.Verify<CurrentLesson>(l => l.TimeBetweenCalls(), "slow down");
        }
    }
}