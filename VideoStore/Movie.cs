using System;

namespace VideoStore
{
	public class Movie 
	{
		public const int CHILDRENS = 2;
		public const int REGULAR = 0;
		public const int NEW_RELEASE = 1;
		private readonly string title;

		public Movie(string title, int priceCode) 
		{
			this.title = title;
			PriceCode = priceCode;
		}

	    public int PriceCode { get; set; }

		public string Title => PriceCode == NEW_RELEASE ? title + " (New)" : title;

		public virtual double GetCost(int daysRented)
		{
			switch (PriceCode) 
			{
				case NEW_RELEASE:
					return daysRented * 3;
				default:
					throw new InvalidOperationException();
			}
		}
	}
}