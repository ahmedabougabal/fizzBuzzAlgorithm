using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fizzBuzzAlgo;

namespace fizzBuzzAlgo.Tests
{
    [TestClass]
    public class FizzBuzzDetectorTests
    {
        private FizzBuzzDetector _detector;

        [TestInitialize]
        public void Initialize()
        {
            _detector = new FizzBuzzDetector();
        }

        [TestMethod]
        public void BasicExample_ReturnsCorrectResult()
        {
            // Arrange
            string input = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white as snow";
            
            // Act
            var result = _detector.GetOverlappings(input);
            
            // Assert
            string expected = "Mary had Fizz little Buzz\nFizz lamb, little Fizz\nBuzz had Fizz little lamb\nFizzBuzz's fleece Fizz white Buzz Fizz";
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {result.OutputString}");
            Assert.AreEqual(expected, result.OutputString);
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullInput_ThrowsArgumentNullException()
        {
            _detector.GetOverlappings(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShortInput_ThrowsArgumentException()
        {
            _detector.GetOverlappings("Short");
        }

        [TestMethod]
        public void OnlyNonAlphanumeric_ReturnsOriginalString()
        {
            // Arrange
            string input = "!@# $%^ &*( )_+ -=";
            
            // Act
            var result = _detector.GetOverlappings(input);
            
            // Assert
            Assert.AreEqual(input, result.OutputString);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ExactlyFifteenWords_ContainsFizzBuzzAndFizzBuzz()
        {
            // Arrange
            string input = "one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen";
            
            // Act
            var result = _detector.GetOverlappings(input);
            
            // Assert
            string expected = "one two Fizz four Buzz Fizz seven eight Fizz Buzz eleven Fizz thirteen fourteen FizzBuzz";
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {result.OutputString}");
            Assert.AreEqual(expected, result.OutputString);
            Assert.AreEqual(7, result.Count);
        }
    }
}
