using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    public class Customer
    {
        public string Name { get; }
        private readonly List<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }

        public string Statement()
        {
            var result = "Rental Record for " + Name + "\n";

            foreach (var rental in rentals)
            {
                result += "\t" + rental.Movie.Title + "\t" + rental.Cost + "\n";
            }

            result += "Amount owed is " + GetTotalCost(rentals) + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints(rentals) + " frequent renter points";

            return result;
        }

        private static int GetTotalFrequentRenterPoints(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(rental => rental.FrequentRenterPoints);
        }

        private static double GetTotalCost(IEnumerable<Rental> rentals)
        {
            return rentals.Sum(rental => rental.Cost);
        }
    }
}