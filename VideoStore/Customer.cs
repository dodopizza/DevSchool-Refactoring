using System.Collections.Generic;

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
            double totalAmount = 0;

            var result = $"Rental Record for {Name}\n";

            foreach (var rental in rentals)
            {
                result += $"\t{rental.Movie.Title}\t{rental.Cost}\n";
                totalAmount += rental.Cost;
            }


            result += $"Amount owed is {totalAmount}\n";
            result += $"You earned {TotalFrequentRenterPoints()} frequent renter points";

            return result;
        }

        private int TotalFrequentRenterPoints()
        {
            var frequentRenterPoints = 0;

            foreach (var rental in rentals)
            {
                frequentRenterPoints += rental.FrequentRenterPoints;
            }

            return frequentRenterPoints;
        }
    }
}