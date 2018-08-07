using System.Collections.Generic;

namespace VideoStore
{
	public class Customer 
	{
		private readonly List<Rental> _rentals = new List<Rental>();

		public Customer(string name) 
		{
			Name = name;
		}

		public void AddRental(Rental arg) 
		{
			_rentals.Add(arg);
		}

		public string Name { get; }

		public string Statement() 
		{
			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in _rentals)
			{
				var thisAmount = rental.GetCost();
				result += ("\t" + rental.Movie.Title + "\t" + thisAmount + "\n");
			}

			result += ("Amount owed is " + GetTotalAmount() + "\n");
			result += ("You earned " + GetFrequentRenterPoints() + " frequent renter points");

			return result;
		}

		private double GetTotalAmount()
		{
			double totalAmount = 0;
			foreach (var rental in _rentals)
			{
				var thisAmount = rental.GetCost();
				totalAmount += thisAmount;
			}

			return totalAmount;
		}

		private double GetFrequentRenterPoints()
		{
			var frequentRenterPoints = 0;
			foreach (var rental in _rentals)
			{
				frequentRenterPoints += rental.GetFrequentRenterPoints();
			}

			return frequentRenterPoints;
		}
	}
}