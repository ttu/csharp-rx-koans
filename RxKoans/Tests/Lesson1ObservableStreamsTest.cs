using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reactive.Subjects;
using CurrentLesson = Koans.Lessons.Lesson1ObservableStreams;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson1ObservableStreamsTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.SimpleSubscription(), 42);
            KoanUtils.Verify<CurrentLesson>(l => l.WhatGoesInComesOut(), 101);
            KoanUtils.Verify<CurrentLesson>(l => l.ThisIsTheSameAsAnEventStream(), 37);
            KoanUtils.AssertLesson<CurrentLesson>(l => l.HowEventStreamsRelateToObservables(),
                                                  l =>
                                                  StringUtils.call =
                                                  (s, p) => { ((Subject<int>)s).OnNext(((int)p[0])); return 0; });
            KoanUtils.Verify<CurrentLesson>(l => l.EventStreamsHaveMultipleEvents(), 17);
            KoanUtils.Verify<CurrentLesson>(l => l.SimpleReturn(), "Foo");
            KoanUtils.Verify<CurrentLesson>(l => l.TheLastEvent(), "Bar");
            KoanUtils.Verify<CurrentLesson>(l => l.EveryThingCounts(), 7);
            KoanUtils.Verify<CurrentLesson>(l => l.ThisIsStillAnEventStream(), 15);
            KoanUtils.Verify<CurrentLesson>(l => l.AllEventsWillBeRecieved(), "Working 98765");
            KoanUtils.Verify<CurrentLesson>(l => l.DoingInTheMiddle(), "Party");
            KoanUtils.AssertLesson<CurrentLesson>(l => l.NothingListensUntilYouSubscribe(),
                                                  l =>
                                                  StringUtils.call =
                                                  (s, p) => ObservableExtensions.Subscribe((IObservable<int>)s));
            KoanUtils.Verify<CurrentLesson>(l => l.EventsBeforeYouSubscribedDoNotCount(), 7);
            KoanUtils.Verify<CurrentLesson>(l => l.EventsAfterYouUnsubscribDoNotCount(), 3);
            KoanUtils.Verify<CurrentLesson>(l => l.EventsWhileSubscribing(), "you look pretty");
            KoanUtils.AssertLesson<CurrentLesson>(l => l.UnsubscribeAtAnyTime(),
                                                  l =>
                                                  StringUtils.call =
                                                  (s, p) =>
                                                      {
                                                          ((IDisposable)s).Dispose();
                                                          return 1;
                                                      });
            KoanUtils.Verify<CurrentLesson>(l => l.TakeUntilFull(), 5);
        }
    }
}