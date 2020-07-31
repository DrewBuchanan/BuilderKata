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
		private string firstName;
		private string lastName;

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

		public Customer WithFirstName (string fname)
		{
			this.firstName = fname;
			return this;
		}

		public CustomerBuilder WithLastName (string lname)
		{
			this.lastName = lname;
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
			_customer = new Customer (this.id);
			_customer.HomeAddress = this.address;
			_customer.FirstName = this.firstName;
			_customer.LastName = this.lastName;
			return _customer;
		}

		public static implicit operator Customer(CustomerBuilder builder)
		{
			return builder.Build ();
		}
	}
}
