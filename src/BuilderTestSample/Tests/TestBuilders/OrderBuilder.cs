﻿using System;
using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
	/// <summary>
	/// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
	/// </summary>
	public class OrderBuilder
	{
		private Order _order = new Order ();

		public OrderBuilder WithId (int id)
		{
			_order.Id = id;
			return this;
		}

		public OrderBuilder WithAmount (decimal amount)
		{
			_order.TotalAmount = amount;
			return this;
		}

		public Order WithCustomer (Customer customer)
		{
			_order.Customer = customer;
			return this;
		}

		public Order Build ()
		{
			return _order;
		}

		public OrderBuilder WithTestValues ()
		{
			_order.TotalAmount = 100m;
			_order.Id = 0;

			// TODO: replace next lines with a CustomerBuilder you create
			// _order.Customer = new Customer();
			// _order.Customer.HomeAddress = new Address();

			return this;
		}

		public static implicit operator Order (OrderBuilder builder)
		{
			return builder.Build ();
		}
	}
}
