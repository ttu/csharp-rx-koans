using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CurrentLesson = Koans.Lessons.Lesson2ComposableObservations;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson2ComposibleTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.ComposableAddition(), 1000);
            KoanUtils.Verify<CurrentLesson>(l => l.ComposableBeforeAndAfter(), "123456");
            KoanUtils.Verify<CurrentLesson>(l => l.WeWroteThis(), 4);
            KoanUtils.AssertLesson<CurrentLesson>(l => l.ConvertingEvents(),
                                                  l => StringUtils.call = (s, p) => ((String)s).ToLower());
            KoanUtils.Verify<CurrentLesson>(l => l.CreatingAMoreRelevantEventStream(), 50);
            KoanUtils.AssertLesson((Action<CurrentLesson>)(l => l.CheckingEverything()), l1 => l1.____ = true);
            KoanUtils.Verify<CurrentLesson>(l => l.CompositionMeansTheSumIsGreaterThanTheParts(), 8);
        }
    }
}