using System;

namespace UnitTests.Core
{
	public class StringCalculator
	{
		public int Add(string inputValue)
		{

			if (string.IsNullOrEmpty(inputValue)) return 0;

			var numbers = inputValue.Split(',');
			var total = 0;
			foreach(var number in numbers)
			{
				total += TryparseToInteger(number);
			}
			return total;
		}

		private int TryparseToInteger(string input)
		{
			int dest;
			if (!int.TryParse(input, out dest))
			{
				throw new ArgumentException("Input format was incorrect");
			}
			return dest;
		}
	}
}