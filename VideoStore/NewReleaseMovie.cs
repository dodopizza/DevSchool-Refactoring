namespace VideoStore
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title)
        {
        }

        public override string Title => _title + " (New)";

        public override double GetCost(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            var frequentRenterPoints = 1;

            if (daysRented > 1)
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }
    }
}