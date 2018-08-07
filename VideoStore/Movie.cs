namespace VideoStore
{
	public abstract class Movie 
	{
		protected readonly string _title;

		protected Movie(string title) 
		{
			_title = title;
		}

		public virtual string Title => _title;

		public abstract double GetCost(int daysRented);

		public virtual int GetFrequentRenterPoints(int daysRented)
		{
			return 1;
		}
	}
}