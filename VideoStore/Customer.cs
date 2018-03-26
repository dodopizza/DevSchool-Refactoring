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
            var frequentRenterPoints = 0;

            var result = $"Rental Record for {Name}\n";

            foreach (var rental in rentals)
            {
                var thisAmount = rental.Cost;
                frequentRenterPoints += rental.FrequentRenterPoints;

                result += $"\t{rental.Movie.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            }


            result += $"Amount owed is {totalAmount}\n";
            result += $"You earned {frequentRenterPoints} frequent renter points";

            return result;
        }
    }
}