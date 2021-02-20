using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Range = Koans.Utils.Range;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson2ComposableObservations
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */

        [TestMethod]
        public void ComposableAddition()
        {
            int received = 0;
            var numbers = new[] { 10, 100, ___ };
            numbers.ToObservable().Sum().Subscribe(x => received = x);
            Assert.AreEqual(1110, received);
        }

        [TestMethod]
        public void ComposableBeforeAndAfter()
        {
            var names = Range.Create(1, 6);
            string a = "";
            string b = "";

            names.ToObservable().Do(n => a += n).Where(n => n.IsEven()).Do(n => b += n).Subscribe();
            Assert.AreEqual(____, a);
            Assert.AreEqual("246", b);
        }

        [TestMethod]
        public void WeWroteThis()
        {
            var received = new List<String>();
            var names = new[] { "Bart", "Marge", "Wes", "Linus", "Erik" };
            names.ToObservable().Where(n => n.Length <= ___).Subscribe(x => received.Add(x));
            Assert.AreEqual("[Bart, Wes, Erik]", received.AsString());
        }

        [TestMethod]
        public void ConvertingEvents()
        {
            string received = "";
            var names = new[] { "wE", "hOpE", "yOU", "aRe", "eNJoyIng", "tHiS" };
            names.ToObservable().Select(x => x.___()).Subscribe(x => received += x + " ");
            Assert.AreEqual("we hope you are enjoying this ", received);
        }

        [TestMethod]
        public void CreatingAMoreRelevantEventStream()
        {
            string received = "";
            var mouseXMovements = new[] { 100, 200, 150 };
            IObservable<int> relativemouse = mouseXMovements.ToObservable().Select((int x) => x - ___);
            relativemouse.Subscribe(x => received += x + ", ");
            Assert.AreEqual("50, 150, 100, ", received);
        }

        [TestMethod]
        public void CheckingEverything()
        {
            bool? received = null;
            var names = new[] { 2, 4, 6, 8 };
            names.ToObservable().All(x => x.IsEven()).Subscribe(x => received = x);
            Assert.AreEqual(____, received);
        }

        [TestMethod]
        public void CompositionMeansTheSumIsGreaterThanTheParts()
        {
            var numbers = Observable.Range(1, 10);
            numbers.Where(x => x > ___).Sum().Subscribe(x => Assert.AreEqual(19, x));
        }

        #region Ignore

        public int ___ = 100;
        public object ____ = "Please Fill in the blank";

        #endregion Ignore
    }
}