
using Moq;
using NUnit.Framework;
using System;
using UnitTests.Core;

namespace UnitTests
{
	public class Learn_UnitTest
	{
		private Mock<IStore> _mockStore;

		private StringCalculator GetCalculator()
		{
			_mockStore = new Mock<IStore>();
			var calc = new StringCalculator(_mockStore.Object);
			return calc;
		}

		[Test]
		public void Add_EmptyString_Returns0()
		{
			StringCalculator calc = GetCalculator();
			int expectedResult = 0;
			int result = calc.Add("");
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("1", 1)]
		[TestCase("2", 2)]
		[TestCase("9", 9)]
		[TestCase("10", 10)]
		public void Add_SingleNumbers_ReturnsTheNumber(string input, int expectedResult)
		{
			StringCalculator calc = GetCalculator();
			int result = calc.Add(input);
			Assert.AreEqual(expectedResult, result);
		}
		
		[TestCase("110,11", 121)]
		[TestCase("5,3,2", 10)]
		[TestCase("5,1,3", 9)]
		[TestCase("25,30", 55)]
		public void Add_Multiple_SumOfAll(string input, int expectedResult)
		{
			StringCalculator calc = GetCalculator();
			int result = calc.Add(input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("a,1")]
		[TestCase("/,8,)")]
		[TestCase("abc,''")]
		public void Add_InvalidString_ThrowException(string input)
		{
			StringCalculator calc = GetCalculator();
			//string input = "a,1";
			Assert.That(() => calc.Add(input), Throws.TypeOf<ArgumentException>());
		}

		[TestCase("-1,5", 4)]
		[TestCase("-1,-2", -3)]
		[TestCase("-2", -2)]
		[TestCase("-1,-3,-10", -14)]
		public void MinuNumbers_AreSummedCorrectly(string input, int expectedResult)
		{
			StringCalculator calc = GetCalculator();
			int result = calc.Add(input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("2")]
		[TestCase("5,6")]
		[TestCase("3,4")]
		[TestCase("10,10,3")]
		[TestCase("5,5,5,5,5,5,5,5,5,5,3")]
		public void Add_ResultIsPrimeNumber_ResultsAreSaved(string input)
		{
			//Constructor
			//Mock<IStore> mockStore = new Mock<IStore>();
			//StringCalculator calc = new StringCalculator(mockStore.Object);
			StringCalculator calc = GetCalculator();
			var result = calc.Add(input);
			_mockStore.Verify(m => m.Save(It.IsAny<int>()), Times.Once());

		}


		[TestCase("4")]
		[TestCase("5,5")]
		[TestCase("5,4")]
		public void Add_ResultIs_NOT_PrimeNumber_ResultsAre_NOT_Saved(string input)
		{
			StringCalculator calc = GetCalculator();
			var result = calc.Add(input);
			_mockStore.Verify(m => m.Save(It.IsAny<int>()), Times.Never());

		}
	}
}
