using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.ViewModels
{
    public class AddDeliveryViewModel
    {
        public int AddressFromId { get; set; }
        public int AddressToId { get; set; }
        public int CustomerId { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
    }
}