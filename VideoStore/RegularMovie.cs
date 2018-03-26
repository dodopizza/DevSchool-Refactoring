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
    }
}