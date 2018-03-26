using System;
using NUnit.Framework;
using VideoStore;

namespace Tests
{
	[TestFixture]
	public class MovieTests 
	{
		private const string MOVIE_TITLE = "some movie";
		private Movie movie;
  
		[SetUp]
		public void Init() 
		{
			movie = new RegularMovie(MOVIE_TITLE, Movie.REGULAR);
		}
  
		[Test]
		public void GetPriceCode() 
		{
			Assert.AreEqual(Movie.REGULAR, movie.PriceCode);
		}
  

		[Test]
		public void GetTitle() 
		{
			Assert.AreEqual(MOVIE_TITLE, movie.Title);
		}
	}
}