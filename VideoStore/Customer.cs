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

		public string Name { get; }

		public void AddRental(Rental rental)
		{
			_rentals.Add(rental);
		}

		public string Statement()
		{
			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in _rentals)
			{
				result += ("\t" + rental.Movie.Title + "\t" + rental.GetCost().ToString() + "\n");
			}

			result += ("Amount owed is " + GetTotalCost() + "\n");
			result += ("You earned " + GetFrequentRenterPoints().ToString() + " frequent renter points");

			return result;
		}

		private double GetTotalCost()
		{
			var totalAmount = 0.0;

			foreach (var rental in _rentals)
			{
				var rentalCost = rental.GetCost();
				totalAmount += rentalCost;
			}

			return totalAmount;
		}

		public int GetFrequentRenterPoints()
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