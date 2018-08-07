using System.Collections.Generic;

namespace VideoStore
{
	public class Customer 
	{
		private readonly List<Rental> rentals = new List<Rental>();

		public Customer(string name) 
		{
			this.Name = name;
		}

		public void AddRental(Rental arg) 
		{
			rentals.Add(arg);
		}

		public string Name { get; }

		public string Statement() 
		{
			double totalAmount = 0;
			var frequentRenterPoints = 0;

			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in rentals)
			{
				var rentalCost = rental.GetCost();

				frequentRenterPoints += rental.GetFrequentRenterPoints();

				result += ("\t" + rental.Movie.Title + "\t" + rentalCost.ToString() + "\n");
				totalAmount += rentalCost;
			}

			result += "Amount owed is " + totalAmount.ToString() + "\n";
			result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

			return result;
		}
	}
}