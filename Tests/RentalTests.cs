using VideoStore;
using Xunit;

namespace Tests
{
	public class RentalTests 
	{
		private Rental rental;
		private Movie movie;

		public RentalTests()
		{
			
			movie = new MovieChildren("some movie");
			rental = new Rental(movie, 1);
		}

		[Fact]
		public void GetDaysRented() 
		{
			Assert.Equal(1, rental.DaysRented);
		}
  
		[Fact]
		public void GetMovie() 
		{
			Assert.Equal(movie, rental.Movie);
		}
	}
}