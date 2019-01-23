using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson4Time
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */

        [TestMethod]
        [Timeout(2000)]
        public void LaunchingAnActionInTheFuture()
        {
            string received = "";
            TimeSpan delay = TimeSpan.FromSeconds(___);
            Scheduler.Immediate.Schedule(delay, () => received = "Finished");
            Assert.AreEqual("Finished", received);
        }

        [TestMethod]
        [Timeout(2000)]
        public void LaunchingAnEventInTheFuture()
        {
            string received = null;
            var time = TimeSpan.FromSeconds(___);
            var people = new Subject<string>();
            people.Delay(time).Subscribe(x => received = x);
            people.OnNext("Godot");
            ThreadUtils.WaitUntil(() => received != null);
            Assert.AreEqual("Godot", received);
        }

        [TestMethod]
        public void YouCanPlaceATimelimitOnHowLongAnEventShouldTake()
        {
            var received = new List<string>();
            var timeout = TimeSpan.FromSeconds(2);
            var timeoutEvent = Observable.Return("Tepid");
            var temperatures = new Subject<string>();
            temperatures.Timeout(timeout, timeoutEvent).Subscribe(x => received.Add(x));
            temperatures.OnNext("Started");
            Thread.Sleep(___);
            temperatures.OnNext("Boiling");
            ThreadUtils.WaitUntil(() => received != null);
            Assert.AreEqual("Started, Tepid", string.Join(", ", received));
        }

        [TestMethod]
        [Timeout(2000)]
        public void Throttling()
        {
            var received = new List<string>();
            var events = new Subject<string>();
            events.Throttle(TimeSpan.FromMilliseconds(100)).Subscribe(i => received.Add(i));
            events.OnNext("f");
            events.OnNext("fr");
            events.OnNext("fro");
            events.OnNext("from");
            Thread.Sleep(120);
            events.OnNext("s");
            events.OnNext("sc");
            events.OnNext("sco");
            events.OnNext("scot");
            events.OnNext("scott");

            Thread.Sleep(120);

            Assert.AreEqual(____, string.Join(" ", received));
        }

        [TestMethod]
        [Timeout(2000)]
        public void Buffering()
        {
            var received = new List<string>();
            var events = new Subject<char>();
            events.Buffer(TimeSpan.FromMilliseconds(100)).Select(c => new string(c.ToArray())).Subscribe(s => received.Add(s));
            events.OnNext('S');
            events.OnNext('c');
            events.OnNext('o');
            events.OnNext('t');
            events.OnNext('t');
            Thread.Sleep(120);

            events.OnNext('R');
            events.OnNext('e');
            events.OnNext('e');
            events.OnNext('d');
            Thread.Sleep(120);

            Assert.AreEqual(____, string.Join(" ", received));
        }

        [TestMethod]
        [Timeout(2000)]
        public void TimeBetweenCalls()
        {
            var received = new List<string>();
            var events = new Subject<string>();
            events.TimeInterval().Where(t => t.Interval.TotalMilliseconds > 100).Subscribe(s => received.Add(s.Value));
            events.OnNext("too");
            events.OnNext("fast");
            Thread.Sleep(120);
            events.OnNext("slow");
            Thread.Sleep(120);
            events.OnNext("down");

            Assert.AreEqual(____, string.Join(" ", received));
        }

        #region Ignore

        public int ___ = 3;
        public object ____ = "Please Fill in the blank";

        #endregion Ignore
    }
}