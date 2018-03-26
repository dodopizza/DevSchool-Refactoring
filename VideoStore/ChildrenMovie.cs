namespace VideoStore
{
    public class ChildrenMovie : Movie
    {
        public override MovieType PriceCode => MovieType.CHILDRENS;

        public ChildrenMovie(string title) : base(title)
        {
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