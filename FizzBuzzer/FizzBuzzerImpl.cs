using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzer
{
    public class FizzBuzzerImpl
    {
        public IEnumerable<string> Start(int lower, int upper, int fizz, int buzz)
        {
            ValidateInputs(lower, upper, new Dictionary<int, string>()
            {
                {fizz, "Fizz"},
                {buzz, "Buzz"}
            });

            for (int i = lower; i <= upper; i++)
            {
                if (i % fizz == 0)
                {
                    yield return "Fizz";
                }

                if (i % buzz == 0)
                {
                    yield return "Buzz";
                }

                if (i%fizz != 0 && i%buzz != 0)
                {
                    yield return i.ToString();
                }
            }
        }

        public IEnumerable<string> Start(int lower, int upper, Dictionary<int, string> fizzers)
        {
            ValidateInputs(lower, upper, fizzers);

            bool hasMatch = false;
            string result = "";

            for (int i = lower; i <= upper; i++)
            {
                //for each iteration, check all test values
                foreach (KeyValuePair<int, string> pair in fizzers)
                {
                    if (i%pair.Key == 0)
                    {
                        hasMatch = true;
                        result = result + pair.Value + " ";
                    }
                }

                if (hasMatch)
                {
                    yield return result;
                }
                else
                {
                    yield return i.ToString();
                }

                //reset
                hasMatch = false;
                result = "";
            }
        }

        public void ValidateInputs(int lower, int upper, Dictionary<int, string> fizzers)
        {
            //setting artificial boundaries
            if (lower < -200)
            {
                throw new ApplicationException(ExceptionMessages.LowerBoundsMessage);
            }

            if (upper > 200)
            {
                throw new ApplicationException(ExceptionMessages.UpperBoundsMessage);
            }

            if (upper < lower)
            {
                throw new ApplicationException(ExceptionMessages.UpperGreaterThanLowerMessage);
            }

            if (fizzers.Count() > 10)
            {
                throw new ApplicationException(ExceptionMessages.FizzersConfigCountToHighMessage);
            }

            if (!fizzers.Any())
            {
                throw new ApplicationException(ExceptionMessages.NoFizzersConfigsMessage);
            }
        }
    }

    public static class ExceptionMessages
    {
        public static string LowerBoundsMessage = "Lower bounds has been exceeded.  No less than -200 allowed.";
        public static string UpperBoundsMessage = "Upper bound has been exceeded.  No greater than 200 allowed.";
        public static string UpperGreaterThanLowerMessage = "The upper bounds is not allowed to be less than the lower bounds.";
        public static string FizzersConfigCountToHighMessage = "Amount of fizzers to tests has been exceeded.  No more than 10 tests are allowed.";
        public static string NoFizzersConfigsMessage = "There should be at least one fizzer to test against.";
    }

    //homework
    //1 write tests to ensure it works as expected
    //2 make it extensible with configureable amount of number / word pairs
    //  if multiple numbers match print on one line
    //  example: 3, 5, 8 all match - print on one line
    //  ie: run all tests per iteration
    //
    //  Put on github
}
