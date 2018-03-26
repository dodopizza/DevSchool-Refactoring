using System;
using System.Collections;
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

			// Select every inside of the parantheses and extract to method called CreateHeader
			var result = "Rental Record for " + Name + "\n";

			foreach (var each in rentals)
			{
				var thisAmount = GetRentalCost(each);
				frequentRenterPoints += GetPointsForRental(each);

				result += "\t" + each.Movie.Title + "\t" + thisAmount + "\n";
				totalAmount += thisAmount;
			}


			result += "Amount owed is " + totalAmount + "\n";
			result += "You earned " + frequentRenterPoints + " frequent renter points";

			return result;
		}

		private double GetRentalCost(Rental rental)
		{
			var thisAmount = 0d;
			
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

		private int GetPointsForRental(Rental each)
		{
			if (each.Movie.PriceCode == Movie.NEW_RELEASE && each.DaysRented > 1)
			{
				return 2;
			}

			return 1;
		}
	}
}