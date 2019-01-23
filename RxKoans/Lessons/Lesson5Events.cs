using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reactive.Linq;
using System.Text;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson5Events
    {
        public event EventHandler<TextChangedEventArgs> TextChanged;

        [TestMethod]
        public void TheMainEvent()
        {
            var received = new StringBuilder();
            var textChanges = Observable.FromEventPattern<TextChangedEventArgs>(this, "TextChanged");
            using (textChanges.Subscribe(e => received.Append(e.EventArgs.value)))
            {
                TextChanged(null, new TextChangedEventArgs { value = "B" });
                TextChanged(null, new TextChangedEventArgs { value = "A" });
                TextChanged(null, new TextChangedEventArgs { value = "R" });
            }
            TextChanged(null, new TextChangedEventArgs { value = "T" });
            Assert.AreEqual(___, received.ToString());
        }

        #region Ignore

        public const int ____ = 1000;
        public object ___ = "Please Fill in the blank";

        public Lesson5Events()
        {
            TextChanged += (o, e) => { };
        }

        #endregion Ignore
    }

    public class TextChangedEventArgs : EventArgs
    {
        public string value;
    }
}