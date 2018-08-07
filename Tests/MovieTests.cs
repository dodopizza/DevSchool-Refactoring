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
			movie = new RegularMovie(MOVIE_TITLE);
		}
  
		[Fact]
		public void GetTitle() 
		{
			Assert.Equal(MOVIE_TITLE, movie.Title);
		}
	}
}