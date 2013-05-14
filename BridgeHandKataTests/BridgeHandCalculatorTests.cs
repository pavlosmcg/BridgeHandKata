using System;
using BridgeHandKata;
using NUnit.Framework;

namespace BridgeHandKataTests
{
    [TestFixture]
    public class BridgeHandCalculatorTests
    {
        private BridgeHandCalculator calculator;
        private SuitScorer suitScorer;
        private CardScorer cardScorer;

        [SetUp]
        public void SetUp()
        {
            cardScorer = new CardScorer();
            suitScorer = new SuitScorer(cardScorer);
            calculator = new BridgeHandCalculator(suitScorer);
        }

        [Test]
        public void Test_That_CalculateFromString_Does_Not_Throw_On_Valid_Input()
        {
            Assert.DoesNotThrow(() => calculator.CalculateFromString(@"SAKQ
HAKQ
DAKQ
CAKQJ
"));
        }

        [Test]
        public void Test_That_CalculateFromString_Throws_When_Given_Wrong_Number_Of_Lines()
        {
            string inputString = "7";
            Assert.Throws<ArgumentException>(() => calculator.CalculateFromString(inputString));
        }

        [Test]
        public void Test_That_CalculateFromString_Throws_When_Given_Wrong_Number_Of_Cards()
        {
            string inputString = @"SAKQ???????
HAKQ
DAKQ
CAKQJ
";
            Assert.Throws<ArgumentException>(() => calculator.CalculateFromString(inputString));
        }

        [TestCase(@"SAKQ
HAKQ
DAKQ
CAKQJ
", 37)]
        [TestCase(@"SAKQ
HAKQ
DA?Q
CAKQJ
", 34)]
        public void Test_That_CalculateFromString_Returns_Correct_Score(string inputString, int expected)
        {
            BridgeHandScore result = calculator.CalculateFromString(inputString);
            Assert.AreEqual(result.TotalScore, expected);
        }

        [Test]
        public void Test_That_SuitScore_Is_Not_Greater_Than_Ten()
        {
            string inputString = @"SAKQJ
HAKQ
DAKQ
CAKQ
";
            BridgeHandScore result = calculator.CalculateFromString(inputString);
            Assert.AreEqual(result.Scores['S'], 10);
        }
    }
}
