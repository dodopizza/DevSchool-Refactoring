namespace VideoStore
{
    public class MovieNewRelease : Movie
    {
        public MovieNewRelease(string title) : base(title)
        {
        }
        
        public override string Title => _title + " (New)";

        public override double GetCost(int daysRented)
        {
            return daysRented * 3;
        }
        
        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }
}