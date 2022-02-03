using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Repository
{
    public static class DeliveryRepository
    {
        public static List<Delivery> GetAll()
        {
            return UnitOfWork.context.Deliveries.ToList();
        }
    }
}