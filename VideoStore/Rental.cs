using System;

namespace VideoStore
{
	public class Rental 
	{
		public Rental(Movie movie, int daysRented) 
		{
			Movie = movie;
			DaysRented = daysRented;
		}

		public int DaysRented { get; }

		public Movie Movie { get; }
		
		
		public double GetRentalCost()
		{
			switch (Movie.PriceCode) 
			{
				case Movie.REGULAR:
					return DaysRented > 2 ? 2 + (DaysRented - 2) * 1.5 : 2;

				case Movie.NEW_RELEASE:
					return DaysRented * 3;

				case Movie.CHILDRENS:
					return DaysRented > 3 ? (DaysRented - 2) * 1.5 : 1.5;
				default:
					throw new InvalidOperationException();
			}
		}
		
		public int GetPointsForRenter()
		{
			return Movie.PriceCode == Movie.NEW_RELEASE && DaysRented > 1 ? 2 : 1;
		}
	}
}