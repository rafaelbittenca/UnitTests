using NUnit.Framework;
using System;
using UnitTests.Core;

namespace UnitTests
{
	public class ArtistTest
	{
		[Test]
		public void ConstructorShouldSetProperties()
		{
			//Arrange
			//Act
			Artist artist = new Artist("Eric", new DateTime(1979, 3, 10), 5, Genre.Rock);

			//Assert
			Assert.AreEqual("Eric", artist.Name);
			Assert.AreEqual(new DateTime(1979, 3, 10), artist.BirthDate);
			Assert.AreEqual(5, artist.Rate);
			Assert.AreEqual(Genre.Rock, artist.Genre);
		}


		[Test]
		//Nunit 3 removed
		//[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ConstructorShouldThrowExceptionIfRateIsNegative()
		{
			Assert.That(() => new Artist("Eric", new DateTime(1979, 3, 10), -5, Genre.Rock), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void ArtistsWithSameIdShouldBeEqual()
		{
			//Arrange
			var artist1 = new Artist { Id = 1L };
			var artist2 = new Artist { Id = 1L };

			//act (execute methods under tests)
			//assert (verify tests results)
			Assert.AreEqual(artist1, artist2);
			Assert.AreEqual(artist1.GetHashCode(), artist2.GetHashCode());
		}

		[Test]
		public void ArtistsWithDifferentIdsShouldBeNotEqual()
		{
			//Arrange
			var artist1 = new Artist { Id = 1L };
			var artist2 = new Artist { Id = 2L };

			//act (execute methods under tests)
			//assert (verify tests results)
			Assert.AreNotEqual(artist1, artist2);
			Assert.AreNotEqual(artist1.GetHashCode(), artist2.GetHashCode());
		}
	}
}
