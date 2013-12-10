using System;
using NUnit.Framework;
using VideoStore;

namespace Tests
{
	[TestFixture]
	public class CustomerTests
	{
		private const string NAME = "Joe";
		private const string SHOW_NAME1 = "show1";
		private const string SHOW_NAME2 = "show2";
		private const string SHOW_NAME3 = "show3";
		private Customer customer;

		[SetUp]
		public void Init()
		{
			customer = new Customer(NAME);
		}

		[Test]
		public void GetName()
		{
			Assert.AreEqual(NAME, customer.Name);
		}

		[Test]
		public void StatementNoMovies()
		{
			AssertStatement(null, 0, 0, 0);
		}

		[Test]
		public void StatementOneNewMovieOneDay()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.NEW_RELEASE), 1));
			AssertStatement(SHOW_NAME1 + " (New)", 3.0f, 3.0f, 1);
		}

		[Test]
		public void StatementOneNewMovieTwoDay()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.NEW_RELEASE), 2));
			AssertStatement(SHOW_NAME1 + " (New)", 6.0f, 6.0f, 2);
		}

		[Test]
		public void StatementOneNewMovieThreeDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.NEW_RELEASE), 3));
			AssertStatement(SHOW_NAME1 + " (New)", 9.0f, 9.0f, 2);
		}

		[Test]
		public void StatementOneRegularMovieOneDay()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.REGULAR), 1));
			AssertStatement(SHOW_NAME1, 2.0f, 2.0f, 1);
		}

		[Test]
		public void StatementOneRegularMovieTwoDay()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.REGULAR), 2));
			AssertStatement(SHOW_NAME1, 2.0f, 2.0f, 1);
		}

		[Test]
		public void StatementOneRegularMovieThreeDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.REGULAR), 3));
			AssertStatement(SHOW_NAME1, 3.5f, 3.5f, 1);
		}

		[Test]
		public void StatementOneChildMovieOneDay()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.CHILDRENS), 1));
			AssertStatement(SHOW_NAME1, 1.5f, 1.5f, 1);
		}

		[Test]
		public void StatementOneChildMovieThreeDay()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.CHILDRENS), 3));
			AssertStatement(SHOW_NAME1, 1.5f, 1.5f, 1);
		}

		[Test]
		public void StatementOneChildMovieFourDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.CHILDRENS), 4));
			AssertStatement(SHOW_NAME1, 3.0f, 3.0f, 1);
		}

		[Test]
		public void StatementTwoNewMoviesThreeDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.NEW_RELEASE), 3));
			customer.AddRental(new Rental(new Movie(SHOW_NAME2, Movie.NEW_RELEASE), 3));
			AssertStatement(new String[] {SHOW_NAME1 + " (New)", SHOW_NAME2 + " (New)"}, new float[] {9f, 9f}, 18f, 4);
		}

		[Test]
		public void StatementTwoRegularMoviesThreeDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.REGULAR), 3));
			customer.AddRental(new Rental(new Movie(SHOW_NAME2, Movie.REGULAR), 3));
			AssertStatement(new String[] {SHOW_NAME1, SHOW_NAME2}, new float[] {3.5f, 3.5f}, 7.0f, 2);
		}

		[Test]
		public void StatementTwoChildMoviesFourDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.CHILDRENS), 4));
			customer.AddRental(new Rental(new Movie(SHOW_NAME2, Movie.CHILDRENS), 4));
			AssertStatement(new String[] {SHOW_NAME1, SHOW_NAME2}, new float[] {3f, 3f}, 6.0f, 2);
		}

		[Test]
		public void StatementAllThreeTypesMoviesFourDays()
		{
			customer.AddRental(new Rental(new Movie(SHOW_NAME1, Movie.NEW_RELEASE), 4));
			customer.AddRental(new Rental(new Movie(SHOW_NAME2, Movie.REGULAR), 4));
			customer.AddRental(new Rental(new Movie(SHOW_NAME3, Movie.CHILDRENS), 4));
			AssertStatement(new String[] {SHOW_NAME1 + " (New)", SHOW_NAME2, SHOW_NAME3}, new float[] {12f, 5f, 3f}, 20f, 4);
		}

		private void AssertStatement(String show, float showCost, float totalCost, int frequentPoints)
		{
			AssertStatement(new String[] {show}, new float[] {showCost}, totalCost, frequentPoints);
		}

		private void AssertStatement(String[] shows, float[] showCosts, float totalCost, int frequentPoints)
		{
			String showList = "";
			if (shows[0] != null) for (int i = 0; i < shows.Length; i++) showList += ("\t" + shows[i] + "\t" + showCosts[i] + "\n");
			Assert.AreEqual("Rental Record for Joe\n" + showList + "Amount owed is " + totalCost + "\n" + "You earned " + frequentPoints + " frequent renter points", customer.Statement());
		}
	}
}