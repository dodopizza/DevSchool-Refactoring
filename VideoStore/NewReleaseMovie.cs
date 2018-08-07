namespace VideoStore
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title, Movie.NEW_RELEASE)
        {
        }

        public override double GetCost(int daysRented)
        {
            var rentalCost = (daysRented * 3);

            return rentalCost;
        }
    }
}