using System;

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

		public virtual double GetCost(int daysRented)
		{
			var rentalCost = 2.0;

			if (daysRented > 2)
			{
				rentalCost += (daysRented - 2) * 1.5;
			}

			return rentalCost;
		}

		public virtual int GetFrequentRenterPoints(int daysRented)
		{
			return 1;
		}
	}
}