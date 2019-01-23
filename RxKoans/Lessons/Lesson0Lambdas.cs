using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koans.Lessons
{
    [TestClass]
    public class Lesson0Lambdas
    {
        /*
		 * How to Run: Press Ctrl+R,T (go ahead, try it now)
		 * Step 1: find the 1st method that fails
		 * Step 2: Fill in the blank ____ to make it pass
		 * Step 3: run it again
		 * Note: Do not change anything other than the blank
		 */

        [TestMethod]
        public void GettingStarted1ReadingTheErrorMessage()
        {
            Assert.AreEqual(___, ReadTheErrorMessageToFigureOutWhatThisReturns());
        }

        [TestMethod]
        public void LambdasAreBlocksOfCode()
        {
            Run(() => Assert.AreEqual(true, ___));
        }

        [TestMethod]
        public void LambdasAreActions()
        {
            Action lambda = () => Assert.AreEqual(true, ___);
            lambda();
        }

        [TestMethod]
        public void LambdasAreNotRunAtDeclaration()
        {
            int i = 1;
            var dictionary = new Dictionary<char, object>();
            dictionary['a'] = i++;
            dictionary['b'] = (Action)(() => i++);
            dictionary['c'] = i++;
            Assert.AreEqual(1, dictionary['a']);
            Assert.AreEqual(_______, dictionary['c']);
        }

        //Q: Why didn't the i++ get run for dictionary entry b ?
        //A:
        [TestMethod]
        public void ButLambdasMightNotBeCalled()
        {
            RunIfNeeded(shouldActionBeRun: ____, action: () => Assert.Fail("Don't Run This"));
        }

        [TestMethod]
        public void LambdasCanUseLocalVariables()
        {
            var lambdaStatus = ___;
            Run(() => Assert.AreEqual("Awesome!", lambdaStatus));
        }

        [TestMethod]
        public void LambdasAreTinyMethods()
        {
            RunWithValue(___, (s) => Assert.AreEqual("Passed In", s));
        }

        [TestMethod]
        public void LambdasCanReturnAValue()
        {
            var message = HiFive(() => { return ___; });
            Assert.AreEqual("Hey Bart, Give me 5", message);
        }

        [TestMethod]
        public void LambdasAutomaticallyReturnSingleStatements()
        {
            var message = HiFive(() => ___);
            Assert.AreEqual("Hey Llewellyn, Give me 5", message);
        }

        [TestMethod]
        public void LambdasCanUseParametersInReturn()
        {
            var message = Run(___, (p) => p + 1);
            Assert.AreEqual(6, message);
        }

        [TestMethod]
        public void LambdasThatReturnAreCalledFunctions()
        {
            Func<int, int> lambda = (a) => a * a;
            Assert.AreEqual(___, lambda(5));
        }

        [TestMethod]
        public void LambdasCanBeVeryTerse()
        {
            int count = Run("12345678", s => s.Length);
            Assert.AreEqual(___, count);
        }

        [TestMethod]
        public void LambdasCanBeVeryVerbose()
        {
            var count = Run("a1a2a3a4", _____, (string given, char remove) =>
                                                   {
                                                       var text = new StringBuilder();
                                                       foreach (var c in given)
                                                       {
                                                           if (c != remove)
                                                           {
                                                               text.Append(c);
                                                           }
                                                       }
                                                       return text.ToString();
                                                   });
            Assert.AreEqual("1234", count);
        }

        [TestMethod]
        public void MethodDuplication1Of2()
        {
            StartSong();
            Sing("We gave the cat to a little kid");

            Sing("But the cat came back");
            Sing("The very next day");
            Sing("Oh the " + ___ + " came back");
            Sing("We thought he was a goner");
            Sing("But the cat came back, he just wouldn't go away");

            Sing("We sent the cat out on a boat");

            Sing("But the cat came back");
            Sing("The very next day");
            Sing("Oh the " + ___ + " came back");
            Sing("We thought he was a goner");
            Sing("But the cat came back, he just wouldn't go away");
            AssertCatSong();
        }

        [TestMethod]
        public void MethodDuplication2Of2()
        {
            StartSong();

            Sing("We gave the cat to a little kid");
            SingVerse();
            Sing("We sent the cat out on a " + ___);
            SingVerse();

            AssertCatSong();
        }

        //Q: How did we remove all the duplication from method 1 of 2?
        //A:
        private void SingVerse()
        {
            Sing("But the cat came back");
            Sing("The very next day");
            Sing("Oh the cat came back");
            Sing("We thought he was a goner");
            Sing("But the cat came back, he just wouldn't go away");
        }

        [TestMethod]
        public void ParameterDuplication1Of2()
        {
            StartSong();
            Sing("100 bottles of beer on the wall");
            Sing("100 bottles of " + ___);
            Sing("Take one down, pass it around");
            Sing("100 bottles of beer on the wall");

            Sing("99 bottles of beer on the wall");
            Sing("99 bottles of " + ___);
            Sing("Take one down, pass it around");
            Sing("99 bottles of beer on the wall");
            AssertBeerSong();
        }

        [TestMethod]
        public void ParameterDuplication2Of2()
        {
            StartSong();
            SingVerse(100);
            SingVerse(___);

            AssertBeerSong();
        }

        //Q: Since the duplication was not exact, how did we remove all the duplication from method 1 of 2?
        //A:
        private void SingVerse(Object num)
        {
            Sing(num + " bottles of beer on the wall");
            Sing(num + " bottles of beer");
            Sing("Take one down, pass it around");
            Sing(num + " bottles of beer on the wall");
        }

        [TestMethod]
        public void LambdaDuplication1Of2()
        {
            StartSong();
            var number = 2;
            Sing(number + "! ");
            number = number + 2;
            Sing(number + "! ");
            number = number + 2;
            Sing(number + "! ");
            number = number + 2;
            Sing(___ + "! ");
            Sing("Who do we appreciate?");

            number = 17;
            Sing(number + "! ");
            number = GetNextPrime(number);
            Sing(number + "! ");
            number = GetNextPrime(number);
            Sing(number + "! ");
            number = GetNextPrime(number);
            Sing(number + "! ");
            Sing("These are the primes, that we find fine!");

            AssertNumberSong();
        }

        [TestMethod]
        public void LambdaDuplication2Of2()
        {
            StartSong();
            SingVerse(2, (int n) => n + _______, "Who do we appreciate?");
            SingVerse(17, (int n) => GetNextPrime(n), "These are the primes, that we find fine!");
            AssertNumberSong();
        }

        //Q: Since the duplication was not exact, and it wasn't just a value, how did we remove all the duplication from method 1 of 2?
        //A:
        //Lambdas allow you to create API from what used to be written as patterns.
        //Reactive framework is using Lambdas to create an API for the best practices of Asychronous programming patterns.
        private void SingVerse(int number, Func<int, int> func, string endWith)
        {
            Sing(number + "! ");
            number = func(number);
            Sing(number + "! ");
            number = func(number);
            Sing(number + "! ");
            number = func(number);
            Sing(number + "! ");
            Sing(endWith);
        }

        #region RunMethods

        private void AssertNumberSong()
        {
            var song = "2! 4! 6! 8! Who do we appreciate?17! 19! 23! 29! These are the primes, that we find fine!";
            Assert.AreEqual(song, singing.ToString());
        }

        private int GetNextPrime(int number)
        {
            switch (number)
            {
                case 13:
                    return 17;

                case 17:
                    return 19;

                case 19:
                    return 23;

                case 23:
                    return 29;
            }
            return 0;
        }

        private void AssertBeerSong()
        {
            var song =
                "100 bottles of beer on the wall100 bottles of beerTake one down, pass it around100 bottles of beer on the wall99 bottles of beer on the wall99 bottles of beerTake one down, pass it around99 bottles of beer on the wall";
            Assert.AreEqual(song, singing.ToString());
        }

        private void AssertCatSong()
        {
            var catSong =
                "We gave the cat to a little kidBut the cat came backThe very next dayOh the cat came backWe thought he was a gonerBut the cat came back, he just wouldn't go awayWe sent the cat out on a boatBut the cat came backThe very next dayOh the cat came backWe thought he was a gonerBut the cat came back, he just wouldn't go away";
            Assert.AreEqual(catSong, singing.ToString());
        }

        private void StartSong()
        {
            singing = new StringBuilder();
        }

        private void Sing(string p)
        {
            singing.Append(p);
        }

        private dynamic Run(dynamic parameter, Func<dynamic, dynamic> func)
        {
            return func(parameter);
        }

        private Out1 Run<In1, In2, Out1>(In1 p1, In2 p2, Func<In1, In2, Out1> func)
        {
            return func(p1, p2);
        }

        private string HiFive(Func<object> func)
        {
            return "Hey " + func() + ", Give me 5";
        }

        private void RunWithValue(object p, Action<object> action)
        {
            action(p);
        }

        public static void Run(Action action)
        {
            action();
        }

        public static void RunIfNeeded(bool shouldActionBeRun, Action action)
        {
            if (shouldActionBeRun)
            {
                action();
            }
        }

        #endregion RunMethods

        #region Ignore

        public object ___ = "Please Fill in the blank";
        public bool ____ = true;
        public char _____ = '_';
        private StringBuilder singing;
        public int _______ = 0;

        private object ReadTheErrorMessageToFigureOutWhatThisReturns()
        {
            return "Harry Potter";
        }

        #endregion Ignore
    }
}