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
            return Movie.GetFrequentRenterPoint(DaysRented);
        }

        public double GetAmount()
        {
            return Movie.GetAmount(DaysRented);
        }
    }
}