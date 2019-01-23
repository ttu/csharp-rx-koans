using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson3Linq
    {
        /*
        * How to Run: Press Ctrl+R,T (go ahead, try it now)
        * Step 1: find the 1st method that fails
        * Step 2: Fill in the blank ____ to make it pass
        * Step 3: run it again
        * Note: Do not change anything other than the blank
        */

        [TestMethod]
        public void Linq()
        {
            var numbers = Observable.Range(1, 100);
            var results = from x in numbers
                          where x % ____ == 0
                          select x.ToString();

            var strings = results.ToEnumerable().ToArray();
            Assert.AreEqual("11,22,33,44,55,66,77,88,99", String.Join(",", strings));
        }

        [TestMethod]
        public void LinqOverMouseEvents()
        {
            IObservable<Point> clicks = Koans.Utils.RxKoans.CreateMouseEvents(new Point(100, 50), new Point(75, 75), new Point(40, 80));
            var results = from click in clicks
                          where click.X == click.Y
                          select ___;
            results.Subscribe(HighlightCrossHairs);
        }

        #region Ignore

        public int ____ = 1;
        public object ___ = "Please Fill in the blank";

        public void HighlightCrossHairs(Point p)
        {
            Assert.AreEqual(p.X, p.Y);
        }

        public void HighlightCrossHairs(object o)
        {
            if (o is Point)
            {
                HighlightCrossHairs((Point)o);
            }
            else
            {
                Assert.Fail("I expected a Point but got: " + o.ToString());
            }
        }

        #endregion Ignore
    }
}