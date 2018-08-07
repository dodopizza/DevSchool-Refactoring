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
			var frequentRenterPoints = 0;
			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in rentals)
			{
				frequentRenterPoints += rental.GetFrequentRenterPoints();

				result += "\t" + rental.Movie.Title + "\t" + rental.GetCost() + "\n";
			}

			result += "Amount owed is " + GetTotalAmount() + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points";

			return result;
		}

		private double GetTotalAmount()
		{
			double totalAmount = 0;
			foreach (var rental in rentals)
			{
				totalAmount += rental.GetCost();
			}

			return totalAmount;
		}
	}
}