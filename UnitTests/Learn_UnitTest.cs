
using NUnit.Framework;

namespace UnitTests
{
	public class Learn_UnitTest
	{
		[Test]
		public void Add_EmptyString_Returns0()
		{
			StringCalculator calc = new StringCalculator();
			int expectedResult = 0;
			int result = calc.Add("");
			Assert.AreEqual(expectedResult, result);
		}
	}
}
