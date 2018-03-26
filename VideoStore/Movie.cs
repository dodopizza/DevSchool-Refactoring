using System;

namespace VideoStore
{
	public class Movie 
	{
		public const int CHILDRENS = 2;
		public const int REGULAR = 0;
		public const int NEW_RELEASE = 1;
		private string _title;
		private int _priceCode;

		public Movie(string title, int priceCode) 
		{
			_title = title;
			_priceCode = priceCode;
		}

	    public int PriceCode
	    {
            get { return _priceCode; }
            set { _priceCode = value; }
	    }

		public String Title 
		{
            get {
                if (_priceCode == 1)
                return _title + " (New)";
                return _title;
            }
			
		}

		public virtual double GetCost(int daysRented)
		{
			switch (PriceCode) 
			{
				case NEW_RELEASE:
					return daysRented * 3;

				case CHILDRENS:
					return daysRented > 3 ? (daysRented - 2) * 1.5 : 1.5;
				default:
					throw new InvalidOperationException();
			}
		}
	}
}