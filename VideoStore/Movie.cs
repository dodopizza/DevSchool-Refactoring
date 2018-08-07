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
			this._title = title;
			this._priceCode = priceCode;
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
			double rentalCost = 0;

			switch (PriceCode)
			{
				case NEW_RELEASE:
					rentalCost += (daysRented * 3);

					break;

				case CHILDRENS:
					rentalCost += 1.5;

					if (daysRented > 3)
					{
						rentalCost += ((daysRented - 3) * 1.5);
					}

					break;
			}

			return rentalCost;
		}

	}
}