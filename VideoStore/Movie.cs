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
	}
}