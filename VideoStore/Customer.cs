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
			var totalAmount = 0.0;
			var frequentRenterPoints = 0;

			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in _rentals)
			{
				var rentalCost = GetCostFor(rental);

				frequentRenterPoints += GetFrequentRenterPointsFor(rental);

				result += ("\t" + rental.Movie.Title + "\t" + rentalCost.ToString() + "\n");
				totalAmount += rentalCost;
			}


			result += ("Amount owed is " + totalAmount.ToString() + "\n");
			result += ("You earned " + frequentRenterPoints.ToString() + " frequent renter points");

			return result;
		}

		private static double GetCostFor(Rental rental)
		{
			double rentalCost = 0;

			switch (rental.Movie.PriceCode)
			{
				case Movie.REGULAR:
					rentalCost += 2;

					if (rental.DaysRented > 2)
					{
						rentalCost += (rental.DaysRented - 2) * 1.5;
					}

					break;

				case Movie.NEW_RELEASE:
					rentalCost += rental.DaysRented * 3;

					break;

				case Movie.CHILDRENS:
					rentalCost += 1.5;

					if (rental.DaysRented > 3)
					{
						rentalCost += (rental.DaysRented - 3) * 1.5;
					}

					break;
			}

			return rentalCost;
		}

		private static int GetFrequentRenterPointsFor(Rental rental)
		{
			var frequentRenterPoints = 1;

			if (rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1)
			{
				frequentRenterPoints++;
			}

			return frequentRenterPoints;
		}
	}
}