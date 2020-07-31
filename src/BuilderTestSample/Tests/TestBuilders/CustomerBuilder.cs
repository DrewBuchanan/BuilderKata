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

		public CustomerBuilder WithId(int id)
		{
			this.id = id;
			return this;
		}

		public Customer Build()
		{
			_customer = new Customer (id);

			return _customer;
		}

		public static implicit operator Customer(CustomerBuilder builder)
		{
			return builder.Build ();
		}
	}
}
