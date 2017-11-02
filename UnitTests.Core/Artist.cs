using System;

namespace UnitTests.Core
{
	public class Artist
	{

		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		private int rate { get; set; }
		public Genre Genre { get; set; }


		public int Rate
		{ 
			get { return rate; }
			set {
				if (value<0)
					throw new ArgumentOutOfRangeException("rate should not be negative");
				rate = value;
			}
		}

		public long Id { get; set; }

		public Artist()
		{

		}

		public Artist(string name, DateTime birthDate, int rate, Genre genre)
		{
			//Improve if set attribute
			//if (rate < 0)
			//	throw new ArgumentOutOfRangeException("rate should not be negative");

			Name = name;
			BirthDate = birthDate;
			Rate = rate;
			Genre = genre;
		}

		public override bool Equals(object obj)
		{
			return Id == (obj as Artist).Id;
		}

		public override int GetHashCode()
		{
			return Convert.ToInt32(Id);
		}

	}
}