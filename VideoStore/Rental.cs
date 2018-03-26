using System;

namespace VideoStore
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int DaysRented { get; }

        public Movie Movie { get; }


        public double GetRentalCost()
        {
            return Movie.GetCost(DaysRented);
        }

        public int GetPointsForRenter()
        {
            return Movie.PriceCode == Movie.NEW_RELEASE && DaysRented > 1 ? 2 : 1;
        }
    }
}