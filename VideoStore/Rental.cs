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

		public  int GetFrequentRenterPoints()
		{
			return Movie.GetFrequentRenterPoints(DaysRented);
		}
	}
}