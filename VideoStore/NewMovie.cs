namespace VideoStore
{
    public class NewMovie : Movie
    {
        public NewMovie(string title) : base($"{title} (New)", NEW_RELEASE)
        {
        }

        public override double GetCost(int daysRented)
        {
            return daysRented * 3;
        }
    }
}