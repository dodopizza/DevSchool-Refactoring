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
			double thisAmount = 0;

			switch (Movie.PriceCode)
			{
				case Movie.REGULAR:
					thisAmount += 2;

					if (DaysRented > 2)
					{
						thisAmount += ((DaysRented - 2) * 1.5);
					}

					break;
				case Movie.NEW_RELEASE:
					thisAmount += (DaysRented * 3);
					break;
				case Movie.CHILDRENS:
					thisAmount += 1.5;

					if (DaysRented > 3)
					{
						thisAmount += ((DaysRented - 3) * 1.5);
					}

					break;
			}

			return thisAmount;
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