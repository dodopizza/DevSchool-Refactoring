using System;
using System.Collections;
using System.Collections.Generic;

namespace VideoStore
{
	public class Customer 
	{
		private readonly string _name;
		private readonly List<Rental> _rentals = new List<Rental>();

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
			double totalAmount = 0;
			int frequentRenterPoints = 0;

			// Select every inside of the parantheses and extract to method called CreateHeader
			string result = "Rental Record for " + Name + "\n";

			foreach (Rental each in _rentals)
			{
				double thisAmount = GetRentalCost(each);
				frequentRenterPoints++;

				if ((each.Movie.PriceCode == Movie.NEW_RELEASE)
					&& (each.DaysRented > 1)) 
				{
					frequentRenterPoints++;
				}

				result += ("\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n");
				totalAmount += thisAmount;
			}


			result += ("Amount owed is " + totalAmount.ToString() + "\n");
			result += ("You earned " + frequentRenterPoints.ToString() + " frequent renter points");

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
	}
}