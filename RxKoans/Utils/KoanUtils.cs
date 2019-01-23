using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Koans.Utils
{
    public static class KoanUtils
    {
        public static void Verify<T>(Action<T> test, object answer) where T : new()
        {
            KoanUtils.AssertLesson<T>(test, l => l.FillAll(answer));
        }

        public static void AssertTypeOf<T>(Action<T> test, Type expected) where T : new()
        {
            var lesson = new T();
            var s = "Didn't Fail";
            try
            {
                test(lesson);
            }
            catch (Exception e)
            {
                s = e.Message;
            }
            var expectedMessage =
                String.Format(
                    "Assert.IsInstanceOfType failed.  Expected type:<System.String>. Actual type:<{0}>.",
                    expected);
            Assert.AreEqual(s, expectedMessage);
        }

        public static void AssertLesson<T>(Action<T> test, Action<T> answer) where T : new()
        {
            AssertLesson(test, answer, testFailure: true);
        }

        public static void AssertLesson<T>(Action<T> test, Action<T> answer, bool testFailure) where T : new()
        {
            var l = new T();
            if (testFailure)
            {
                VerifyFailure(test, l);
            }
            answer(l);
            test(l);
            StringUtils.Reset();
        }

        private static void VerifyFailure<T>(Action<T> test, T l)
        {
            var failed = false;
            try
            {
                test(l);
            }
            catch (Exception)
            {
                failed = true;
            }
            Assert.IsTrue(failed, "The Lesson is already passing [Need to add a blank]");
        }

        public static void FillAll(this object lesson, object answer)
        {
            var fields = lesson.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetField);
            foreach (var f in fields)
            {
                if (f.FieldType.IsAssignableFrom(answer.GetType()))
                {
                    f.SetValue(lesson, answer);
                }
            }
        }
    }
}