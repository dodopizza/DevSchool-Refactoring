namespace VideoStore
{
    public class Rental
    {
        public int DaysRented { get; }
        public Movie Movie { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public double Cost => Movie.GetCost(DaysRented);

        public int FrequentRenterPoints => Movie.GetFrequentRenterPoints(DaysRented);
    }
}