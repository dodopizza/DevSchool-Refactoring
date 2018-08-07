namespace VideoStore
{
    public class MovieRegular : Movie
    {
        public MovieRegular(string title) : base(title)
        {
        }
        
        public override double GetCost(Rental rental)
        {
            double thisAmount = 2;

            if (rental.DaysRented > 2)
            {
                thisAmount += (rental.DaysRented - 2) * 1.5;
            }

            return thisAmount;
        }
    }
}