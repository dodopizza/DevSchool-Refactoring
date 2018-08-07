using System.Collections.Generic;
using System.Linq;

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
            string result = "Rental Record for " + Name + "\n";

			foreach (Rental rental in _rentals)
			{
				result += ("\t" + rental.Movie.Title + "\t" + rental.GetAmount().ToString() + "\n");
            }

            result += ("Amount owed is " + GetTotalAmount().ToString() + "\n");
			result += ("You earned " + GetTotalRenterPoints().ToString() + " frequent renter points");

			return result;
		}

        private double GetTotalAmount()
        {
            return _rentals.Sum(x => x.GetAmount());
        }

        private int GetTotalRenterPoints()
        {
            return _rentals.Sum(x => x.GetFrequentRenterPoints());
        }
    }
}