using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string  FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAccount { get; set; }
        public int AddressId { get; set; }

    }
}