namespace VideoStore
{
	public abstract class Movie 
	{
		protected Movie(string title) 
		{
			Title = title;
		}

		public string Title { get; }

		public abstract double GetCost(int daysRented);
	}
}