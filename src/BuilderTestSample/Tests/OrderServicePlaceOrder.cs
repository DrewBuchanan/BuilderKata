using BuilderTestSample.Exceptions;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
	public class OrderServicePlaceOrder
	{
		private readonly OrderService _orderService = new OrderService ();
		private readonly OrderBuilder _orderBuilder = new OrderBuilder ();

		[Fact]
		public void ThrowsExceptionGivenOrderWithExistingId ()
		{
			var order = _orderBuilder
							.WithTestValues ()
							.Id (123)
							.Build ();

			Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
		}

		[Fact]
		public void ThrowsExceptionGivenOrderWithNegativeAmount()
		{
			var order = _orderBuilder
				.WithTestValues ()
				.Id (0)
				.Amount (-1)
				.Build ();

			Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
		}

		[Fact]
		public void ThrowsExceptionGivenOrderWithZeroAmount ()
		{
			var order = _orderBuilder
				.WithTestValues ()
				.Id (0)
				.Amount (0)
				.Build ();

			Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
		}
	}
}
