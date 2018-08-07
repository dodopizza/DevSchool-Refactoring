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

		public double GetCost()
		{
			return Movie.GetCost(DaysRented);
		}

		public int GetFrequentRenterPoints()
		{
			var frequentRenterPoints = 1;

			if (Movie.PriceCode == Movie.NEW_RELEASE && DaysRented > 1)
			{
				frequentRenterPoints++;
			}

			return frequentRenterPoints;
		}
	}
}