using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> ProductsId { get; set; }
        public Address DeliveryAddress { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime CreateTime { get; set; }
    }
}