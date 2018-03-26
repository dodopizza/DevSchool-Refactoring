namespace VideoStore
{
    public class NewReleaseMovie : Movie
    {
        public override int PriceCode => NEW_RELEASE;

        public NewReleaseMovie(string title) : base(title)
        {
        }

        public override double CostFor(int daysRented)
        {
            return daysRented * 3;
        }
    }
}