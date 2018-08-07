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
            int frequentRenterPoints = 0;

            string result = "Rental Record for " + Name + "\n";

			foreach (Rental rental in _rentals)
			{
				double thisAmount = rental.GetAmount();

				//show figures for this rental
				result += ("\t" + rental.Movie.Title + "\t" + thisAmount.ToString() + "\n");
				totalAmount += thisAmount;

                frequentRenterPoints += rental.GetFrequentRenterPoints();
            }

            //add footer lines

            result += ("Amount owed is " + totalAmount.ToString() + "\n");
			result += ("You earned " + frequentRenterPoints.ToString() + " frequent renter points");

			return result;
		}
	}
}