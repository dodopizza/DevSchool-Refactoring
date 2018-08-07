using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    public class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) : base(title)
        {
        }

        public override double GetAmount(int daysRented)
        {
            double result = 1.5;

            if (daysRented > 3)
            {
                result += ((daysRented - 3) * 1.5);
            }

            return result;
        }
    }
}
