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
			return string.Concat(
				GetStatementHeader(),
				GetRentalLines(),
				GetOwedLine(),
				GetPointsLine());
		}

		private string GetRentalLines()
		{
			return string.Concat(rentals.Select(GetRentalLine));
		}

		private string GetPointsLine()
		{
			return "You earned " + GetTotalRenterPoints() + " frequent renter points";
		}

		private string GetOwedLine()
		{
			return "Amount owed is " + GetTotalRentalCost() + "\n";
		}

		private string GetStatementHeader()
		{
			return "Rental Record for " + Name + "\n";
		}

		private static string GetRentalLine(Rental rental)
		{
			return "\t" + rental.Movie.Title + "\t" + rental.GetRentalCost() + "\n";
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