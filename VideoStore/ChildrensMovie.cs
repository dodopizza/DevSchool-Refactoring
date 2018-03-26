namespace VideoStore
{
    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title)
        {
        }

        public override double GetCost(int daysRented)
        {
            return daysRented > 3 ? (daysRented - 2) * 1.5 : 1.5;
        }
    }
}