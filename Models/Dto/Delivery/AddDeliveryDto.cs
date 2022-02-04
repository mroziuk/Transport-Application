using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Models.Dto.Delivery
{
    public class AddDeliveryDto
    {
        public string PaymentStatus { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
    }
}