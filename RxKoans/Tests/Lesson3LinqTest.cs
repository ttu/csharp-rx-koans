using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using CurrentLesson = Koans.Lessons.Lesson3Linq;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson3LinqTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.Linq(), 11);
            KoanUtils.Verify<CurrentLesson>(l => l.LinqOverMouseEvents(), new Point(75, 75));
        }
    }
}