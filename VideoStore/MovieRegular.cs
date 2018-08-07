namespace VideoStore
{
    public class MovieRegular : Movie
    {
        public MovieRegular(string title) : base(title)
        {
        }
        
        public override double GetCost(int daysRented)
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