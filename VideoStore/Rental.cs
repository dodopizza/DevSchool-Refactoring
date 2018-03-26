namespace VideoStore
{
	public class Rental 
	{
		public int DaysRented { get; }
		public Movie Movie { get; }

		public Rental(Movie movie, int daysRented)
		{
			Movie = movie;
			DaysRented = daysRented;
		}

		public int FrequentRenterPoints
		{
			get
			{
				var isNewFilm = Movie.PriceCode == Movie.NEW_RELEASE && DaysRented > 1;

				return isNewFilm ? 2 : 1;
			}
		}

		public double Cost
		{
			get
			{
				switch (Movie.PriceCode)
				{
					case Movie.REGULAR:
						return RegularMovieCost();
					case Movie.NEW_RELEASE:
						return NewReleaseCost();
					case Movie.CHILDRENS:
						return ChildrenMovieCost();
					default:
						return 0;
				}
			}
		}

		private double ChildrenMovieCost()
		{
			double thisAmount = 1.5;

			if (DaysRented > 3)
			{
				thisAmount += (DaysRented - 3) * 1.5;
			}

			return thisAmount;
		}

		private double RegularMovieCost()
		{
			double thisAmount = 2;

			if (DaysRented > 2)
			{
				thisAmount += (DaysRented - 2) * 1.5;
			}

			return thisAmount;
		}

		private double NewReleaseCost()
		{
			return DaysRented * 3;
		}
	}
}