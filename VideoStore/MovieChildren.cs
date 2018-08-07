namespace VideoStore
{
    public class MovieChildren : Movie
    {
        public MovieChildren(string title) : base(title)
        {
        }
        
        public override double GetCost(int daysRented)
        {
            var thisAmount =  1.5;

            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5;
            }

            return thisAmount;
        }
    }
}