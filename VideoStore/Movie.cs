using System;

namespace VideoStore
{
	public abstract class Movie 
	{
		public const int CHILDRENS = 2;
		public const int REGULAR = 0;
		public const int NEW_RELEASE = 1;

		public Movie(string title, int priceCode) 
		{
			Title = title;
			PriceCode = priceCode;
		}

	    public int PriceCode { get; set; }

		public string Title { get; }

		public abstract double GetCost(int daysRented);
	}
}