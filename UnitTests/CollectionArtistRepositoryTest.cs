using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Core;

namespace UnitTests
{
	public class CollectionArtistRepositoryTest
	{
		
		public CollectionArtistRepositoryTest()
		{
			// create some mock products to play with
			IList<Artist> artists = new List<Artist>
			{
			  new Artist { Id = 1, Name = "Eric" },
			  new Artist { Id = 2, Name = "John" },
			  new Artist { Id = 3, Name = "Steve"}
			};

			// Mock the Artist Repository using Moq
			Mock<IArtistRepository> mockArtistRepository = new Mock<IArtistRepository>();

			// Return all the Artists
			mockArtistRepository.Setup(mr => mr.FindAll()).Returns(artists);

			// return a Artist by Id
			mockArtistRepository.Setup(mr => mr.FindById(
			    It.IsAny<int>())).Returns((int i) => artists.Where(
			    x => x.Id == i).Single());

			// return a Artist by Name
			mockArtistRepository.Setup(mr => mr.FindByName(
			    It.IsAny<string>())).Returns((string s) => artists.Where(
			    x => x.Name == s).Single());


			// Allows us to test saving a Artist
			mockArtistRepository.Setup(mr => mr.Save(It.IsAny<Artist>())).Returns(
			    (Artist target) =>
			    {
				    if (target.Id.Equals(default(int)))
				    {
					    target.Name = target.Name;
					    target.Id = artists.Count() + 1;
					    artists.Add(target);
				    }
				    else
				    {
					    var original = artists.Where(
					  q => q.Id == target.Id).Single();

					    if (original == null)
					    {
						    return false;
					    }

					    original.Name = target.Name;
				    }

				    return true;
			    });

			// Complete the setup of our Mock Artist Repository
			this.MockArtistRepository = mockArtistRepository.Object;
		}

		/// <summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }

		/// <summary>
		/// Our Mock Products Repository for use in testing
		/// </summary>
		public readonly IArtistRepository MockArtistRepository;

		[Test]
		public void CanReturnArtistById()
		{
			// Try finding a product by id
			Artist testArtist = this.MockArtistRepository.FindById(2);

			Assert.IsNotNull(testArtist); // Test if null
			Assert.AreEqual("John", testArtist.Name); // Verify it is the right product
		}


		[Test]
		public void CanReturnArtistByName()
		{
			// Try finding a Artist by Name
			Artist testArtist = this.MockArtistRepository.FindByName("Eric");
			Assert.IsNotNull(testArtist);		// Test if null
			Assert.AreEqual(1, testArtist.Id); // Verify it is the right Artist
		}

		
		[Test]
		public void CanReturnAllArtists()
		{
			// Try finding all artists
			IList<Artist> testArtists= this.MockArtistRepository.FindAll();

			Assert.IsNotNull(testArtists); 
			Assert.AreEqual(4, testArtists.Count); 
		}

		[Test]
		public void CanInsertArtist()
		{
			// Create a new artist, not I do not supply an id
			Artist newArtist = new Artist	{ Name = "Maria" };

			int artistCount = this.MockArtistRepository.FindAll().Count;
			Assert.AreEqual(3, artistCount); // Verify the expected Number pre-insert

			// try saving our new artist
			this.MockArtistRepository.Save(newArtist);

			// demand a recount
			artistCount = this.MockArtistRepository.FindAll().Count;
			Assert.AreEqual(4, artistCount); // Verify the expected Number post-insert

			// verify that our new artist has been saved
			Artist testArtist = this.MockArtistRepository.FindByName("Maria");
			Assert.IsNotNull(testArtist); 
			Assert.AreEqual(4, testArtist.Id); 
		}

		[Test]
		public void CanUpdateProduct()
		{
			// Find a product by id
			Artist testArtist = this.MockArtistRepository.FindById(1);

			// Change one of its properties
			testArtist.Name = "Eric";

			// Save our changes.
			this.MockArtistRepository.Save(testArtist);

			// Verify the change
			Assert.AreEqual("Eric", this.MockArtistRepository.FindById(1).Name);
		}
	}
}
