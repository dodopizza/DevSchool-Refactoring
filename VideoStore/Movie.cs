using System;

namespace VideoStore
{
    public class Movie
    {
        private string title;
        private MovieType priceCode;

        public virtual MovieType PriceCode => priceCode;

        public Movie(string title)
        {
            this.title = title;
        }

        public String Title
        {
            get
            {
                if (PriceCode == MovieType.NEW_RELEASE)
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