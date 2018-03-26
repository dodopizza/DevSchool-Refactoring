namespace VideoStore
{
    public class ChildrenMovie : Movie
    {
        public ChildrenMovie(string title, int priceCode) : base(title, priceCode)
        {
        }

        public int PriceCode
        {
            get { return CHILDRENS; }
        }

        public override double CostFor(int daysRented)
        {
            double thisAmount = 1.5;

            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5;
            }

            return thisAmount;
        }
    }
}