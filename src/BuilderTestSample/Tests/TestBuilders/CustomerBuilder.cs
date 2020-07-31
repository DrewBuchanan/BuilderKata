using BuilderTestSample.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderTestSample.Tests.TestBuilders
{
	public class CustomerBuilder
	{
		private Customer _customer;
		private int id;
		private Address address;

		public CustomerBuilder WithId(int id)
		{
			this.id = id;
			return this;
		}

		public CustomerBuilder WithAddress (Address address)
		{
			this.address = address;
			return this;
		}

		public CustomerBuilder WithTestValues()
		{
			_customer = new Customer (1);
			_customer.HomeAddress = new Address ();
			return this;
		}

		public Customer Build()
		{
			_customer = new Customer (id);
			_customer.HomeAddress = address;
			return _customer;
		}

		public static implicit operator Customer(CustomerBuilder builder)
		{
			return builder.Build ();
		}
	}
}
