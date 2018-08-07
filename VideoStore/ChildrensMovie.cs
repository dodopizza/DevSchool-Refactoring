namespace VideoStore
{
    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title)
        {
        }

        public override double GetCost(int daysRented)
        {
            var rentalCost = 1.5;

            if (daysRented > 3)
            {
                rentalCost += (daysRented - 3) * 1.5;
            }

            return rentalCost;
        }
    }
}