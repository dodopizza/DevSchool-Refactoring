namespace VideoStore
{
    public class MovieNewRelease : Movie
    {
        public MovieNewRelease(string title) : base(title)
        {
        }
        
        public override string Title => _title + " (New)";

        public override double GetCost(Rental rental)
        {
            return rental.DaysRented * 3;
        }
        
        public override int GetFrequentRenterPoints(Rental rental)
        {
            return rental.DaysRented > 1 ? 2 : 1;
        }
    }
}