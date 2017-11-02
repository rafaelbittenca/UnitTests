using System.Collections.Generic;

namespace UnitTests.Core
{
	public interface IArtistRepository
	{
		IList<Artist> FindAll();

		Artist FindByName(string artistName);

		Artist FindById(int artistId);

		bool Save(Artist target);
	}
}
