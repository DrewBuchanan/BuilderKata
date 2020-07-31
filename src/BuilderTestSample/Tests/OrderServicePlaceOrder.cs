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

		public class OrderServiceValidateOrderMethod : OrderServicePlaceOrder
		{
			[Fact]
			public void ThrowsExceptionGivenOrderWithExistingId ()
			{
				Order order = _orderBuilder
								.WithTestValues ()
								.WithId (123);

				Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
			}

			[Fact]
			public void ThrowsExceptionGivenOrderWithNegativeAmount()
			{
				Order order = _orderBuilder
					.WithTestValues ()
					.WithAmount (-1);

				Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
			}

			[Fact]
			public void ThrowsExceptionGivenOrderWithZeroAmount ()
			{
				Order order = _orderBuilder
					.WithTestValues ()
					.WithAmount (0);

				Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
			}

			[Fact]
			public void ThrowsExceptionGivenOrderWithNullCustomer()
			{
				Order order = _orderBuilder
					.WithTestValues ()
					.WithCustomer (null);

				Assert.Throws<InvalidOrderException> (() => _orderService.PlaceOrder (order));
			}
		}
	}
}
