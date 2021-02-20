using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using Range = Koans.Utils.Range;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson1ObservableStreams
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */

        [TestMethod]
        public void SimpleSubscription()
        {
            Observable.Return(42).Subscribe(x => Assert.AreEqual(___, x));
        }

        [TestMethod]
        public void WhatGoesInComesOut()
        {
            Observable.Return(___).Subscribe(x => Assert.AreEqual(101, x));
        }

        //Q: Which interface Rx apply? (hint: what does "Return()" return)
        //A:
        [TestMethod]
        public void ThisIsTheSameAsAnEventStream()
        {
            var events = new Subject<int>();
            events.Subscribe(x => Assert.AreEqual(___, x));
            events.OnNext(37);
        }

        //Q: What is the relationship between "ThisIsTheSameAsAnEventStream()" and "SimpleSubscription()"?
        //A:
        [TestMethod]
        public void HowEventStreamsRelateToObservables()
        {
            int observableResult = 1;
            Observable.Return(73).Subscribe(i => observableResult = i);
            int eventStreamResult = 1;
            var events = new Subject<int>();
            events.Subscribe(i => eventStreamResult = i);
            events.___(73);
            Assert.AreEqual(observableResult, eventStreamResult);
        }

        //Q: What does Observable.Return() map to for a Subject?
        //A:

        [TestMethod]
        public void EventStreamsHaveMultipleEvents()
        {
            int eventStreamResult = 0;
            var events = new Subject<int>();
            events.Subscribe(i => eventStreamResult += i);
            events.OnNext(10);
            events.OnNext(7);
            Assert.AreEqual(____, eventStreamResult);
        }

        //Q: What does Observable.Return() map to for a Subject?
        //A:

        [TestMethod]
        public void SimpleReturn()
        {
            var received = "";
            Observable.Return("Foo").Subscribe((string s) => received = s);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void TheLastEvent()
        {
            var received = "";
            var names = new[] { "Foo", "Bar" };
            names.ToObservable().Subscribe((s) => received = s);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void EveryThingCounts()
        {
            var received = 0;
            var numbers = new[] { 3, 4 };
            numbers.ToObservable().Subscribe((int x) => received += x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void ThisIsStillAnEventStream()
        {
            var received = 0;
            var numbers = new Subject<int>();
            numbers.Subscribe((int x) => received += x);
            numbers.OnNext(10);
            numbers.OnNext(5);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void AllEventsWillBeRecieved()
        {
            var received = "Working ";
            var numbers = Range.Create(9, 5);
            numbers.ToObservable().Subscribe((int x) => received += x);
            Assert.AreEqual(___, received);
        }

        [TestMethod]
        public void DoingInTheMiddle()
        {
            var status = new List<String>();
            var daysTillTest = Range.Create(4, 1).ToObservable();
            daysTillTest.Do(d => status.Add(d + "=" + (d == 1 ? "Study Like Mad" : ___))).Subscribe();
            Assert.AreEqual("[4=Party, 3=Party, 2=Party, 1=Study Like Mad]", status.AsString());
        }

        [TestMethod]
        public void NothingListensUntilYouSubscribe()
        {
            var sum = 0;
            var numbers = Range.Create(1, 10).ToObservable();
            var observable = numbers.Do(n => sum += n);
            Assert.AreEqual(0, sum);
            observable.___();
            Assert.AreEqual(1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10, sum);
        }

        [TestMethod]
        public void EventsBeforeYouSubscribedDoNotCount()
        {
            var sum = 0;
            var numbers = new Subject<int>();
            var observable = numbers.Do(n => sum += n);
            numbers.OnNext(1);
            numbers.OnNext(2);
            observable.Subscribe();
            numbers.OnNext(3);
            numbers.OnNext(4);
            Assert.AreEqual(___, sum);
        }

        [TestMethod]
        public void EventsAfterYouUnsubscribDoNotCount()
        {
            var sum = 0;
            var numbers = new Subject<int>();
            var observable = numbers.Do(n => sum += n);
            var subscription = observable.Subscribe();
            numbers.OnNext(1);
            numbers.OnNext(2);
            subscription.Dispose();
            numbers.OnNext(3);
            numbers.OnNext(4);
            Assert.AreEqual(___, sum);
        }

        [TestMethod]
        public void EventsWhileSubscribing()
        {
            var recieved = new List<string>();
            var words = new Subject<string>();
            var observable = words.Do(recieved.Add);
            words.OnNext("Peter");
            words.OnNext("said");
            var subscription = observable.Subscribe();
            words.OnNext("you");
            words.OnNext("look");
            words.OnNext("pretty");
            subscription.Dispose();
            words.OnNext("ugly");
            Assert.AreEqual(___, String.Join(" ", recieved));
        }

        [TestMethod]
        public void UnsubscribeAtAnyTime()
        {
            var received = "";
            var numbers = Range.Create(1, 9);
            IDisposable un = null;

            un = numbers
                    .ToObservable(NewThreadScheduler.Default)
                    .Subscribe((int x) =>
                    {
                        received += x;
                        if (x == 5)
                        {
                            un.___();
                        }
                    });

            Thread.Sleep(100);
            Assert.AreEqual("12345", received);
        }

        [TestMethod]
        public void TakeUntilFull()
        {
            var received = "";
            var subject = new Subject<int>();
            subject.TakeUntil(subject.Where(x => x > ____)).Subscribe(x => received += x);
            subject.OnNext(Range.Create(1, 9).ToArray());
            Assert.AreEqual("12345", received);
        }

        #region Ignore

        public object ___ = "Please Fill in the blank";
        public int ____ = 100;

        #endregion Ignore
    }
}