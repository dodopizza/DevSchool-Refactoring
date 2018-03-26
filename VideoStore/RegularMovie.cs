namespace VideoStore
{
    public class RegularMovie : Movie
    {
        public override MovieType PriceCode => MovieType.REGULAR;

        public RegularMovie(string title) : base(title)
        {
        }

        public override double CostFor(int daysRented)
        {
            double thisAmount = 2;

            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5;
            }

            return thisAmount;
        }
    }
}