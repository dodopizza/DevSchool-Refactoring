namespace VideoStore
{
	public class Rental 
	{
		private Movie _movie;
		private int _daysRented;

		public Rental(Movie movie, int daysRented) 
		{
			this._movie = movie;
			this._daysRented = daysRented;
		}

		public int DaysRented
		{
            get{ return _daysRented; }
		}

		public Movie Movie
		{
            get { return _movie; }
		}

        public int GetFrequentRenterPoints()
        {
            if ((Movie.PriceCode == Movie.NEW_RELEASE) && (DaysRented > 1))
            {
                return 2;
            }

            return 1;
        }

        public double GetAmount()
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
    }
}