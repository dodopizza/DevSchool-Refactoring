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
			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in rentals)
			{
				result += "\t" + rental.Movie.Title + "\t" + rental.GetCost() + "\n";
			}

			result += "Amount owed is " + GetTotalCost() + "\n";
			result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points";

			return result;
		}

		private double GetTotalCost()
		{
			double totalAmount = 0;
			foreach (var rental in rentals)
			{
				totalAmount += rental.GetCost();
			}

			return totalAmount;
		}

		private int GetTotalFrequentRenterPoints()
		{
			var frequentRenterPoints = 0;
			foreach (var rental in rentals)
			{
				frequentRenterPoints += rental.GetFrequentRenterPoints();
			}

			return frequentRenterPoints;
		}
	}
}