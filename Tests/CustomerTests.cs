using VideoStore;
using Xunit;

namespace Tests
{
    public class CustomerTests
    {
        private Customer customer;

        public CustomerTests()
        {
            customer = new Customer("Joe");
        }

        [Fact]
        public void GetName()
        {
            Assert.Equal("Joe", customer.Name);
        }

        [Fact]
        public void StatementNoMovies()
        {
            AssertStatement(null, 0, 0, 0);
        }

        [Fact]
        public void StatementOneNewMovieOneDay()
        {
            customer.AddRental(new Rental(new NewReleaseMovie("show1"), 1));
            AssertStatement("show1" + " (New)", 3.0f, 3.0f, 1);
        }

        [Fact]
        public void StatementOneNewMovieTwoDay()
        {
            customer.AddRental(new Rental(new NewReleaseMovie("show1"), 2));
            AssertStatement("show1" + " (New)", 6.0f, 6.0f, 2);
        }

        [Fact]
        public void StatementOneNewMovieThreeDays()
        {
            customer.AddRental(new Rental(new NewReleaseMovie("show1"), 3));
            AssertStatement("show1" + " (New)", 9.0f, 9.0f, 2);
        }

        [Fact]
        public void StatementOneRegularMovieOneDay()
        {
            customer.AddRental(new Rental(new RegularMovie("show1"), 1));
            AssertStatement("show1", 2.0f, 2.0f, 1);
        }

        [Fact]
        public void StatementOneRegularMovieTwoDay()
        {
            customer.AddRental(new Rental(new RegularMovie("show1"), 2));
            AssertStatement("show1", 2.0f, 2.0f, 1);
        }

        [Fact]
        public void StatementOneRegularMovieThreeDays()
        {
            customer.AddRental(new Rental(new RegularMovie("show1"), 3));
            AssertStatement("show1", 3.5f, 3.5f, 1);
        }

        [Fact]
        public void StatementOneChildMovieOneDay()
        {
            customer.AddRental(new Rental(new Movie("show1", Movie.CHILDRENS), 1));
            AssertStatement("show1", 1.5f, 1.5f, 1);
        }

        [Fact]
        public void StatementOneChildMovieThreeDay()
        {
            customer.AddRental(new Rental(new Movie("show1", Movie.CHILDRENS), 3));
            AssertStatement("show1", 1.5f, 1.5f, 1);
        }

        [Fact]
        public void StatementOneChildMovieFourDays()
        {
            customer.AddRental(new Rental(new Movie("show1", Movie.CHILDRENS), 4));
            AssertStatement("show1", 3.0f, 3.0f, 1);
        }

        [Fact]
        public void StatementTwoNewMoviesThreeDays()
        {
            customer.AddRental(new Rental(new NewReleaseMovie("show1"), 3));
            customer.AddRental(new Rental(new NewReleaseMovie("show2"), 3));
            AssertStatement(new[] {"show1" + " (New)", "show2" + " (New)"}, new[] {9f, 9f}, 18f, 4);
        }

        [Fact]
        public void StatementTwoRegularMoviesThreeDays()
        {
            customer.AddRental(new Rental(new RegularMovie("show1"), 3));
            customer.AddRental(new Rental(new RegularMovie("show2"), 3));
            AssertStatement(new[] {"show1", "show2"}, new[] {3.5f, 3.5f}, 7.0f, 2);
        }

        [Fact]
        public void StatementTwoChildMoviesFourDays()
        {
            customer.AddRental(new Rental(new Movie("show1", Movie.CHILDRENS), 4));
            customer.AddRental(new Rental(new Movie("show2", Movie.CHILDRENS), 4));
            AssertStatement(new[] {"show1", "show2"}, new[] {3f, 3f}, 6.0f, 2);
        }

        [Fact]
        public void StatementAllThreeTypesMoviesFourDays()
        {
            customer.AddRental(new Rental(new NewReleaseMovie("show1"), 4));
            customer.AddRental(new Rental(new RegularMovie("show2"), 4));
            customer.AddRental(new Rental(new Movie("show3", Movie.CHILDRENS), 4));
            AssertStatement(new[] {"show1" + " (New)", "show2", "show3"}, new[] {12f, 5f, 3f}, 20f, 4);
        }

        private void AssertStatement(string show, float showCost, float totalCost, int frequentPoints)
        {
            AssertStatement(new[] {show}, new[] {showCost}, totalCost, frequentPoints);
        }

        private void AssertStatement(string[] shows, float[] showCosts, float totalCost, int frequentPoints)
        {
            var showList = "";
            if (shows[0] != null)
                for (var i = 0; i < shows.Length; i++)
                    showList += "\t" + shows[i] + "\t" + showCosts[i] + "\n";
            Assert.Equal(
                "Rental Record for Joe\n" + showList + "Amount owed is " + totalCost + "\n" + "You earned " + frequentPoints + " frequent renter points", customer.Statement());
        }
    }
}