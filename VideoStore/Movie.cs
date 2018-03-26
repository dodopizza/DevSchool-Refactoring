namespace VideoStore
{
    public abstract class Movie
    {
        protected readonly string OriginalTitle;

        protected Movie(string title)
        {
            OriginalTitle = title;
        }

        public virtual string Title => OriginalTitle;

        public abstract double GetCost(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class NewRelease : Movie
    {
        public NewRelease(string title) : base(title)
        {
        }

        public override double GetCost(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }

        public override string Title => OriginalTitle + " (New)";
    }

    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title)
        {
        }

        public override double GetCost(int daysRented)
        {
            if (daysRented > 2)
            {
                return 2 + (daysRented - 2) * 1.5;
            }
            else
            {
                return 2;
            }
        }
    }

    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title)
        {
        }

        public override double GetCost(int daysRented)
        {
            if (daysRented > 3)
            {
                return 1.5 * (daysRented - 2);
            }
            else
            {
                return 1.5;
            }
        }
    }
}