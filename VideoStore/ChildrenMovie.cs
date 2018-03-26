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

    }
}