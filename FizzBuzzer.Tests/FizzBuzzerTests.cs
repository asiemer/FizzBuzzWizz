using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FizzBuzzer.Tests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        [Test]
        public void SimpleFizzBuzzer_WhenRanWithAppropriateData_ShouldReturnExpectedResults()
        {
            var result = new FizzBuzzerImpl().Start(1, 15, 3, 5);
            Assert.IsTrue(result.Count() == 16); //should be 16 items
            Assert.IsTrue(result.Count(x=> x == "Fizz") == 5); //should have 5 instances of Fizz
            Assert.IsTrue(result.Count(x => x == "Buzz") == 3); //should have 3 instances of Buzz
        }

        [Test]
        public void FizzBuzzer_WhenRanWithAppropriateData_ShouldReturnExpectedResults()
        {
            var result = new FizzBuzzerImpl().Start(1, 120, new Dictionary<int, string>()
            {
                {3, "Fizz"},
                {5, "Buzz"},
                {8, "Wizz"}
            });

            //should return number of items equal to count of items from X to Y
            Assert.IsTrue(result.Count() == 120);

            //should contain X number of 3
            var fizzCnt = result.Count(x => x.Trim() == "Fizz");
            Assert.IsTrue(fizzCnt == 28);

            //should contain X number of 5
            var buzzCnt = result.Count(x => x.Trim() == "Buzz");
            Assert.IsTrue(buzzCnt == 14);

            //should contain X number of 8
            var wizzCnt = result.Count(x => x.Trim() == "Wizz");
            Assert.IsTrue(wizzCnt == 8);

            //should contain X number of 3 and 5
            var fizzBuzzCnt = result.Count(x => x.Trim() == "Fizz Buzz");
            Assert.IsTrue(fizzBuzzCnt == 7);

            //should contain X number of 5 and 8
            var buzzWizzCnt = result.Count(x => x.Trim() == "Buzz Wizz");
            Assert.IsTrue(buzzWizzCnt == 2);

            //should contain X number of 3 and 8
            var fizzWizzCnt = result.Count(x => x.Trim() == "Fizz Wizz");
            Assert.IsTrue(fizzWizzCnt == 4);

            //should contain X number of 3 and 5 and 8
            var fizzBuzzWizzCnt = result.Count(x => x.Trim() == "Fizz Buzz Wizz");
            Assert.IsTrue(fizzBuzzWizzCnt == 1);
        }

        [Test]
        public void FizzBuzzer_WhenRanWithInvalidLowerBounds_ShouldThrowException()
        {
            //should account for lower's low
            try
            {
                new FizzBuzzerImpl().Start(-201, 15, 3, 5);
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual(ae.Message, ExceptionMessages.LowerBoundsMessage);
            }
        }

        [Test]
        public void FizzBuzzer_WhenRanWithInvalidUpperBounds_ShouldThrowException()
        {
            //should account for upper's high
            try
            {
                new FizzBuzzerImpl().Start(1, 201, 3, 5);
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual(ae.Message, ExceptionMessages.UpperBoundsMessage);
            }

        }

        [Test]
        public void FizzBuzzer_WhenRanWithLowerBoundsGreaterThanUpperBounds_ShouldThrowException()
        {
            //should account for lower being less than upper
            try
            {
                new FizzBuzzerImpl().Start(15, 1, 3, 5);
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual(ae.Message, ExceptionMessages.UpperGreaterThanLowerMessage);
            }
        }

        [Test]
        public void FizzBuzzer_WhenRanWithNotEnoughConfigurations_ShouldThrowException()
        {
            //should account for no fizzers
            try
            {
                new FizzBuzzerImpl().Start(-201, 15, new Dictionary<int, string>());
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual(ae.Message, ExceptionMessages.NoFizzersConfigsMessage);
            }
        }

        [Test]
        public void FizzBuzzer_WhenRanWithTooManyConfigurations_ShouldThrowException()
        {
            //should account for too many fizzers
            var config = new Dictionary<int, string>();
            for (int i = 0; i <= 11; i++)
            {
                config.Add(i,"foo");
            }
            try
            {
                new FizzBuzzerImpl().Start(1, 15, config);
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual(ae.Message, ExceptionMessages.FizzersConfigCountToHighMessage);
            }
        }
    }
}
