using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Transport.Models.Dto.Delivery;
using Transport.Repository;

namespace Transport.ApiControllers
{
    public class DeliveryApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            GetDeliveryDto delivery = new GetDeliveryDto(UnitOfWork.context.Deliveries.FirstOrDefault());
            return this.Ok(delivery);
        }
        public IHttpActionResult Post(AddDeliveryDto dto)
        {
            Address addressFrom = new Address()
            {
                Country = dto.AddressFrom.Country,
                City = dto.AddressFrom.City,
                Street = dto.AddressFrom.Street,
                Number = dto.AddressFrom.Number,
            };
            Address addressTo = new Address()
            {
                Country = dto.AddressTo.Country,
                City = dto.AddressTo.City,
                Street = dto.AddressTo.Street,
                Number = dto.AddressTo.Number,
            };
            //add addresses to databsase
            //TODO: check if address already in the database
            UnitOfWork.context.Addresses.InsertOnSubmit(addressFrom);
            UnitOfWork.context.Addresses.InsertOnSubmit(addressTo);
            UnitOfWork.context.SubmitChanges();
            int fromId = UnitOfWork.context.Addresses.First(a =>
                a.Country == addressFrom.Country &&
                a.City == addressFrom.City &&
                a.Street == addressFrom.Street &&
                a.Number == addressFrom.Number
            ).Id;
            int toId = UnitOfWork.context.Addresses.First(a =>
                a.Country == addressTo.Country &&
                a.City == addressTo.City &&
                a.Street == addressTo.Street &&
                a.Number == addressTo.Number
            ).Id;

            Delivery delivery = new Delivery()
            {
                CustomerId = 1,
                AddressFromId = fromId,
                AddressToId = toId,
                PaymentStatus = "not paid",
                DeliveryStatus = "not delivered yet"
            };
            UnitOfWork.context.Deliveries.InsertOnSubmit(delivery);
            UnitOfWork.context.SubmitChanges();
            return Ok(new GetDeliveryDto(delivery));
        }
    }
}