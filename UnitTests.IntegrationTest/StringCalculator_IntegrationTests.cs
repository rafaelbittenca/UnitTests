using NUnit.Framework;
using System.IO;
using UnitTests.Core;

namespace UnitTests.IntegrationTest
{
	public class StringCalculator_IntegrationTests
    {
		private string _filePath = @"c:\Teste\test.txt";

		[OneTimeSetUp]
		public void SetUp()
		{
			if (File.Exists(_filePath))
				File.Delete(_filePath);
		}

		[Test]
		public void Add_ResultIsPrime_CreatesFile()
		{
			
			FileStore store = new FileStore(_filePath);
			StringCalculator calc = new StringCalculator(store);
			var result = calc.Add("5,6");
			Assert.IsTrue(File.Exists(_filePath));
		}

		[OneTimeTearDown]
		public void CleanUp()
		{
			if (File.Exists(_filePath))
				File.Delete(_filePath);
		}
	}

	public class FileStore : IStore
	{
		private readonly string _filePath;
		public int Result { get; set; }

		public FileStore(string filePath)
		{
			_filePath = filePath;
		}

		public void Save(int result)
		{
			using(var writer = File.CreateText(_filePath))
			{
				writer.Write(result);
			};
		}
	}
}
