using System.Collections.Generic;

namespace VideoStore
{
	public class Customer 
	{
		private string _name;
		private List<Rental> _rentals = new List<Rental>();

		public Customer(string name) 
		{
			this._name = name;
		}

		public void AddRental(Rental arg) 
		{
			_rentals.Add(arg);
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string Statement() 
		{
			double totalAmount = 0;

			string result = "Rental Record for " + Name + "\n";

			foreach (Rental rental in _rentals)
			{
				double thisAmount = GetAmountFor(rental);

				//show figures for this rental
				result += ("\t" + rental.Movie.Title + "\t" + thisAmount.ToString() + "\n");
				totalAmount += thisAmount;
			}

			//add footer lines
			result += ("Amount owed is " + totalAmount.ToString() + "\n");
			result += ("You earned " + GetPoints().ToString() + " frequent renter points");

			return result;
		}

        public int GetPoints()
        {
            int frequentRenterPoints = 0;

            string result = "Rental Record for " + Name + "\n";

            foreach (Rental rental in _rentals)
            {
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if ((rental.Movie.PriceCode == Movie.NEW_RELEASE)
                    && (rental.DaysRented > 1))
                {
                    frequentRenterPoints++;
                }
            }

            return frequentRenterPoints;
        }

        public double GetAmountFor(Rental rental)
        {
            double thisAmount = 0;

            //determine amounts for each line
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;

                    if (rental.DaysRented > 2)
                    {
                        thisAmount += ((rental.DaysRented - 2) * 1.5);
                    }

                    break;

                case Movie.NEW_RELEASE:
                    thisAmount += (rental.DaysRented * 3);

                    break;

                case Movie.CHILDRENS:
                    thisAmount += 1.5;

                    if (rental.DaysRented > 3)
                    {
                        thisAmount += ((rental.DaysRented - 3) * 1.5);
                    }

                    break;
            }

            return thisAmount;
        }
	}
}