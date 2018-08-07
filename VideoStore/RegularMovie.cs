using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title) : base(title)
        {
        }

        public override double GetAmount(int daysRented)
        {
            double result = 2;

            if (daysRented > 2)
            {
                result += ((daysRented - 2) * 1.5);
            }

            return result;
        }
    }
}
