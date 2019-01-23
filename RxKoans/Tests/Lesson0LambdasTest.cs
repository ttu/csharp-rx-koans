using Koans.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrentLesson = Koans.Lessons.Lesson0Lambdas;

namespace Koans.Tests
{
    [TestClass]
    public class Lesson0LambdasTest
    {
        [TestMethod]
        public void TestAllQuestions()
        {
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasAreBlocksOfCode(), true);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasAreActions(), true);
            KoanUtils.Verify<CurrentLesson>(l => l.GettingStarted1ReadingTheErrorMessage(), "Harry Potter");
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasAreNotRunAtDeclaration(), 2);
            KoanUtils.Verify<CurrentLesson>(l => l.ButLambdasMightNotBeCalled(), false);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasCanUseLocalVariables(), "Awesome!");
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasAreTinyMethods(), "Passed In");
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasCanReturnAValue(), "Bart");
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasThatReturnAreCalledFunctions(), 25);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasAutomaticallyReturnSingleStatements(), "Llewellyn");
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasCanUseParametersInReturn(), 5);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasCanBeVeryTerse(), 8);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdasCanBeVeryVerbose(), 'a');
            KoanUtils.Verify<CurrentLesson>(l => l.MethodDuplication1Of2(), "cat");
            KoanUtils.Verify<CurrentLesson>(l => l.MethodDuplication2Of2(), "boat");
            KoanUtils.Verify<CurrentLesson>(l => l.ParameterDuplication1Of2(), "beer");
            KoanUtils.Verify<CurrentLesson>(l => l.ParameterDuplication2Of2(), 99);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdaDuplication1Of2(), 8);
            KoanUtils.Verify<CurrentLesson>(l => l.LambdaDuplication2Of2(), 2);
        }
    }
}