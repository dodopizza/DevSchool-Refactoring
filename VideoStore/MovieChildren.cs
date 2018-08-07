namespace VideoStore
{
    public class MovieChildren : Movie
    {
        public MovieChildren(string title) : base(title)
        {
        }
        
        public override double GetCost(Rental rental)
        {
            var thisAmount =  1.5;

            if (rental.DaysRented > 3)
            {
                thisAmount += (rental.DaysRented - 3) * 1.5;
            }

            return thisAmount;
        }
    }
}