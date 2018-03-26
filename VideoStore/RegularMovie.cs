namespace VideoStore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

        public int PriceCode
        {
            get { return REGULAR; }
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