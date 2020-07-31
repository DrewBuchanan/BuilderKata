using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
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
			Order order = _orderBuilder
							.WithTestValues ()
							.Id (123);

			Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
		}

		[Fact]
		public void ThrowsExceptionGivenOrderWithNegativeAmount()
		{
			Order order = _orderBuilder
				.WithTestValues ()
				.Amount (-1);

			Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
		}

		[Fact]
		public void ThrowsExceptionGivenOrderWithZeroAmount ()
		{
			Order order = _orderBuilder
				.WithTestValues ()
				.Amount (0);

			Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
		}
	}
}
