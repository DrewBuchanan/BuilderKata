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

		public class OrderServiceValidateCustomerMethod : OrderServicePlaceOrder
		{
			private readonly CustomerBuilder _customerBuilder = new CustomerBuilder ();

			[Fact]
			public void ThrowsExceptionWhenGivenCustomerWithNegativeId()
			{
				Customer customer = _customerBuilder
					.WithId (-1);

				Order order = _orderBuilder
					.WithTestValues ()
					.WithCustomer (customer);

				Assert.Throws<InvalidCustomerException> (() => _orderService.PlaceOrder (order));
			}

			[Fact]
			public void ThrowsExceptionWhenGivenCustomerWithZeroId()
			{
				Customer customer = _customerBuilder
					.WithId (0);

				Order order = _orderBuilder
					.WithTestValues ()
					.WithCustomer (customer);

				Assert.Throws<InvalidCustomerException> (() => _orderService.PlaceOrder (order));
			}

			[Fact]
			public void ThrowsExceptionWhenGivenCustomerWithNullAddress()
			{
				Customer customer = _customerBuilder
					.WithId (1)
					.WithAddress (null);

				Order order = _orderBuilder
					.WithTestValues ()
					.WithCustomer (customer);

				Assert.Throws<InvalidCustomerException> (() => _orderService.PlaceOrder (order));
			}
		}
	}
}
