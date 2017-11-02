using System;

namespace UnitTests.Core
{
	public class StringCalculator
	{
		private readonly IStore _store;


		//public StringCalculator()
		//{
		//}

		public StringCalculator(IStore store)
		{
			_store = store;
		}

		public int Add(string inputValue)
		{

			if (string.IsNullOrEmpty(inputValue)) return 0;

			var numbers = inputValue.Split(',');
			var total = 0;
			foreach(var number in numbers)
			{
				total += TryparseToInteger(number);
			}
			if (_store != null)
			{
				if (IsPrime(total))
					_store.Save(total);  
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

		private bool IsPrime(int number)
		{
			if (number == 2) return true;
			if (number % 2 == 0) return false;
			for (int i = 3; i <= (int)(Math.Sqrt(number)); i += 2)
			{
				if (number % i == 0) return false;
			}
			return true;
		}
	}
}