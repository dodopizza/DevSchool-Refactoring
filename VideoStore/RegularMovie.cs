namespace VideoStore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title, Movie.REGULAR)
        {
        }

        public override double GetCost(int daysRented)
        {
            var rentalCost = 0d;
            rentalCost += 2;

            if (daysRented > 2)
            {
                rentalCost += ((daysRented - 2) * 1.5);
            }

            return rentalCost;
        }
    }
}