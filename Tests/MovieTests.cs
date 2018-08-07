using VideoStore;
using Xunit;

namespace Tests
{
	public class MovieTests
	{
		[Fact]
		public void GetRegularMovieTitle()
		{
			var movie = new RegularMovie("some movie");

			Assert.Equal("some movie", movie.Title);
		}

		[Fact]
		public void GetChildrensMovieTitle()
		{
			var movie = new ChildrensMovie("some movie");

			Assert.Equal("some movie", movie.Title);
		}

		[Fact]
		public void GetNewReleaseMovieTitle()
		{
			var movie = new NewReleaseMovie("some movie");

			Assert.Equal("some movie (New)", movie.Title);
		}
	}
}