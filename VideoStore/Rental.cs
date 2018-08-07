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
			double rentalCost = 0;

			switch (Movie.PriceCode)
			{
				case Movie.REGULAR:
					rentalCost += 2;

					if (DaysRented > 2)
					{
						rentalCost += (DaysRented - 2) * 1.5;
					}

					break;

				case Movie.NEW_RELEASE:
					rentalCost += DaysRented * 3;

					break;

				case Movie.CHILDRENS:
					rentalCost += 1.5;

					if (DaysRented > 3)
					{
						rentalCost += (DaysRented - 3) * 1.5;
					}

					break;
			}

			return rentalCost;
		}
	}
}