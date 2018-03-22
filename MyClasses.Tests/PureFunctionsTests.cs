using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClasses.Tests
{
    [TestClass]
    public class PureFunctionsTests
    {
        [TestMethod]
        public void IsEvenReturnsTrueTest()
        {
            // Arrange
            var functions = new PureFunctions();

            // Act 
            bool result = functions.IsEven(2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEvenReturnsFalseTest()
        {
            // Arrange
            var functions = new PureFunctions();

            // Act 
            bool result = functions.IsEven(3);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DivideReturnsRightResultTest()
        {
            // Arrange
            double expected = 3.5;
            var functions = new PureFunctions();

            // Act 
            double actual = functions.Divide(7, 2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DivideThrowsExceptionWhenDividingByZeroTest()
        {
            // Arrange
            var functions = new PureFunctions();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => functions.Divide(7, 0));
            // We sow it with the ExpectedException attribute but can also be checked like this,
            // passing a System.Action to the Assert.ThrowsExceptioon<T>
        }

        [TestMethod]
        public void IsInCollectionRetursTrueTest()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            var functions = new PureFunctions();

            // Act 
            bool result = functions.IsInCollection(numbers, 2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInCollectionRetursFalseTest()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            var functions = new PureFunctions();

            // Act 
            bool result = functions.IsInCollection(numbers, 6);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TransformCollectionNumbersTest()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int[] expected = new int[] { 2, 1, 6, 2, 10 };
            var functions = new PureFunctions();

            // Act 
            int[] actual = functions.TransformCollectionNumbers(numbers);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
