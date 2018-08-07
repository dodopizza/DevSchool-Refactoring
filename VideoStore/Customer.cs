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
			double totalAmount = 0;
			var frequentRenterPoints = 0;

			var result = "Rental Record for " + Name + "\n";

			foreach (var rental in _rentals)
			{
				var thisAmount = GetCostFor(rental);

				frequentRenterPoints += FrequentRenterPointsFor(rental);

				result += ("\t" + rental.Movie.Title + "\t" + thisAmount + "\n");
				totalAmount += thisAmount;
			}

			result += ("Amount owed is " + totalAmount + "\n");
			result += ("You earned " + frequentRenterPoints + " frequent renter points");

			return result;
		}

		private static int FrequentRenterPointsFor(Rental rental)
		{
			var frequentRenterPoints = 1;

			if (rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1)
			{
				frequentRenterPoints++;
			}

			return frequentRenterPoints;
		}

		private static double GetCostFor(Rental rental)
		{
			double thisAmount = 0;

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