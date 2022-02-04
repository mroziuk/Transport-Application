using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Models.Dto.Delivery
{
    public class GetDeliveryDto
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerId { get; set; }
        public int AddressFromId{ get; set; }
        public int AddressToId{ get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public GetDeliveryDto(Transport.Delivery delivery)
        {
            Id = delivery.Id;
            CustomerId = delivery.CustomerId;
            AddressToId = delivery.AddressToId;
            AddressFromId = delivery.AddressFromId;
            PaymentStatus = delivery.PaymentStatus;
            DeliveryStatus = delivery.DeliveryStatus;
            CreateTime = delivery.CreateTime;
            CustomerEmail = delivery.Customer.Email;
        }
    }
}