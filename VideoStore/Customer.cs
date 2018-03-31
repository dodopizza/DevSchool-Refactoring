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
			return string.Join("\n",
				GetStatementHeader(),
				GetRentalLines(),
				GetOwedLine(),
				GetPointsLine());
		}

		private string GetRentalLines()
		{
			return string.Join("\n", rentals.Select(GetRentalLine));
		}

		private string GetPointsLine()
		{
			return "You earned " + GetTotalRenterPoints() + " frequent renter points";
		}

		private string GetOwedLine()
		{
			return "Amount owed is " + GetTotalRentalCost();
		}

		private string GetStatementHeader()
		{
			return "Rental Record for " + Name;
		}

		private static string GetRentalLine(Rental rental)
		{
			return "\t" + rental.Movie.Title + "\t" + rental.GetRentalCost();
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