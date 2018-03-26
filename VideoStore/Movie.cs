using System;

namespace VideoStore
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        private string title;
        private int priceCode;

        public Movie(string title)
        {
            this.title = title;
        }

        public virtual int PriceCode
        {
            get { return priceCode; }
        }

        public String Title
        {
            get
            {
                if (PriceCode == 1)
                    return title + " (New)";
                return title;
            }
        }

        public virtual double CostFor(int daysRented)
        {
            return 0;
        }
    }
}