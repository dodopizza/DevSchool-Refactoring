namespace VideoStore
{
	public class Rental 
	{
		public int DaysRented { get; }
		public Movie Movie { get; }

		public double Cost => Movie.CostFor(DaysRented);

		public Rental(Movie movie, int daysRented)
		{
			Movie = movie;
			DaysRented = daysRented;
		}

		public int FrequentRenterPoints
		{
			get
			{
				var isNewFilm = Movie.PriceCode == MovieType.NEW_RELEASE && DaysRented > 1;

				return isNewFilm ? 2 : 1;
			}
		}
	}
}