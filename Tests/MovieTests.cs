using VideoStore;
using Xunit;

namespace Tests
{
	public class MovieTests
	{
		private const string MOVIE_TITLE = "some movie";
		private Movie movie;

		public MovieTests()
		{
			movie = new Movie(MOVIE_TITLE, Movie.REGULAR);
		}
  
		[Fact]
		public void GetPriceCode() 
		{
			Assert.Equal(Movie.REGULAR, movie.PriceCode);
		}
  
		[Fact]
		public void SetPriceCode() 
		{
			movie.PriceCode = Movie.CHILDRENS;

			Assert.Equal(Movie.CHILDRENS, movie.PriceCode);
		}
  
		[Fact]
		public void GetTitle() 
		{
			Assert.Equal(MOVIE_TITLE, movie.Title);
		}
	}
}