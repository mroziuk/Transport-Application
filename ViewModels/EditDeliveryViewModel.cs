using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.ViewModels
{
    public class EditDeliveryViewModel
    {
        public int Id { get; set; }

        public int? NewAddressFromId { get; set; }
        public int? NewAddressToId { get; set; }
        public int? NewCustomerId { get; set; }
        public string NewPaymentStatus { get; set; }
        public string NewDeliveryStatus { get; set; }
    }
}