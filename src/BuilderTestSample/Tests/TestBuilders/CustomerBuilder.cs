using BuilderTestSample.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderTestSample.Tests.TestBuilders
{
	public class CustomerBuilder
	{
		private Customer _customer;
		private int id = 1;
		private Address address;
		private string firstName;
		private string lastName;
		private int creditScore;

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

		public CustomerBuilder WithCreditScore (int creditScore)
		{
			this.creditScore = creditScore;
			return this;
		}

		public CustomerBuilder WithTestValues()
		{
			id = 1;
			address = new Address ();
			firstName = "Drew";
			lastName = "Buchanan";
			return this;
		}

		public Customer Build()
		{
			_customer = new Customer (this.id);
			_customer.HomeAddress = this.address;
			_customer.FirstName = this.firstName;
			_customer.LastName = this.lastName;
			_customer.CreditRating = this.creditScore;
			return _customer;
		}

		public static implicit operator Customer(CustomerBuilder builder)
		{
			return builder.Build ();
		}
	}
}
