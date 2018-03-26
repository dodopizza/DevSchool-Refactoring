namespace VideoStore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title)
        {
        }

        public override double GetCost(int daysRented)
        {
            return daysRented > 2 ? 2 + (daysRented - 2) * 1.5 : 2;
        }
    }
}