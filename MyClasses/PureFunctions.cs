using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class PureFunctions
    {
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public double Divide(int a, int b)
        {
            if (b == 0) throw new ArgumentException("Not possible to divide by 0");

            return (double)a / (double)b;
        }

        public bool IsInCollection(int[] numbers, int numberToFind)
        {
            bool isInCollection = false;

            foreach (var number in numbers)
            {
                if (number == numberToFind)
                {
                    isInCollection = true;
                    break;
                }
            }

            return isInCollection;
        }

        public int[] TransformCollectionNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsEven(numbers[i]))
                {
                    numbers[i] = numbers[i] / 2;
                }
                else
                {
                    numbers[i] = numbers[i] * 2;
                }

                // We could also write it as below, but if you have a VS edition that supports Code Coverage Analysis (or add a third party plugin)
                // it is easier to see the coverage as written above
                // numbers[i] = IsEven(numbers[i]) ? numbers[i] / 2 : numbers[i] * 2;
            }

            return numbers;
        }
    }
}
