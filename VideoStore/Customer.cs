using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
	public class Customer 
	{
		private readonly List<Rental> rentals = new List<Rental>();

		public Customer(string name) 
		{
			Name = name;
		}

		public void AddRental(Rental arg) 
		{
			rentals.Add(arg);
		}

		public string Name { get; }

		public string Statement() 
		{
			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in rentals)
			{
				result += "\t" + rental.Movie.Title + "\t" + rental.GetRentalCost() + "\n";
			}


			result += "Amount owed is " + GetTotalRentalCost() + "\n";
			result += "You earned " + GetTotalRenterPoints() + " frequent renter points";

			return result;
		}

		private int GetTotalRenterPoints()
		{
			return rentals.Sum(rental => rental.GetPointsForRenter());
		}

		private double GetTotalRentalCost()
		{
			return rentals.Sum(rental => rental.GetRentalCost());
		}
	}
}