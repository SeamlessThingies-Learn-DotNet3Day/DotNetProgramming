using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NHibernate.Mapping;

namespace St.Eg.NHibernate.Fundies.ConsoleRunner.Domain
{
	public partial class Customer
	{
		public Customer()
		{
		}

        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string CompanyName { get; set; }
	    public virtual string EmailAddress { get; set; }
	    public virtual string Phone { get; set; }
	    public virtual string SalesPersonId { get; set; }
	    public virtual string Title { get; set; }

	    public override string ToString()
	    {
	        return string.Format("{0} {1} {2}", Id, FirstName, LastName);
	    }
	}
}