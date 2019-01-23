using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CurrentLesson = Koans.Lessons.Lesson6AdvancedStreams;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson6AdvancedStreamsTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.Merging(), "1 A 2 B 3 C ");
            KoanUtils.Verify<CurrentLesson>(l => l.SplittingUp(), 2);
            KoanUtils.Verify<CurrentLesson>(l => l.MergingEvents(), "I am perfect.");
            KoanUtils.AssertLesson<CurrentLesson>(l => l.NeedToSubscribeImediatelyWhenSplitting(),
                                                  l =>
                                                  StringUtils.call =
                                                  (s, p) =>
                                                  ObservableExtensions.Subscribe((IObservable<double>)s, (Action<double>)p[0]));
            KoanUtils.Verify<CurrentLesson>(l => l.MultipleSubscriptions(), 2.0);
        }
    }
}