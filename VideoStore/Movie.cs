using System;

namespace VideoStore
{
	public abstract class Movie 
	{
		protected string _title;

		public Movie(string title) 
		{
			this._title = title;
		}

        public virtual string Title => _title;

        public abstract double GetAmount(int daysRented);

        public virtual int GetFrequentRenterPoint(int daysRented)
        {
            return 1;
        }
    }
}