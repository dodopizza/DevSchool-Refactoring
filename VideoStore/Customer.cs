using System.Collections.Generic;
using System.Linq;

namespace VideoStore
{
    public class Customer
    {
        private readonly List<Rental> rentals = new List<Rental>();

        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Statement()
        {
            var result = $"Rental Record for {Name}\n";

            foreach (var rental in rentals)
            {
                result += $"\t{rental.Movie.Title}\t{rental.Cost}\n";
            }

            result += $"Amount owed is {GetTotalCost()}\n";
            result += $"You earned {TotalFrequentRenterPoints()} frequent renter points";

            return result;
        }

        private int TotalFrequentRenterPoints()
        {
            return rentals.Sum(_ => _.FrequentRenterPoints);
        }

        private double GetTotalCost()
        {
            return rentals.Sum(_ => _.Cost);
        }
    }
}