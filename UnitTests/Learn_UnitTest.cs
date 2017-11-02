
using NUnit.Framework;
using System;
using UnitTests.Core;

namespace UnitTests
{
	public class Learn_UnitTest
	{
		private StringCalculator GetCalculator()
		{
			var calc = new StringCalculator();
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

		[Test]
		public void Add_InvalidString_ThrowException()
		{
			StringCalculator calc = GetCalculator();
			string input = "a,1";
			//calc.Add(input);
			Assert.That(() => calc.Add(input), Throws.TypeOf<ArgumentException>());
		}
	}
}
