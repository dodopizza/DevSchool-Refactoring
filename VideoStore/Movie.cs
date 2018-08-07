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

		public abstract double GetCost(Rental rental);

		public virtual int GetFrequentRenterPoints(Rental rental)
		{
			return 1;
		}
	}
}