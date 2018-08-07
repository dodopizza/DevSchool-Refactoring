using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) : base(title)
        {
        }

        public override string Title => _title + " (New)";

        public override int GetFrequentRenterPoint(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }

        public override double GetAmount(int daysRented)
        {
            return daysRented * 3;
        }
    }
}
